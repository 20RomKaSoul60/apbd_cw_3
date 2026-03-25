using Microsoft.VisualBasic.CompilerServices;

namespace APBD3;

public class DeviceService
{
     class Debt
    {
        private long borrower;
        private long device_identifier;
        private float debt_amount;

        public Debt(long identifier,long device_identifier,float amount)
        {
            this.borrower = identifier;
            this.device_identifier = device_identifier;
            this.debt_amount = amount;
        }

    }
    
    private List<Device> list_of_devices = new List<Device>();
    private List<Borrowing> _borrowings = new List<Borrowing>();
    private List<Debt> debts = new List<Debt>();

    private float price_for_damage = 600.0f;
    private float price_for_delay = 25.50f;


    public List<Device> filter(string type)
    {
        List<Device> filtered_by = new List<Device>();
        foreach (var device in list_of_devices)
        {
            if (device.Type == type)
            {
                filtered_by.Add(device);
            }
            
        }
        return filtered_by;
    }

    public bool check(long borrower)
    {
        bool answer = true;
        int counter = 0;
        foreach (var borrowing in _borrowings)
        {
            if (borrowing.Id_of_borrower == borrower)
            {
                counter++;
            }
        }

        if (UserService.get_role(borrower) == "Student")
        {
            answer = counter <= 2;
        }else if (UserService.get_role(borrower) == "Employee")
        {
            answer = counter <= 5;
        }

        return answer;

    }
    public void addDevice(Device device)
    {
        list_of_devices.Add(device);
        Console.WriteLine("New "+device.Type+" was added to system");
    }

    public List<Device> get_devices()
    {
        list_of_devices.ForEach(device => Console.WriteLine(device.Type+" : "+device.Identifier));
        return list_of_devices;
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
        foreach (var borrowing in _borrowings)
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
        foreach (var borrowing in _borrowings)
        {
            if(!borrowing.on_time){
                delayed.Add(borrowing);
                
            }
        }
        return delayed;
    }

    public bool borrow(long borrower,string type)
    {
        if (get_available_devices(filter(type)).Count == 0 || !check(borrower))
            {
                Console.WriteLine("Borrow for "+borrower.ToString()+" is not available");
            return false;
            }
        
        string current_date = (DateTime.Today.Date).ToString();
        long device = filter(type)[0].Identifier;
        _borrowings.Add(new Borrowing(borrower,device,current_date,"ACTIVE"));
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
        
        foreach (var bor in _borrowings)
        {
            if (bor.Id == id && bor.Id_of_borrower == borrower)
            {
                bor.Moment_when_given_back = moment;
                if (bor.Is_given_back)
                {
                    bor.punishment();
                    if (bor.Need_a_debt)
                    {
                        amount_of_debt+=bor.days(bor.Moment_from, bor.Moment_to)*price_for_delay;
                    }
                }

                foreach (var device in list_of_devices)
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
        
        
        debts.Add(new Debt(borrower,device_identifier,amount_of_debt));

    }

    public void summarise()
    {
        Console.WriteLine("General amount of borrowings: "+_borrowings.Count());
        foreach (var borrowing in _borrowings)
        {
            Console.WriteLine(borrowing.toString()+"\n");
        }
        Console.WriteLine("From them are delayed: "+get_delayed_borrowings().Count());
    }


}