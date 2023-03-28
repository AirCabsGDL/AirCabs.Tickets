using AirCabs.Tickets.BehaviorTests.Contexts;

namespace AirCabs.Tickets.BehaviorTests.Features.Commons.Riders;

[Binding]
public class GivenRiderSteps
{
    private readonly AnonymousRiderContext _anonymousRider;

    public GivenRiderSteps(AnonymousRiderContext anonymousRider)
    {
        _anonymousRider = anonymousRider;
    }
    
    [Given(@"an anonymous rider who wants to buy a ticket")]
    public void GivenAnAnonymousRiderWhoWantsToBuyATicket()
    {
        _anonymousRider.FirstName = "John";
        _anonymousRider.LastName = "Doe";
    }
}