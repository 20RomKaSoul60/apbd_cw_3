namespace APBD3;

public class Borrowing
{
    
    private long id_of_borrower {
        get { return this.id_of_borrower; }
        set { this.id_of_borrower = value; }

    }

    private long id_of_device
    {
        get { return this.id_of_borrower; }
        set { this.id_of_borrower = value; }
    }


    private string moment_from
    {
        get { return this.moment_from; }
        set { this.moment_from = value; }
    }

    private string moment_to
    {
        get { return this.moment_to; }
        set { this.moment_to = value; }
    }

    private string moment_when_given_back
    {
        get
        {
            return this.moment_when_given_back;
        }
        set
        {
            this.moment_when_given_back = value;
        }
    }

    private bool on_time
    {
        get { return this.on_time; }
        set { this.on_time = value; }
    }
    
    private bool is_given_back
    {
        get
        {
            return this.is_given_back;
        }

        set
        {
            this.is_given_back = value;
            if (value == true)
            {
                if (this.moment_to == this.moment_when_given_back)
                {
                    this.on_time = true;
                }
                else
                {
                    this.on_time = false;
                }
            }
        }
    }

    

    public Borrowing(long borrower, long device,string moment_from,string moment_to)
    {
        this.id_of_borrower = borrower;
        this.id_of_device = device;
        this.moment_from = moment_from;
        this.moment_to = moment_from.Split('/')[0].Trim()
                         +string.Join('/', int.Parse(moment_from.Split('/')[1].Trim())+1,'/')
                         +moment_from.Split('/')[2].Trim();
        this.moment_when_given_back = moment_to; 

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
        if (!on_time)
        {
            if (int.Parse(moment_when_given_back.Split('/')[0]) > int.Parse(moment_to.Split('/')[0]))
            {
                if (int.Parse(moment_when_given_back.Split('/')[1]) == int.Parse(moment_to.Split('/')[1]))
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