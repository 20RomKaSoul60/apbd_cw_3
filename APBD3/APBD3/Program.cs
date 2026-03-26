namespace APBD3;

public class Program
{
    public static void Main(string[] args)
    {
        DeviceService ds = new DeviceService();
        UserService us = new UserService();

        while (true)
        {
            Console.WriteLine("Choose an option:\n" +
                              "1 - Add a new device \n" +
                              "2 - Add a new user\n" +
                              "3 - Borrow some device\n" +
                              "4 - Refund the device\n" +
                              "5 - Print a raport\n" +
                              "6 - Exit");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("Enter a name");
                string name = Console.ReadLine().Trim();
                string status = "AVAILABLE";
                Console.WriteLine("Enter a year");
                long year = long.Parse(Console.ReadLine());
                Console.WriteLine("Enter a producer");
                string producer = Console.ReadLine().Trim();
                Console.WriteLine("Which type of device do you want to add?\n1 - Laptop\n2 - Projector\n3 - Camera");
                string type = Console.ReadLine().Trim();
                switch (type)
                {
                    case "1": ds.addDevice(new Laptop(name, status,year, producer)); break;
                    case "2": ds.addDevice(new Projector(name, status, year, producer)); break;
                    case "3": ds.addDevice(new Camera(name, status, year, producer)); break;
                }
            }
            else if (input == "2")
            {
                Console.WriteLine("Enter your name:");
                string name = Console.ReadLine().Trim();
                Console.WriteLine("Is it a student <1> or an employee<2> ? ");
                string user_type = Console.ReadLine().Trim();
                switch (user_type)
                {
                    case "1": us.add_user(new Student(name));break;
                    case "2": us.add_user(new Employee(name));break;
                }
            }
            else if (input == "3")
            {
                Console.WriteLine("Enter your id");
                long user_id = long.Parse(Console.ReadLine().Trim());
                Console.WriteLine("Enter a type");
                string type = Console.ReadLine().Trim();
                long new_id = IdGenerator.generate();
            
                if (ds.borrow(new_id,user_id, type))
                {
                    Console.WriteLine("You borrowed a "+type+". Your borrowing id is: "+new_id+". Remember it !!!!!!!!!");
                }
                else
                {
                    Console.WriteLine("Unsuccessful borrow - try again or try to borrow another type of device");
                }
            }
            else if (input == "4")
            {
                Console.WriteLine("Enter an id of borrowing");
                long id = long.Parse(Console.ReadLine().Trim());
                Console.WriteLine("Enter your id");
                long your_id = long.Parse(Console.ReadLine().Trim());
                string moment = DateTime.Today.Date.ToString("dd/MM/yyyy");
                ds.refund(id,your_id,moment);
                foreach (var borrowing in ds.get_delayed_borrowings())
                {
                    if (borrowing.Id_of_borrower == your_id)
                    {
                         float amount = ds.get_debt(your_id).Debt_Amount;
                         Console.WriteLine("User "+your_id +" refunded device not at time has debt in count of "+amount);
                    }
                    else
                    {
                        Console.WriteLine("Everything is ok, you refunded the device at time");
                    }
                }
                
            }
            else if (input == "5")
            {
                ds.summarise();
            }
            else if (input == "6")
            {
                Console.WriteLine("You left the system");
                break;
            }
            
        }
    }
}