namespace APBD3;

public class DataBase
{
    private List<Device> list_of_devices = new List<Device>();
    private List<Borrowing> _borrowings = new List<Borrowing>();
    private List<Punishment.Debt> debts = new List<Punishment.Debt>();
    private List<User> _users = new List<User>();


    public List<Device> List_of_devices {
        get { return list_of_devices; }
    }
    public List<Borrowing> _Borrowings {
        get { return _borrowings; }
    }
    public List<Punishment.Debt> Debts {
        get {return debts; }
    }
    public List<User> _Users { get { return _users; } }
    
}