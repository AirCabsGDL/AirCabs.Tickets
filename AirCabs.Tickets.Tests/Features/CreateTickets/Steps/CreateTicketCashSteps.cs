namespace AirCabs.Tickets.Tests.Features.CreateTickets.Steps;

[Binding]
public class CreateTicketCashSteps
{
    [When(@"the anonymous rider pays (.*) in cash")]
    public void WhenTheAnonymousRiderPaysInCash(decimal p0)
    {
        ScenarioContext.StepIsPending();
    }
}