Feature: AutomationPractice

A short summary of the feature
Given User is on demoqa.com
@SmokeTest
Scenario: Verify user is able to navigate to auto pracice home page, Select blouse,proceed to checkout and validate the summary
	Given User is on automationpractice.com
	When User scroll down to hover mouse on Blouse
	And User click 'add_to_cart' to add item to basket
	And User click proceed to checkout button
	Then User should see 'SHOPPING-CART SUMMARY' displayed on the page
	And User should also see item selected 'Blouse' under discription
	And User should validate that Qty is equal to 1
	And Following are the price breakdown of the selected item
		| Totalproducts | Totalshipping | Total  | Tax   |
		| $27.00        | $2.00         | $29.00 | $0.00 |