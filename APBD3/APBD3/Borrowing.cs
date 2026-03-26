namespace APBD3;

public class Borrowing
{

    private long id;
    public long Id
    {
        get { return this.id; }
    }

    private string status;
    public string Status
    {
        get { return this.status; }
        set { this.status = value; }
    }

    
    private long id_of_borrower;
    public long Id_of_borrower
    {
        get { return this.id_of_borrower; }
        set { this.id_of_borrower = value; }

    }


    private long id_of_device;
    public long Id_of_device{
        get { return this.id_of_borrower; }
        set { this.id_of_borrower = value; }
    }


    private string moment_from;
    public string Moment_from{
        get { return this.moment_from; }
        set { this.moment_from = value; }
    }

    
    private string moment_to;
    public string Moment_to
    {
        get { return this.moment_to; }
        set { this.moment_to = value; }
    }

    
    private string moment_when_given_back;
    public string Moment_when_given_back{
        get
        {
            return this.moment_when_given_back;
        }
        set
        {
            this.moment_when_given_back = value;
            this.is_given_back = true;
        }
    }

    public bool on_time
    {
        get { return this.on_time; }
        set { this.on_time = value; }
    }

    
    private bool is_given_back;
    public bool Is_given_back
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

    

    public Borrowing(long id,long borrower, long device,string moment_from,string status)
    {
        this.id = id;
        this.id_of_borrower = borrower;
        this.id_of_device = device;
        this.moment_from = moment_from;
        this.moment_to = moment_from.Split('/')[0].Trim()
                         +string.Join('/', int.Parse(moment_from.Split('/')[1].Trim())+1,'/')
                         +moment_from.Split('/')[2].Trim();
        this.status = status;

    }
    public string toString()
    {
        return "Borrowing: " + this.id + ", Status: " + this.status+"\nBorrower: "+this.id_of_borrower+"\nBorrowed device: "+this.Id_of_device;
    }


}