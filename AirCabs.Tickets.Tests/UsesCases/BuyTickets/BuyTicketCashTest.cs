using AirCabs.Tickets.Domain.Entities;
using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Exceptions;
using AirCabs.Tickets.Domain.Ports;
using AirCabs.Tickets.Domain.UsesCases.BuyTickets;
using AirCabs.Tickets.Tests.Mocks;
using Moq;
using Xunit;

namespace AirCabs.Tickets.Tests.UsesCases.BuyTickets;

public class BuyTicketCashTest
{
    [Fact]
    public void Try_to_buy_a_ticket_with_insufficient_amount()
    {
        // Arrange
        const decimal cashAmount = 400.00m;
        const decimal ticketPrice = 450.00m;

        Address address = new("Fake Street", "City", "Fake State", "Country", "23452");
        Zone zone = new("Zone A", ticketPrice);

        var zoneQueriesMock = CreateZoneQueriesMock(address, zone);

        var ticketsCommandsMock = new Mock<ITicketsCommands>();
        
        IBuyTicketCashUseCase sut = new BuyTicketCashCashUseCase(zoneQueriesMock.Object, ticketsCommandsMock.Object);
        var buyTicketCashRequest = new BuyTicketCashRequest(address, cashAmount);

        // Act/Assert
        var exception = Assert.Throws<InsufficientAmountException>(() => sut.Execute(buyTicketCashRequest));

        // Assert
        Assert.Equal(ticketPrice, exception.Cost.Amount);
        Assert.Equal(cashAmount, exception.Paid.Amount);
    }

    [Fact]
    public void Buy_a_ticket_successfully()
    {
        // Arrange
        const decimal cashAmount = 500.00m;
        const decimal ticketPrice = 450.00m;
        Cash expectedChange = new (cashAmount - ticketPrice);

        Address address = new("Fake Street", "City", "Fake State", "Country", "23452");
        Zone zone = new("Zone A", ticketPrice);
        
        var zoneQueriesMock = CreateZoneQueriesMock(address, zone);

        var ticketsCommandsMock = new TicketsCommandsMock();
        IBuyTicketCashUseCase sut = new BuyTicketCashCashUseCase(zoneQueriesMock.Object, ticketsCommandsMock);
        
        var request = new BuyTicketCashRequest(address, cashAmount);
        
        // Act
        var ticket = sut.Execute(request);

        // Assert
        Assert.NotNull(ticket);
        Assert.NotNull(ticket.Id);
        Assert.Equal(address, ticket.Destination);
        Assert.Equal(zone.Price, ticket.Cost);
        Assert.Equal(expectedChange, ticket.Change);
        Assert.Equal(cashAmount, ticket.TotalPayed.Amount);
        Assert.Single(ticketsCommandsMock.Tickets);
        Assert.Equal(ticketsCommandsMock.Tickets[0], ticket);
    }

    private static Mock<IZoneQueries> CreateZoneQueriesMock(Address address, Zone zone)
    {
        var zoneQueriesMock = new Mock<IZoneQueries>();
        zoneQueriesMock.Setup(x => x.GetZoneByAddress(address)).Returns(zone);
        return zoneQueriesMock;
    }
}