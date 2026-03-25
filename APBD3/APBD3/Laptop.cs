using System.Runtime.InteropServices.Swift;

namespace APBD3;

public class Laptop : Device
{
    private string type_of_device = "Laptop";

    public string Type  {
        get { return type_of_device; }
    }
    
    public Laptop(string name,string status,long year,string producer): base(name,status,year,producer){}
    
    
}