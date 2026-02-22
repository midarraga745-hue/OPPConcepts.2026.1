
namespace OPPConcepts.backed;

public class HourlyEmployee : Employee
{
    // Fields
    private decimal _hourlyValue;
    private float _workingHours;

    // Constructors
    public HourlyEmployee(int id, string firstName, string lastName, bool isActive, Date bornDate, Date hireDate, decimal hourlyValue, float workingHours) :
        base(id, firstName, lastName, isActive, bornDate, hireDate)
    {
        HourlyValue = hourlyValue;
        WorkingHours = workingHours;
    }


    // Properties
    public decimal HourlyValue
    {
        get => _hourlyValue;
        set => _hourlyValue = ValidateHourlyValue(value);
    }

    public float WorkingHours
    {
        get => _workingHours;
        set => _workingHours = ValidateWorkingHours(value);
    }

    // Methods
    public override decimal GetValueToPay() => (decimal)WorkingHours * HourlyValue;

    override public string ToString() => base.ToString() + $"\n\t" +
        $"Hourly Value.....: {HourlyValue,20:C2}\n\t" +
        $"Working Hours....: {WorkingHours,20:N2}";

    private decimal ValidateHourlyValue(decimal hourlyValue)
    {
        if (hourlyValue < 10000)
        {
            throw new ArgumentOutOfRangeException(nameof(hourlyValue), "Hourly value must be greater than or equal to $10,000.");
        }
        return hourlyValue;
    }

    private float ValidateWorkingHours(float workingHours)
    {
        if (workingHours < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(workingHours), "Working hours must be greater than or equal to 0.");
        }
        return workingHours;
    }
}
