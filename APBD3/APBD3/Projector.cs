namespace APBD3;

public class Projector : Device
{


    public Projector(string name, string status, long year, string producer) : base(name, status, year, producer)
    {
        this.Type = "Projector";
    }
}