namespace APBD3;

public class Camera : Device
{
    private string type_of_device = "Camera";

    public string Type  {
        get { return type_of_device; }
    }
    public Camera(string name,string status,long year,string producer) : base(name,status,year,producer){}
    
}