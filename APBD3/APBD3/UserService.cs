namespace APBD3;

public class UserService
{
    private List<User> _users = new List<User>();

    public void add_user(User user)
    {
        _users.Add(user);
        Console.WriteLine("User names "+user.Name+" added");
    }
    
    





}