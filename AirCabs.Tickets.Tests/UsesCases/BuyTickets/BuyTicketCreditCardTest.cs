using AirCabs.Tickets.Domain.Entities;
using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Tickets;
using AirCabs.Tickets.Domain.Exceptions;
using AirCabs.Tickets.Domain.Ports;
using AirCabs.Tickets.Domain.UsesCases.BuyTickets;
using AirCabs.Tickets.Domain.UsesCases.BuyTickets.BuyTicketsCreditCard;
using AirCabs.Tickets.Tests.Mocks;
using Moq;
using Xunit;

namespace AirCabs.Tickets.Tests.UsesCases.BuyTickets;

public class BuyTicketCreditCardTest
{
    [Fact]
    public void Try_to_buy_a_ticket_but_the_rider_does_not_have_enough_funds()
    {
        // Arrange
        var paymentCommandsMock = new Mock<IPaymentCommands>();
        paymentCommandsMock.Setup(x => x.PayWithCreditCard(It.IsAny<Money>()))
            .Throws(new PaymentDeclineException("Payment Declined"));
        
        var zone = new Zone("Zone A", Money.Zero());
        var zoneQueriesMock = CreateZoneQueriesMock(zone);
        var ticketCommandsMock = new Mock<ITicketCommands>();
        var riderWaitingQueue = new Mock<IRiderWaitingQueue>();

        var creditCardSettings =
            new CreditCardPorts(zoneQueriesMock.Object, ticketCommandsMock.Object, riderWaitingQueue.Object);
        
        IBuyTicketCreditCard sut = new BuyTicketCreditCard(creditCardSettings, paymentCommandsMock.Object);
        var destination = new Address("Fake Street", "City", "Fake State", "Country", "23452");
        var buyTicketCreditCardRequest = new BuyTicketCreditCardRequest(null, destination);

        // Act/Assert
        Assert.Throws<PaymentDeclineException>(() => sut.Execute(buyTicketCreditCardRequest));
    }
    
    [Fact]
    public void Anonymous_rider_buy_a_ticket_with_credit_card_successfully()
    {
        // Arrange
        var ticketCost = new Money(400);
        var address = new Address("Fake Street", "City", "Fake State", "Country", "23452");
        var paymentCommandsMock = new Mock<IPaymentCommands>();

        var zone = new Zone("Zone A", ticketCost);
        var zoneQueriesMock = CreateZoneQueriesMock(zone);

        var ticketCommandsMock = new TicketCommandsMock();
        var riderWaitingQueue = new Mock<IRiderWaitingQueue>();

        var creditCardSettings = new CreditCardPorts(zoneQueriesMock.Object, ticketCommandsMock, riderWaitingQueue.Object);
        IBuyTicketCreditCard sut = new BuyTicketCreditCard(creditCardSettings, paymentCommandsMock.Object);
        var buyTicketCreditCardRequest = new BuyTicketCreditCardRequest(null, address);

        // Act
        var ticket = sut.Execute(buyTicketCreditCardRequest);

        // Assert
        Assert.NotNull(ticket);
        Assert.IsType<TicketCreditCard>(ticket);
        Assert.NotEmpty(ticket.Id.Value);
        Assert.Equal(ticket.Summary.Destination, address);
        Assert.Equal(ticket.Summary.TotalPayed, ticketCost);
        Assert.Equal(ticket.Summary.Cost, ticketCost);
        Assert.Null(ticket.Summary.Rider);
        Assert.Equal(ticket.DestinationZone, zone);
        
    }

    private static Mock<IZoneQueries> CreateZoneQueriesMock(Zone zone)
    {
        var zoneQueriesMock = new Mock<IZoneQueries>();
        zoneQueriesMock.Setup(x => x.GetZoneByAddress(It.IsAny<Address>()))
            .Returns(zone);
        return zoneQueriesMock;
    }
}
