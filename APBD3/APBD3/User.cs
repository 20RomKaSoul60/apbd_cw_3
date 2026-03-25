namespace APBD3;

public abstract class User
{
    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    private long id = Random.Shared.NextInt64(1,1000);
    
    public long Id
    {
        get
        {
            return this.id;
        }
    }

    public User(string name)
    {
        this.name = name;
    }
    
    
    
    


}