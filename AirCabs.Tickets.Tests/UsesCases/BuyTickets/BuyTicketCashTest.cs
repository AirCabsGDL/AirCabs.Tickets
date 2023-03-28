using AirCabs.Tickets.Domain.Entities;
using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;
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
        var ticketPrice = new Cash(450.00m);
        var riderName = new RiderName("John", "Doe");
        var cashAmount = new Cash(300.00m);

        var address = new Address("Fake Street", "City", "Fake State", "Country", "23452");
        var zone = new Zone("Zone A", ticketPrice);

        var zoneQueriesMock = CreateZoneQueriesMock(address, zone);
        var ticketsCommandsMock = new Mock<ITicketCommands>();
        var riderWaitingQueueMock = new Mock<RiderWaitingQueueMock>();

        IBuyTicketCashUseCase sut = new BuyTicketCashCashUseCase(zoneQueriesMock.Object, ticketsCommandsMock.Object,
            riderWaitingQueueMock.Object);
        var buyTicketCashRequest = new BuyTicketCashRequest(riderName, address, cashAmount);

        // Act/Assert
        var exception = Assert.Throws<InsufficientAmountException>(() => sut.Execute(buyTicketCashRequest));

        // Assert
        Assert.Equal(ticketPrice, exception.Cost);
        Assert.Equal(cashAmount, exception.Paid);
    }

    [Fact]
    public void Buy_a_ticket_successfully()
    {
        // Arrange
        var ticketPrice = new Cash(450.00m);
        var riderName = new RiderName("John", "Doe");
        var cashAmount = new Cash(500.00m);
        var expectedChange = cashAmount.Subtract(ticketPrice);

        var address = new Address("Fake Street", "City", "Fake State", "Country", "23452");
        var zone = new Zone("Zone A", ticketPrice);

        var zoneQueriesMock = CreateZoneQueriesMock(address, zone);
        var ticketsCommandsMock = new TicketCommandsMock();
        var riderWaitingQueueMock = new Mock<RiderWaitingQueueMock>();

        IBuyTicketCashUseCase sut = new BuyTicketCashCashUseCase(zoneQueriesMock.Object, ticketsCommandsMock,
            riderWaitingQueueMock.Object);

        var request = new BuyTicketCashRequest(riderName, address, cashAmount);

        // Act
        var ticket = sut.Execute(request);

        // Assert
        Assert.NotNull(ticket);
        Assert.NotNull(ticket.Id);
        Assert.Equal(address, ticket.Destination);
        Assert.Equal(zone, ticket.DestinationZone);
        Assert.Equal(zone.Price, ticket.Cost);
        Assert.Equal(expectedChange, ticket.Change);
        Assert.Equal(cashAmount, ticket.TotalPayed);
        Assert.NotNull(ticket.Rider);
        Assert.NotNull(ticket.Rider?.Id);
        Assert.Equal(ticket.Rider?.Name, ticket.Rider?.Name);
        Assert.Single(ticketsCommandsMock.Tickets);
        Assert.Equal(ticketsCommandsMock.Tickets[0], ticket);
    }

    [Fact]
    public void Buy_a_ticket_without_rider_name_successfully()
    {
        // Arrange
        var ticketPrice = new Cash(450.0m);
        var cashAmount = new Cash(500.00m);
        var expectedChange = cashAmount.Subtract(ticketPrice);

        var address = new Address("Fake Street", "City", "Fake State", "Country", "23452");
        var zone = new Zone("Zone A", ticketPrice);

        var zoneQueriesMock = CreateZoneQueriesMock(address, zone);
        var ticketsCommandsMock = new TicketCommandsMock();
        var riderWaitingQueueMock = new Mock<RiderWaitingQueueMock>();

        IBuyTicketCashUseCase sut = new BuyTicketCashCashUseCase(zoneQueriesMock.Object, ticketsCommandsMock,
            riderWaitingQueueMock.Object);

        var request = new BuyTicketCashRequest(null, address, cashAmount);

        // Act
        var ticket = sut.Execute(request);

        // Assert
        Assert.NotNull(ticket);
        Assert.NotNull(ticket.Id);
        Assert.Equal(address, ticket.Destination);
        Assert.Equal(zone.Price, ticket.Cost);
        Assert.Equal(expectedChange, ticket.Change);
        Assert.Equal(cashAmount, ticket.TotalPayed);
        Assert.Null(ticket.Rider);
        Assert.Single(ticketsCommandsMock.Tickets);
        Assert.Equal(ticketsCommandsMock.Tickets[0], ticket);
    }

    [Fact]
    public void Buy_a_ticket_an_send_ticket_to_rider_waiting_queue()
    {
        // Arrange
        var ticketPrice = new Cash(450.0m);
        var cashAmount = new Cash(500.00m);
        var address = new Address("Fake Street", "City", "Fake State", "Country", "23452");
        var zone = new Zone("Zone A", ticketPrice);

        var zoneQueriesMock = CreateZoneQueriesMock(address, zone);
        var ticketsCommandsMock = new TicketCommandsMock();
        var riderWaitingQueueMock = new RiderWaitingQueueMock();

        IBuyTicketCashUseCase sut =
            new BuyTicketCashCashUseCase(zoneQueriesMock.Object, ticketsCommandsMock, riderWaitingQueueMock);

        var request = new BuyTicketCashRequest(null, address, cashAmount);

        // Act
        var ticket = sut.Execute(request);

        // Assert
        Assert.NotNull(ticket);
        Assert.Equal(riderWaitingQueueMock.Tickets[0], ticket);
    }

    private static Mock<IZoneQueries> CreateZoneQueriesMock(Address address, Zone zone)
    {
        var zoneQueriesMock = new Mock<IZoneQueries>();
        zoneQueriesMock.Setup(x => x.GetZoneByAddress(address)).Returns(zone);

        return zoneQueriesMock;
    }
}