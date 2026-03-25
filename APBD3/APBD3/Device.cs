namespace APBD3;


public abstract class Device
{
    private string name
    {
        get
        {
            return this.name;
        }
        set { this.name = value; }
    }

    private long year_of_production {
        get { return this.year_of_production; }
        set{ this.year_of_production = value; }
    }

    private string producer
    {
        set { this.producer = value;}
        get{ return this.producer;} }
    
    private string status;

    public string Status
    {
        get { return this.status; }
        set { this.status = value; }
    }

    private string type;

    public string Type
    {
        get { return this.type; }
        set { this.type = value; }
    }


    private long identifier = Random.Shared.NextInt64(1000, 10000);

    public long Identifier{get { return this.identifier;}}

    public Device(string name,string status,long year_of_production,string producer)
    {
        this.name =  name;
        this.status = status;
        
    }
    
        







}