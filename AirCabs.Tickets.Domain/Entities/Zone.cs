namespace AirCabs.Tickets.Domain.Entities;

public class Zone
{
    public Zone(string name, Cash price)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name), "Zone name cannot be null or empty");
        
        Id = new Id();
        Name = name;
        Price = price;
    }
    
    public Id Id { get; }

    public string Name { get; }
    
    public Cash Price { get; }
}