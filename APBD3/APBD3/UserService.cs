namespace APBD3;

public class UserService
{
    private static List<User> _users = new List<User>();

    public void add_user(User user)
    {
        _users.Add(user);
        Console.WriteLine("User names "+user.Name+" added");
    }

    public static string get_role(long id)
    {
        string this_role = "";
        foreach (var user in _users)
        {
            if (user.Id == id)
            {
                this_role = user.Role;
            }
        }

        return this_role;
    }
    





}