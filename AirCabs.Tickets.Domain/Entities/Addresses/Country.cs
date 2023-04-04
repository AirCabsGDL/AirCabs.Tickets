namespace AirCabs.Tickets.Domain.Entities.Addresses;

public record Country
{
    public Country(string Value)
    {
        if (string.IsNullOrEmpty(Value))
            throw new ArgumentNullException(nameof(Value), "Country name cannot be null or empty");

        this.Value = Value;
    }
    
    public string Value { get; init; }

    public void Deconstruct(out string Value)
    {
        Value = this.Value;
    }
}