namespace APBD3;


public abstract class Device
{
    private string name
    {
        get
        {
            return this.name;
        }
    }
    


    private string status
    {
        get { return this.status; }
        set { this.status = value; }
    }


    private long identifier = Random.Shared.NextInt64(1000, 10000);

    public long Identifier{get { return this.identifier;}}
    
        







}