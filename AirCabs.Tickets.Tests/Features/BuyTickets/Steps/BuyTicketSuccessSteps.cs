namespace AirCabs.Tickets.Tests.Features.BuyTickets.Steps;

[Binding]
public class BuyTicketSuccessSteps
{
    [Given(@"the anonymous rider provides a destination address")]
    public void GivenTheAnonymousRiderProvidesADestinationAddress()
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"destination address is in Zone A has a price of (.*)")]
    public void GivenDestinationAddressIsInZoneAHasAPriceOf(decimal p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"the destination address is outside the coverage zones")]
    public void GivenTheDestinationAddressIsOutsideTheCoverageZones()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"a new ticket to the destination is created")]
    public void ThenANewTicketToTheDestinationIsCreated()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the anonymous rider is added to the waiting queue")]
    public void ThenTheAnonymousRiderIsAddedToTheWaitingQueue()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"transaction was sent to finance system")]
    public void ThenTransactionWasSentToFinanceSystem()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"success data was sent to the analytic system")]
    public void ThenSuccessDataWasSentToTheAnalyticSystem()
    {
        ScenarioContext.StepIsPending();
    }
}