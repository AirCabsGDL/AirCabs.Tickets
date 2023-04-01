using AirCabs.Tickets.Domain.Entities;
using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Exceptions;
using AirCabs.Tickets.Domain.UsesCases.BuyTicketsCreditCard;
using Xunit;

namespace AirCabs.Tickets.Tests.UsesCases.BuyTickets;

public class BuyTicketCreditCardTest
{
    [Fact]
    public void Try_to_buy_a_ticket_but_the_rider_does_not_have_enough_funds()
    {
        // Arrange
        IBuyTicketCreditCard sut = new BuyTicketCreditCard();

        // Act/Assert
        Assert.Throws<PaymentDeclineException>(() => sut.Execute());
    }
    
    [Fact]
    public void Anonymous_rider_buy_a_ticket_with_credit_card_successfully()
    {
        // Arrange
        var ticketCost = new Cash(400);
        var address = new Address("Fake Street", "City", "Fake State", "Country", "23452");

        IBuyTicketCreditCard sut = new BuyTicketCreditCard();

        // Act
        var ticket = sut.Execute();

        // Assert
        Assert.NotNull(ticket);
        Assert.Equal(ticket.Summary.Destination, address);
        Assert.Equal(ticket.Summary.TotalPayed, ticketCost);
        Assert.Equal(ticket.Summary.Cost, ticketCost);
        Assert.Equal(ticket.Change, Cash.Zero());
        Assert.Null(ticket.Summary.Rider);
        Assert.Equal(ticket.DestinationZone, new Zone("Zone A", ticketCost));
        
    }
}
