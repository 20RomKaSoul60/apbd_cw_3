namespace APBD3;

public class Projector : Device
{

    private string type_of_device = "Projector";

    private string Type
    {
        get { return type_of_device; }
    }

    public Projector(string name, string status, long year, string producer) : base(name,status,year,producer) {}
}