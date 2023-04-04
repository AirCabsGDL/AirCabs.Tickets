namespace AirCabs.Tickets.BehaviorTests.Contexts;

public class AnonymousRiderContext
{
    public AnonymousRiderContext(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
}