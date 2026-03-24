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
    
    

    private bool need_a_punishment
    {
        get
        {
            return this.need_a_punishment;
        }
        set { this.need_a_punishment = value; }
    }

    private bool need_a_debt
    {
        get { return this.need_a_debt; }
        set { this.need_a_debt = value; }

    }
    

    public void punishment()
    {
        if (moment_when_gave_back != moment_to)
        {
            if (int.Parse(moment_when_gave_back.Split('/')[0]) > int.Parse(moment_to.Split('/')[0]))
            {
                if (int.Parse(moment_when_gave_back.Split('/')[1]) == int.Parse(moment_to.Split('/')[1]))
                {
                    need_a_debt = true;
                }
                else
                {
                    need_a_debt = true;
                    need_a_punishment = true;
                }

                
            }
        }
    }


}