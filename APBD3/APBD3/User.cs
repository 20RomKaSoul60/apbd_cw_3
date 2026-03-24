namespace APBD3;

public abstract class User
{
    private string name
    {
        get
        {
            return this.name;
        }
    }

    private long id = Random.Shared.NextInt64(1,1000);
    
    private long Id
    {
        get
        {
            return this.id;
        }
    }
    
    
    
    


}