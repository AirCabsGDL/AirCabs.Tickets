namespace AirCabs.Tickets.Domain.Entities.Addresses;

public record Address
{
    public Street Street { get; }
    public City City { get; }
    public State State { get; }
    public Country Country { get; }
    public ZipCode ZipCode { get; }

    public Address(string street, string city, string state, string country, string zipCode)
    {
        Street = new Street(street);
        City = new City(city);
        State = new State(state);
        Country = new Country(country);
        ZipCode = new ZipCode(zipCode);
    }
}