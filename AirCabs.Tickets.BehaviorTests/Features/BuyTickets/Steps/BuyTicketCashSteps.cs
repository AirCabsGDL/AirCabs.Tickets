namespace AirCabs.Tickets.BehaviorTests.Features.BuyTickets.Steps;

[Binding]
public class BuyTicketCashSteps
{
    [When(@"the anonymous rider pays (.*) in cash")]
    public void WhenTheAnonymousRiderPaysInCash(decimal p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the rider get a change of (.*)")]
    public void ThenTheRiderGetAChangeOf(decimal p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"destination address is outside the covered area, the closest alternative with a price of (.*) will be chosen")]
    public void GivenDestinationAddressIsOutsideTheCoveredAreaTheClosestAlternativeWithAPriceOfWillBeChosen(decimal p0)
    {
        ScenarioContext.StepIsPending();
    }
}