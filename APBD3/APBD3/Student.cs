namespace APBD3;

public class Student : User
{
    public Student(string name) : base(name)
    {
        this.Role = "Student";
    }
    
}