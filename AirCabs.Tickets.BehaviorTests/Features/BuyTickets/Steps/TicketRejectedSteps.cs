namespace AirCabs.Tickets.BehaviorTests.Features.BuyTickets.Steps;

[Binding]
public class TicketRejectedSteps
{
    [When(@"the anonymous rider reject the offer")]
    public void WhenTheAnonymousRiderRejectTheOffer()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the ticket is closed as reject")]
    public void ThenTheTicketIsClosedAsReject()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"rejected data was sent to the analytic system")]
    public void ThenRejectedDataWasSentToTheAnalyticSystem()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"the anonymous rider attempts to pay (.*) using the digital method")]
    public void WhenTheAnonymousRiderAttemptsToPayUsingTheDigitalMethod(decimal p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the digital payment is rejected")]
    public void ThenTheDigitalPaymentIsRejected()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the system rise an payment rejected error")]
    public void ThenTheSystemRiseAnPaymentRejectedError()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the system informs through an error that the address is outside the coverage zones")]
    public void ThenTheSystemInformsThroughAnErrorThatTheAddressIsOutsideTheCoverageZones()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"address outside coverage area was sent to the analytics system")]
    public void ThenAddressOutsideCoverageAreaWasSentToTheAnalyticsSystem()
    {
        ScenarioContext.StepIsPending();
    }
}