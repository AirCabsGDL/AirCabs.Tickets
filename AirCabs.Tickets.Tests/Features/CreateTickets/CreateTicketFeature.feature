Feature: Create Ticket Feature
An anonymous rider is allowed to buy a cab ticket at the airport stand.

Scenarios:

    Scenario: An anonymous rider wants to buy a cab ticket at the airport stand to travel to their destination paying with cash successfully.
        Given an anonymous rider who wants to buy a ticket
        And the anonymous rider provides a destination address
        * destination address is in Zone A has a price of 350.00
        When the anonymous rider pays 350.00 in cash
        Then a new ticket to the destination is created
        And the anonymous rider is added to the waiting queue
        * transaction was sent to finance system
        * success data was sent to the analytic system
        
    Scenario: An anonymous rider wants to buy a cab ticket at the airport stand to travel to their destination paying with a credit card successfully.
        Given an anonymous rider who wants to buy a ticket
        And the anonymous rider provides a destination address
        * destination address is in Zone A has a price of 350.00
        * using credit card as payment method
        * anonymous rider has enough funds
        When the anonymous rider pays 350.00 using a credit card
        Then a new ticket to the destination is created
        And the anonymous rider is added to the waiting queue
        * transaction was sent to finance system
        * success data was sent to the analytic system

    Scenario: An anonymous rider wants to buy a cab ticket at the airport stand to travel to their destination but rejects the offer.
        Given an anonymous rider who wants to buy a ticket
        And the anonymous rider provides a destination address
        * destination address is in Zone A has a price of 350.00
        When the anonymous rider reject the offer
        Then the ticket is closed as reject
        * rejected data was sent to the analytic system

    Scenario: An anonymous rider wants to buy a cab ticket at the airport stand to travel to their destination, but the credit card is rejected.
        Given an anonymous rider who wants to buy a ticket
        And the anonymous rider provides a destination address
        * destination address is in Zone A has a price of 350.00
        * using credit card as payment method
        * anonymous rider does not have enough funds
        When the anonymous rider attempts to pay 350.00 using the digital method
        Then the digital payment is rejected
        And the system rise an payment rejected error