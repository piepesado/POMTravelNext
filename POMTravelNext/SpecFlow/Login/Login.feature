Feature: Login
	As a TOS user,
	I want to Logon to TravelNxt playform. 

@login
Scenario: Login as user
	Given that I navigate to TravelNext application
	And I enter dnan@travelleaders.com as the username
	And I enter the password
	And I enter 20033 as the CID
	And I wait 10 seconds to input captcha
	When I press Login button
	Then I should land on the Backoffice page
