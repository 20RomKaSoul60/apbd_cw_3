namespace APBD3;

public class Borrowing
{
    private string moment_from
    {
        get
        { 
            return this.moment_from;
        }
    }

    private string moment_to
    {
        get
        {
            return this.moment_to;
        }
    }

    private string moment_when_gave_back
    {
        get
        {
            return this.moment_when_gave_back;
        }
    }

    private bool isGivenBack
    {
        get
        {
            return this.isGivenBack;
        }

        set
        {
            this.isGivenBack = value;
        }
    }
    
}