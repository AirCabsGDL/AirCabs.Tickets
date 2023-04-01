using AirCabs.Tickets.BehaviorTests.Contexts;
using AirCabs.Tickets.BehaviorTests.Features.BuyTickets.Contexts;
using AirCabs.Tickets.Domain.Entities;
using AirCabs.Tickets.Domain.Entities.Riders;
using AirCabs.Tickets.Domain.UsesCases.BuyTickets;
using Xunit;

namespace AirCabs.Tickets.BehaviorTests.Features.BuyTickets.Steps;

[Binding]
public class BuyTicketCashSteps
{
    private readonly BuyTicketContext _buyTicketContext;
    private readonly AnonymousRiderContext _anonymousRiderContext;

    public BuyTicketCashSteps(BuyTicketContext buyTicketContext, AnonymousRiderContext anonymousRiderContext)
    {
        _buyTicketContext = buyTicketContext;
        _anonymousRiderContext = anonymousRiderContext;
    }
    
    [When(@"the anonymous rider pays (.*) in cash")]
    public void WhenTheAnonymousRiderPaysInCash(decimal payAmount)
    {
        var zoneQueries = _buyTicketContext.CreateMockForZoneQueries();

        var sut = new BuyTicketCashUseCase(zoneQueries, _buyTicketContext.TicketCommandsMock,
            _buyTicketContext.RiderWaitingQueueMock);

        var totalPayed = new Cash(payAmount);
        var riderName = new RiderName(_anonymousRiderContext.FirstName, _anonymousRiderContext.LastName);
        var buyTicketCashRequest = new BuyTicketCashRequest(riderName, _buyTicketContext.Destination,totalPayed);
        
        var result = sut.Execute(buyTicketCashRequest);
        
        _buyTicketContext.TicketCashResult = result;
        _buyTicketContext.TotalPayed = totalPayed;
    }

    [Then(@"the rider get a change of (.*)")]
    public void ThenTheRiderGetAChangeOf(decimal change)
    {
        Assert.Equal(new Cash(change), _buyTicketContext.TicketCashResult.Change);
    }

    [Given(@"destination address is outside the covered area, the closest alternative with a price of (.*) will be chosen")]
    public void GivenDestinationAddressIsOutsideTheCoveredAreaTheClosestAlternativeWithAPriceOfWillBeChosen(decimal p0)
    {
        ScenarioContext.StepIsPending();
    }
}