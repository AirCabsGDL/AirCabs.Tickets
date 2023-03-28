namespace AirCabs.Tickets.Domain.Entities.Addresses;

public record Street
{
    public Street(string value)
    {
        if(value.Length > 100)
            throw new ArgumentOutOfRangeException(nameof(value), "Street cannot be longer than 100 characters");
        
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Value { get; }
}