Feature:Login Function 
	
	Background: Login page
		Given Users go to the Log in page

		
	Scenario Outline: Verify that user should be able to log in with Valid Credentials
		When Type "<username>" and "<password>" in the input boxes
		And Click Login button
		Then Verify that user should be able to see url that contains "inventory.html"


		Examples: Valid credentials
		  | username                | password     |
		  | standard_user           | secret_sauce |
		  | problem_user            | secret_sauce |
		  | performance_glitch_user | secret_sauce |
    

Scenario: Verify that user should not be able to login with below credential
	When Type "locked_out_user" as username and "secret_sauce" as password
	And Click Login button
	Then Verify that user should be able to see error message "Epic sadface: Sorry, this user has been locked out."
	
    
	Scenario Outline: Verify that user should NOT be able to log in with Invalid Credentials
		When Type "<username>" and "<password>" in the input boxes
		And Click Login button
		Then Verify that user should be able to see error message "Epic sadface: Username and password do not match any user in this service"

	
		Examples: Valid username, Invalid password
		  | username      | password     |
		  | standard_user | Secret_Sauce |
		  | standard_user | password     |
		  | standard_user | 09*-^'!é     |

	
		Examples: Invalid username, Valid password
		  | username                  | password     |
		  | Standard_user             | secret_sauce |
		  | lockedoutuser             | secret_sauce |
		  | problem_User              | secret_sauce |
		  | performance_glitch_user12 | secret_sauce |

	
		Examples: Invalid username, Invalid password
		  | username              | password              |
		  | standard              | ___3___               |
		  | problem               | 11!!aaQ@%/()=?*_-é^#~ |
		  | 11!!aaQ@%/()=?*_-é^#~ | (UserUser)            |
    

	Scenario Outline: Verify that user should NOT be able to log in with Invalid Credentials (White Space)
		When Type "<username>" and "<password>" in the input boxes
		And Click Login button
		Then Verify that user should be able to see error message "<message>"

	
		Examples: Valid username, Invalid password
		  | username      | password | message                            |
		  | standard_user |          | Epic sadface: Password is required |
		  |               | password | Epic sadface: Username is required |
		  |               |          | Epic sadface: Username is required |
    
    
	Scenario: Verify that entered password should be able to turn into bullet sign
		Then verify that user should be able see entered password as bullet signs
		
		
		# livingdoc feature-folder /Users/omerdemir/RiderProjects/SpecFlow/SwagLabs/Features -o /Users/omerdemir/RiderProjects/SpecFlow/SwagLabs/TestReport
		# livingdoc test-assembly /Users/omerdemir/RiderProjects/DirectLineSwagLabs/DirectLineSwagLabs/bin/Debug/net6.0/DirectLineSwagLabs.dll -t /Users/omerdemir/RiderProjects/DirectLineSwagLabs/DirectLineSwagLabs/bin/Debug/net6.0/TestExecution.json --output /Users/omerdemir/RiderProjects/DirectLineSwagLabs/DirectLineSwagLabs/TestReport
		# livingdoc feature-folder /Users/omerdemir/RiderProjects/SpecFlow/SwagLabs --output /Users/omerdemir/RiderProjects/SpecFlow/SwagLabs/TestReport

