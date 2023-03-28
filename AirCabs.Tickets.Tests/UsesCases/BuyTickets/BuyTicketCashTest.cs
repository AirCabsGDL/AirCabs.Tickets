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
    public void Try_to_buy_a_ticket_in_a_address_without_coverage()
    {
        // Arrange
        const string riderTest = "Rider Test";
        Address address = new("Fake Street", "City", "Fake State", "Country", "23452");
        var zoneQueriesMock = new Mock<IZoneQueries>();
        zoneQueriesMock.Setup(x => x.GetZoneByAddress(address)).Returns(null as Zone);

        var ticketsCommandsMock = new Mock<ITicketsCommands>();
        IBuyTicketCashUseCase sut = new BuyTicketCashCashUseCase(zoneQueriesMock.Object, ticketsCommandsMock.Object);
        
        var buyTicketCashRequest = new BuyTicketCashRequest(address, 500.00m);

        // Act/Assert
        var exception = Assert.Throws<UncoveredZoneException>(() => sut.Execute(buyTicketCashRequest));

        // Assert
        Assert.Equal(address.GetFullAddress(), exception.FullAddress);
    }
    
    [Fact]
    public void Try_to_buy_a_ticket_with_insufficient_amount()
    {
        // Arrange
        const decimal cashAmount = 400.00m;
        const decimal ticketPrice = 450.00m;

        Address address = new("Fake Street", "City", "Fake State", "Country", "23452");
        Zone zone = new("Zone A", ticketPrice);

        var zoneQueriesMock = new Mock<IZoneQueries>();
        zoneQueriesMock.Setup(x => x.GetZoneByAddress(address)).Returns(zone);

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

        var zoneQueriesMock = new Mock<IZoneQueries>();
        var ticketsCommandsMock = new TicketsCommandsMock();
        zoneQueriesMock.Setup(x => x.GetZoneByAddress(address)).Returns(zone);

        IBuyTicketCashUseCase sut = new BuyTicketCashCashUseCase(zoneQueriesMock.Object, ticketsCommandsMock);
        var buyTicketCashRequest = new BuyTicketCashRequest(address, cashAmount);
        
        // Act
        var ticket = sut.Execute(buyTicketCashRequest);

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
}