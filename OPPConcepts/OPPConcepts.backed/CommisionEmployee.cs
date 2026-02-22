namespace OPPConcepts.backed;
public class CommisionEmployee : Employee
{
    // Fields
    private float _commisionPercent;
    private decimal _sales;

    // Constructors
    public CommisionEmployee(int id, string firstName, string lastName, bool isActive, Date bornDate, Date hireDate, float  commisionPercent, decimal sales) :
        base(id, firstName, lastName, isActive, bornDate, hireDate)
     {
        _commisionPercent = commisionPercent;
        _sales = sales;
    }

    // Properties
    public float CommisionPercent
    {
        get => _commisionPercent;
        set => _commisionPercent = ValidateCommisionPercent(value);
    }

    public decimal Sales
    {
        get => _sales;
        set => _sales = ValidateSales(value);
    }

    // Methods

    public override decimal GetValueToPay() => (decimal)CommisionPercent * Sales;

    public override string ToString() => base.ToString() + $"\n\t" +
        $"Commision Percent: {CommisionPercent,20:P2}\n\t" +
        $"Sales............: {Sales,20:C2}";

    private float ValidateCommisionPercent(float commisionPercent)
    {
        if (commisionPercent < 0 || commisionPercent > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(commisionPercent), "Commision percent must be between 0 and 1.");
        }
        return commisionPercent;
      
    }

    private decimal ValidateSales(decimal sales)
    {
        if (sales < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(sales), "Sales must be greater than or equal to 0.");
        }
        return sales;
    }
}





