namespace AirCabs.Tickets.BehaviorTests.Features.BuyTickets.Steps;

[Binding]
public class BuyTicketCreditCartSteps
{
    [When(@"the anonymous rider pays (.*) with a credit card")]
    public static void WhenTheAnonymousRiderPaysWithACreditCard(decimal p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"anonymous rider does not have enough funds")]
    public static void GivenAnonymousRiderDoesNotHaveEnoughFunds()
    {
        ScenarioContext.StepIsPending();
    }
}