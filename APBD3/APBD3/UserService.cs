namespace APBD3;

public class UserService
{
    static DataBase db =  new DataBase();

    public void add_user(User user)
    {
        db._Users.Add(user);
        Console.WriteLine("User names "+user.Name+" added");
    }

    public static string get_role(long id)
    {
        string this_role = "";
        foreach (var user in db._Users)
        {
            if (user.Id == id)
            {
                this_role = user.Role;
            }
        }

        return this_role;
    }
    





}