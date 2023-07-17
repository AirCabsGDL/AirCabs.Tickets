namespace AirCabs.Tickets.Domain.Entities.Addresses;

public record Address
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }
    public ZipCode ZipCode { get; }

    public Address(string street, string city, string state, string country, string zipCode)
    {
        IsNotNull(street, city, state, country);
        IsLenghtValid(street, city, state, country);

        Street = street;
        City = city ?? throw new ArgumentNullException(nameof(city));
        State = state ?? throw new ArgumentNullException(nameof(state));
        Country = country ?? throw new ArgumentNullException(nameof(country));
        ZipCode = new ZipCode(zipCode);
    }

    private static void IsLenghtValid(string street, string city, string state, string country)
    {
        if (street.Length > 100)
            throw new ArgumentOutOfRangeException(nameof(street), "Street cannot be longer than 100 characters");
        if (city.Length > 100)
            throw new ArgumentOutOfRangeException(nameof(city), "City cannot be longer than 100 characters");
        if (state.Length > 100)
            throw new ArgumentOutOfRangeException(nameof(state), "State cannot be longer than 100 characters");
        if (country.Length > 100)
            throw new ArgumentOutOfRangeException(nameof(country), "Country cannot be longer than 100 characters");
    }

    private static void IsNotNull(string street, string city, string state, string country)
    {
        if (string.IsNullOrEmpty(street))
            throw new ArgumentNullException(nameof(street), "Street cannot be null or empty");
        if (string.IsNullOrEmpty(city))
            throw new ArgumentNullException(nameof(city), "City cannot be null or empty");
        if (string.IsNullOrEmpty(state))
            throw new ArgumentNullException(nameof(state), "State cannot be null or empty");
        if (string.IsNullOrEmpty(country))
            throw new ArgumentNullException(nameof(country), "State cannot be null or empty");
    }
}