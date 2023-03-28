using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Exceptions;
using AirCabs.Tickets.Domain.UsesCases.BuyTickets;
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
        var exception = Assert.Throws<UncoveredZoneException>(() => sut.Execute(address));
        
        // Assert
        Assert.Equal(address.GetFullAddress(), exception.FullAddress);
    }
}