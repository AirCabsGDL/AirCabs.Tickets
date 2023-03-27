namespace AirCabs.Tickets.Tests.Features.BuyTickets.Steps;

[Binding]
public class BuyTicketCashSteps
{
    [When(@"the anonymous rider pays (.*) in cash")]
    public void WhenTheAnonymousRiderPaysInCash(decimal p0)
    {
        ScenarioContext.StepIsPending();
    }
}