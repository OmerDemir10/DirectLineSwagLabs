Feature: HomePageAction
	User can add or remove items to chart list, inspect items or change items order

	Background: Home page
		Given Users go to the Login page
		When Users login with valid credentials
	

Scenario: Verify that user should be able to see four options under hamburger menu
	When click hamburger menu that is top left on the homepage
	Then user should be able to see four options
	Then user should be able to close the menu
	
	
Scenario: Verify that user should be able to change the items order
	When click product sort container button and change the items order from z to a 
	Then verify that items list is changed z to a
	And click product sort container button and change the items order from low price to high
	Then verify that items list is changed low to high
	
	
Scenario: Verify that user should be able to add items to chart
	When click item to add chart
	Then verify that shopping cart badge increase one
	Then verify that add to cart button replace remove button
	And click shopping cart icon
	Then verify that correct item is added shopping cart
	Then verify that user should be able to go back homepage
	
