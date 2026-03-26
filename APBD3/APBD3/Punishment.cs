using System.Globalization;
using System.Runtime.InteropServices.JavaScript;

namespace APBD3;

public class Punishment
{
    
    public class Debt
    {
        private long borrower;
        private long device_identifier;
        private float debt_amount;

        public long Borrower
        {
            get { return borrower; }
        }
        public long DeviceIdentifier
        {
            get { return device_identifier; }
        }
        public float Debt_Amount
        {
            get { return debt_amount; }
        }
        

        public Debt(long identifier,long device_identifier,float amount)
        {
            this.borrower = identifier;
            this.device_identifier = device_identifier;
            this.debt_amount = amount;
        }

    }
    
    
    
    
    private Borrowing borrowing;
    public Punishment(Borrowing borrowing)
    {
        this.borrowing = borrowing;
    }
    
    private bool need_a_debt;
    public bool Need_a_debt
    {
        get { return this.need_a_debt; }
        set { this.need_a_debt = value; }

    }
    
    
    
    
    
    public void punish()
    {
        if (!borrowing.On_time)
        {
            need_a_debt = true;
        }
    }
    
    public int days_of_delay(string moment_from, string moment_to)
    {
        
        DateTime fromdate = DateTime.ParseExact(moment_from, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime todate = DateTime.ParseExact(moment_to, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        
        
        return  (todate - fromdate).Days;
    }
    
    public static bool check_border_for_a_role(long borrower,List<Borrowing> borrowings)
    {
        bool answer = true;
        int counter = 0;
        foreach (var borrowing in borrowings)
        {
            if (borrowing.Id_of_borrower == borrower)
            {
                counter++;
            }
        }

        if (UserService.get_role(borrower) == "Student")
        {
            answer = counter <= 2;
        }else if (UserService.get_role(borrower) == "Employee")
        {
            answer = counter <= 5;
        }

        return answer;

    }
    


}