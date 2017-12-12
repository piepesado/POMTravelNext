Feature: Login
	As a TOS user,
	I want to Logon to TravelNxt playform. 

@login
Scenario: Login as user
	Given that I navigate to TravelNext application
	And I enter dnan@travelleaders.com as the username
	And I enter the password
	And I enter 20033 as the CID
	And I click captcha field
	And I wait 10 seconds to input captcha
	When I press Login button
	Then I should land on the Backoffice page

@login
Scenario: Login as user wrong credentials
	Given that I navigate to TravelNext application
	And I enter pepe@travelleaders.com as the username
	And I enter wrong password
	And I enter 16022 as the CID
	And I click capctha field
	And I wait 10 seconds to input captcha
	When I press Login button
	Then I should not able to land on the Backoffice page
	And a warning message is displayed on screen
