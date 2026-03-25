
namespace APBD3;
public class DeviceService
{
    static DataBase db =  new DataBase();

    private float price_for_damage = 600.0f;
    private float price_for_delay = 25.50f;


    public List<Device> filter(string type)
    {
        List<Device> filtered_by = new List<Device>();
        foreach (var device in db.List_of_devices)
        {
            if (device.Type == type)
            {
                filtered_by.Add(device);
            }
            
        }
        return filtered_by;
    }
    public void addDevice(Device device)
    {
        db.List_of_devices.Add(device);
        Console.WriteLine("New "+device.Type+" was added to system");
    }

    public List<Device> get_devices()
    {
        db.List_of_devices.ForEach(device => Console.WriteLine(device.Type+" : "+device.Identifier));
        return db.List_of_devices;
    }

    public static List<Device> get_available_devices(List<Device> devices)
    {
        List<Device> avialable_devices = new List<Device>();
        foreach (var device in devices)
        {
            if (device.Status == "AVAILABLE")
            {
                Console.WriteLine(device.Identifier+": "+device.Type + " is available");
                avialable_devices.Add(device);
            }
        }

        return avialable_devices;
    }

    public List<Borrowing> get_active_borrowings(long borrower)
    {
        List<Borrowing> active_borrowings = new List<Borrowing>();
        foreach (var borrowing in db._Borrowings)
        {
            if (borrowing.Status == "ACTIVE" && borrowing.Id_of_borrower == borrower)
            {
                active_borrowings.Add(borrowing);
            }
        }
        return active_borrowings;
    }

    public List<Borrowing> get_delayed_borrowings()
    {
        List<Borrowing> delayed = new List<Borrowing>();
        foreach (var borrowing in db._Borrowings)
        {
            if(!borrowing.on_time){
                delayed.Add(borrowing);
                
            }
        }
        return delayed;
    }

    public bool borrow(long borrower,string type)
    {
        if (get_available_devices(filter(type)).Count == 0 || !Punishment.check_border_for_a_role(borrower,db._Borrowings))
            {
                Console.WriteLine("Borrow for "+borrower.ToString()+" is not available");
            return false;
            }
        
        string current_date = (DateTime.Today.Date).ToString();
        long device = filter(type)[0].Identifier;
        db._Borrowings.Add(new Borrowing(borrower,device,current_date,"ACTIVE"));
        foreach (var dev in get_devices())
        {
            if (dev.Identifier == device)
            {
                dev.Status = "BORROWED";
                break;
            }
        }
        
        return true;
    }

    public void refund(long id,long borrower,string moment)
    {
        float amount_of_debt = 0.0f;
        long device_identifier = 0;
        
        foreach (var bor in db._Borrowings)
        {
            if (bor.Id == id && bor.Id_of_borrower == borrower)
            {
                bor.Moment_when_given_back = moment;
                Punishment punishment = new Punishment(bor);
                if (bor.Is_given_back)
                {
                    punishment.punish();
                    if (punishment.Need_a_debt)
                    {
                        amount_of_debt+=punishment.days_of_delay(bor.Moment_from, bor.Moment_to)*price_for_delay;
                    }
                }

                foreach (var device in db.List_of_devices)
                {
                    if (device.Identifier == bor.Id_of_device)
                    {
                        device_identifier = device.Identifier;
                        if (device.State == "DAMAGED")
                        {
                            amount_of_debt += price_for_damage;
                            device.Status = "UNAVAILABLE";
                        }
                        else if (device.State == "OK")
                        {
                            device.Status = "AVAILABLE";
                        }
                    }
                }
                bor.Status = "REFUNDED";
            }
        }
        
        
        db.Debts.Add(new Punishment.Debt(borrower,device_identifier,amount_of_debt));

    }

    public void summarise()
    {
        Console.WriteLine("General amount of borrowings: "+db._Borrowings.Count());
        foreach (var borrowing in db._Borrowings)
        {
            Console.WriteLine(borrowing.toString()+"\n");
        }
        Console.WriteLine("From them are delayed: "+get_delayed_borrowings().Count());
    }


}