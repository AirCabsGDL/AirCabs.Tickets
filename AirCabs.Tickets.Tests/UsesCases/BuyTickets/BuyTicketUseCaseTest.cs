using System;
using Xunit;

namespace AirCabs.Tickets.Tests.UsesCases.BuyTickets;

public class BuyTicketUseCaseTest
{
    [Fact]
    public void Try_to_buy_a_ticket_in_a_address_without_coverage()
    {
        // Arrange
        Address address = new ("Fake Street", "City", "Fake State", "Country", "23452");
        IBuyTicketUseCase sut = new BuyTicketUseCase();

        // Act/Assert
        Assert.Throws<UncoveredZoneException>(() => sut.Execute(address));
    }
}

public class UncoveredZoneException : Exception
{
    public string FullAddress { get; }

    public UncoveredZoneException(string address, string? message = null) : base(message)
    {
        FullAddress = address;
    }
}

public class BuyTicketUseCase : IBuyTicketUseCase
{
    public void Execute(Address destination)
    {
        throw new UncoveredZoneException("Address");
    }
}

public record Address
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }
    public string ZipCode { get; }

    public Address(string street, string city, string state, string country, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(state) ||
            string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(zipCode))
        {
            throw new ArgumentException("All address fields must be provided.");
        }

        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }

    public string GetFullAddress()
    {
        return $"{Street}, {City}, {State}, {Country}, {ZipCode}";
    }
}

public interface IBuyTicketUseCase
{
    public void Execute(Address destination);
}
