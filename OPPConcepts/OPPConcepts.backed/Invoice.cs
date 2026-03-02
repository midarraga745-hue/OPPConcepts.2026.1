namespace OPPConcepts.backed;


public class Invoice : IPay

{
    // Fields
    private float _quantity;
    private decimal _value;

    // Constructors
    public Invoice(int id, string description, Date date, float quantity, decimal value)
    {
        Id = id;
        Description = description;
        Quantity = quantity;
        Value = value;
        Date = date;
    }

    // Properties
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public Date Date { get; set; }

    public float Quantity
    {
        get => _quantity;
        set => _quantity = ValidateQuantity(value);
    }

    public decimal Value
    {
        get => _value;
        set => _value = ValidateValue(value);
    }


    // Methods
    public override string ToString()
    {
        return $"{Id}\t{Description}\n\t" +
               $"Value............: {Value,20:C2}\n\t" +
               $"Quantity.........: {Quantity,20:N2}\n\t" +
               $"Value to pay.....: {GetValueToPay(),20:C2}";
    }

    public decimal GetValueToPay() => Value * (decimal)Quantity;

    private float ValidateQuantity(float quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than or equal to 0.");
        }
        return quantity;
    }

    private decimal ValidateValue(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be greater than or equal to 0.");
        }
        return value;
    }

    
    
}