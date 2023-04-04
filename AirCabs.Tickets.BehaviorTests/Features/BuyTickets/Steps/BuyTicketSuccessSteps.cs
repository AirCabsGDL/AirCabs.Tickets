using AirCabs.Tickets.BehaviorTests.Contexts;
using AirCabs.Tickets.BehaviorTests.Features.BuyTickets.Contexts;
using AirCabs.Tickets.Domain.Entities;
using AirCabs.Tickets.Domain.Entities.Addresses;
using Xunit;

namespace AirCabs.Tickets.BehaviorTests.Features.BuyTickets.Steps;

[Binding]
public class BuyTicketSuccessSteps
{
    private readonly BuyTicketContext _buyTicketContext;
    private readonly AnonymousRiderContext _anonymousRider;

    public BuyTicketSuccessSteps(BuyTicketContext buyTicketContext, AnonymousRiderContext anonymousRider)
    {
        _buyTicketContext = buyTicketContext;
        _anonymousRider = anonymousRider;
    }

    [Given(@"the anonymous rider provides a destination address")]
    public void GivenTheAnonymousRiderProvidesADestinationAddress()
    {
        _buyTicketContext.Destination = new Address("123 Main St", "New York", "NY", "US", "10001");
    }

    [Given(@"destination address is in Zone A has a price of (.*)")]
    public void GivenDestinationAddressIsInZoneAHasAPriceOf(decimal zonePrice)
    {
        _buyTicketContext.DestinationZone = new Zone("Zone A", new Money(zonePrice));
    }

    [Given(@"the destination address is outside the coverage zones")]
    public void GivenTheDestinationAddressIsOutsideTheCoverageZones()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"a new ticket payment with cash is created")]
    public void ThenANewTicketPaymentWithCashIsCreated()
    {
        Assert.NotNull(_buyTicketContext.TicketCashResult);
        Assert.Equal(_buyTicketContext.Destination, _buyTicketContext.TicketCashResult.Summary.Destination);
        Assert.Equal(_buyTicketContext.DestinationZone.Price, _buyTicketContext.TicketCashResult.Summary.Cost);
        Assert.Equal(_buyTicketContext.TotalPayed, _buyTicketContext.TicketCashResult.Summary.TotalPayed);
        Assert.NotNull(_buyTicketContext.TicketCashResult.Summary.Rider);
        Assert.Equal(_anonymousRider.FirstName, _buyTicketContext.TicketCashResult.Summary.Rider!.Name.FirstName);
        Assert.Equal(_anonymousRider.LastName, _buyTicketContext.TicketCashResult.Summary.Rider!.Name.LastName);
    }

    [Then(@"the anonymous rider is added to the waiting queue")]
    public void ThenTheAnonymousRiderIsAddedToTheWaitingQueue()
    {
        Assert.Single(_buyTicketContext.RiderWaitingQueueMock.Tickets);
        Assert.Equal(_buyTicketContext.TicketCashResult, _buyTicketContext.RiderWaitingQueueMock.Tickets[0]);
    }
}