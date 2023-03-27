namespace AirCabs.Tickets.Tests.Features.CreateTickets.Steps;

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
}