namespace AirCabs.Tickets.BehaviorTests.Features.BuyTickets.Steps;

[Binding]
public class TicketRejectedSteps
{
    [When(@"the anonymous rider reject the offer because is to expensive")]
    public void WhenTheAnonymousRiderRejectTheOfferBecauseIsToExpensive()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the ticketCash is closed as reject with the next reason is to expensive")]
    public void ThenTheTicketIsClosedAsRejectWithTheNextReasonIsToExpensive()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"rejected data was sent to the analytic system")]
    public void ThenRejectedDataWasSentToTheAnalyticSystem()
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

    [When(@"the anonymous rider attempts to buy a ticketCash with a credit card")]
    public void WhenTheAnonymousRiderAttemptsToBuyATicketWithACreditCard()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"a notification event about ride to a not covered area was raised")]
    public void ThenANotificationEventAboutRideToANotCoveredAreaWasRaised()
    {
        ScenarioContext.StepIsPending();
    }
}