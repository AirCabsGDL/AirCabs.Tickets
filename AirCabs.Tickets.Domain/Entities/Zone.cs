namespace AirCabs.Tickets.Domain.Entities;

public record Zone
{
    public Zone(string name, Money price)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name), "Zone name cannot be null or empty");
        
        Id = new Id();
        Name = name;
        Price = price;
    }
    
    public Id Id { get; }

    public string Name { get; }
    
    public Money Price { get; }
}