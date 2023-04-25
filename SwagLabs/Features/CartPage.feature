Feature: CartPage
	User should be able to complete order process

	Background: Home page
		Given Users go to the Login page
		When Users login with valid credentials

Scenario: Verify that user should be able to continue shopping
	When click item to add chart
	And click shopping cart icon
	And click continue shopping button
	And add another item to cart
	Then verify that all items are added to cart
	
	
Scenario: Verify that user should be able to remove items from cart
	When click item to add chart
	And add another item to cart
	And remove all items from cart
	Then verify that all items are removed successfully	
	
	
Scenario: Verify that user should be able to go back from checkout page		
	When click item to add chart
	And add another item to cart
	And click shopping cart icon
	And click checkout button
	And click cancel button
	Then verify that url contains "cart.html"
	

Scenario Outline:Verify that user should not be able to continue without filling mandatory fields
	When click item to add chart
	And click shopping cart icon
	And click checkout button
	Then type first name "<firstname>" last name "<lastname>" and zip code "<zipcode>"
	And click continue button
	Then verify that error message is displayed error message 
	
	Examples: First name, last name and zip code
	
	| firstname | lastname | zipcode |
	|  john     |  doe     |         |
	|           |  doe     |   123   |
	|  john     |          |   123   |
	|  john     |          |      	 |
	|           |          |   123   |
 

Scenario: Verify that zip code must contains number
	When click item to add chart
	And click shopping cart icon
	And click checkout button
	And type first name "John" and last name "Doe"
	And type zip code "asdfg"
	Then verify that user should not be able to continue
	
	
Scenario Outline:Verify that user should not be able to continue filling special characters mandatory fields
	When click item to add chart
	And click shopping cart icon
	And click checkout button
	And type first name "<firstname>" last name "<lastname>" and zip code "<zipcode>"
	Then verify that user should not be able to move forward
	
	Examples: First name, last name and zip code
	
	| firstname | lastname | zipcode |
	| !'^+      | %&/      | ()=?    |
	| 1234      | 5678     | *-ÇÖ    |
 

Scenario: Verify that reset app state button working properly
	When click item to add chart
	When click hamburger menu that is top left on the homepage
	And click reset app state button
	And click close button
	Then verify that shopping cart badge number disappear
	
	
Scenario: Verify that reset app state button working properly-1
	When click item to add chart
	When click hamburger menu that is top left on the homepage
	And click reset app state button
	Then verify that remove button replace add to cart button

	
Scenario: Verify that reset app state button working properly-2
	When click item to add chart
	And click shopping cart icon
	When click hamburger menu that is top left on the homepage
	And click reset app state button
	And click close button
	And click continue shopping button
	Then verify that remove button replace add to cart button successfully
	Then verify that shopping cart badge number disappear
	
	
Scenario: Verify that total price of items are correct
	When click item to add chart
	And add another item to cart
	And click shopping cart icon
	And click checkout button
	And type first name "John" last name "Doe" and zip code "123"
	Then click continue button
	Then verify that total price is correct
	And click finish button
	Then verify that order is completed
	And click back home button
	Then verify that user should be able to access home page