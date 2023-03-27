namespace AirCabs.Tickets.BehaviorTests.Features.BuyTickets.Steps;

[Binding]
public class BuyTicketCreditCartSteps
{
    [Given(@"using credit card as payment method")]
    public void GivenUsingCreditCardAsPaymentMethod()
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"anonymous rider has enough funds")]
    public void GivenAnonymousRiderHasEnoughFunds()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"the anonymous rider pays (.*) using a credit card")]
    public void WhenTheAnonymousRiderPaysUsingACreditCard(decimal p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"anonymous rider does not have enough funds")]
    public void GivenAnonymousRiderDoesNotHaveEnoughFunds()
    {
        ScenarioContext.StepIsPending();
    }
}