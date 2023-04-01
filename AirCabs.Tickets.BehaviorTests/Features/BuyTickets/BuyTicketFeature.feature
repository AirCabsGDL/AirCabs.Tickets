Feature: Buy a Ticket
An anonymous rider is allowed to buy a cab ticket at the airport stand.

Scenarios:

    Scenario: An anonymous rider wants to buy a cab ticket at the airport stand to travel to their destination paying with cash successfully.
        Given an anonymous rider who wants to buy a ticket
        And the anonymous rider provides a destination address
        * destination address is in Zone A has a price of 350.00
        When the anonymous rider pays 400.00 in cash
        Then a new ticket to the destination is created
        And the rider get a change of 50.00
        And the anonymous rider is added to the waiting queue
        
    Scenario: An anonymous rider wants to buy a cab ticket at the airport stand to travel to their destination paying with a credit card successfully.
        Given an anonymous rider who wants to buy a ticket
        And the anonymous rider provides a destination address
        * destination address is in Zone A has a price of 350.00
        * using credit card as payment method
        * anonymous rider has enough funds
        When the anonymous rider pays 350.00 with a credit card
        Then a new ticket to the destination is created
        And the anonymous rider is added to the waiting queue

    Scenario: An anonymous rider wants to buy a cab ticket at the airport stand to travel to their destination but rejects the offer.
        Given an anonymous rider who wants to buy a ticket
        And the anonymous rider provides a destination address
        * destination address is in Zone A has a price of 350.00
        When the anonymous rider reject the offer because is to expensive
        Then the ticket is closed as reject with the next reason is to expensive
        
    Scenario: An anonymous rider wants to buy a cab ticket at the airport stand to travel to their destination, but the credit card is rejected.
        Given an anonymous rider who wants to buy a ticket
        And the anonymous rider provides a destination address
        * destination address is in Zone A has a price of 350.00
        * using credit card as payment method
        * anonymous rider does not have enough funds
        When the anonymous rider attempts to buy a ticket with a credit card
        Then the digital payment is rejected
        And the system rise an payment rejected error
        
    Scenario: An anonymous rider wants to buy a cab ticket at the airport stand with cash, to travel to an not covered area.
        Given an anonymous rider who wants to buy a ticket
        And the anonymous rider provides a destination address
        * destination address is outside the covered area, the closest alternative with a price of 450.00 will be chosen
        When the anonymous rider pays 500.00 in cash
        Then a new ticket to the destination is created
        And the rider get a change of 50.00
        And the anonymous rider is added to the waiting queue
        And a notification event about ride to a not covered area was raised