namespace AirCabs.Tickets.BehaviorTests.Features.BuyTickets.Steps;

[Binding]
public class BuyTicketCreditCartSteps
{
    [Given(@"using credit card as payment method")]
    public static void GivenUsingCreditCardAsPaymentMethod()
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"anonymous rider has enough funds")]
    public static void GivenAnonymousRiderHasEnoughFunds()
    {
        ScenarioContext.StepIsPending();
    }

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