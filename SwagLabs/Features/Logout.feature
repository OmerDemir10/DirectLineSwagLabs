Feature: Logout Function

	Background: Home page
		Given Users go to the Login page
		When Users login with valid credentials

		
	# Logout button scenario
	Scenario: Verify that users should be able log out and are successfully redirected to login page
		When click hamburger menu that is top left on the homepage
		And click Logout button
		Then verify that user should be able to log out

		
	# Open two tabs with same credentials
	Scenario: Verify that users should be able log out even if two account is opened
		When open new tab and login with same credentials
		When click hamburger menu that is top left on the homepage
		And click Logout button
		Then verify that user should NOT be able to do anything in the another open homepage
		
		
	# Close single open tab	
	Scenario: Verify that users log out after closing single open tab
		When close the single tab
		And open new browser and go to login page
		Then verify that user should NOT be able to go back home page
		
		
	# navigate().back() method
	Scenario: Verify that users should NOT be able go back homepage after log out successfully by pressing back button
		When click hamburger menu that is top left on the homepage
		And click Log out button
		And click back button
		Then verify that user should NOT be able to go back home page
		
		
	# Command + ArrowLeft shortcut
	Scenario: Verify that users should NOT be able go back homepage after log out successfully with keyboard action
		When click hamburger menu that is top left on the homepage
		And click Log out button
		And press shortcut key to go to previous web page
		Then verify that user should NOT be able to go back home page