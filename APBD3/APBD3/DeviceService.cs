namespace APBD3;

public class DeviceService
{
    private List<Device> list_of_devices = new List<Device>();
    

    public void addDevice(Device device)
    {
        list_of_devices.Add(device);
        Console.WriteLine("New "+device.Type+" was added to system");
    }
    
    
}