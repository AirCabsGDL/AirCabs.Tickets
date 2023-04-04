namespace AirCabs.Tickets.Domain.Entities.Addresses;

public record State
{
    public State(string value)
    {
        if(value.Length > 100)
            throw new ArgumentOutOfRangeException(nameof(value), "State cannot be longer than 100 characters");

        
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Value { get; }
}