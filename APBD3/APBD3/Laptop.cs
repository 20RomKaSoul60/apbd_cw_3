using System.Runtime.InteropServices.Swift;

namespace APBD3;

public class Laptop : Device
{
    

    public Laptop(string name, string status, long year, string producer) : base(name, status, year, producer)
    {
        this.Type = "Laptop";
    }
    
    
}