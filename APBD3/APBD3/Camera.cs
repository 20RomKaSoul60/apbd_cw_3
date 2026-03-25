namespace APBD3;

public class Camera : Device
{

    public Camera(string name, string status, long year, string producer) : base(name, status, year, producer)
    {
        this.Type = "Camera";
    }
    
}