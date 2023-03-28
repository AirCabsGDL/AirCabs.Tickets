namespace AirCabs.Tickets.Domain.Entities.Riders;

public record RiderName
{
    public string FirstName { get; }
    public string LastName { get; }

    public RiderName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentNullException(nameof(firstName), "First name is required");
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentNullException(nameof(lastName), "Last name is required");
        if (firstName.Length > 50) 
            throw new ArgumentOutOfRangeException(nameof(firstName), "First name is too long");
        if (lastName.Length > 50) 
            throw new ArgumentOutOfRangeException(nameof(lastName), "Last name is too long");

        FirstName = firstName;
        LastName = lastName;
    }
}