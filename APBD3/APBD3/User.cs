namespace APBD3;

public abstract class User
{
    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    private long id = IdGenerator.generate();
    
    public long Id
    {
        get
        {
            return this.id;
        }
    }

    private string role;

    public string Role
    {
        get { return this.role; }
        set { this.role = value; }
    }

    public User(string name)
    {
        this.name = name;
    }
    
    
    
    
    
    


}