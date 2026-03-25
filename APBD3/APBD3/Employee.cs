namespace APBD3;

public class Employee : User
{
    public Employee(string name) : base(name)
    {
        this.Role = "Employee";
    }
}