namespace AirCabs.Tickets.Domain.Entities.Addresses;

public record City
{
    public City(string Value)
    {
        if(Value.Length > 100)
            throw new ArgumentOutOfRangeException(nameof(Value), "City cannot be longer than 100 characters");
        
        this.Value = Value ?? throw new ArgumentNullException(nameof(Value));
    }

    public string Value { get; init; }

    public void Deconstruct(out string Value)
    {
        Value = this.Value;
    }
}