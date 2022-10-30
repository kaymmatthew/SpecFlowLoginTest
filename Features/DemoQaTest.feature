Feature: Demo qa Tech Test

Background: 
	Given User is on demoqa.com

@tag1
Scenario: Create New User and Login
	When User click on 'Book Store Application'
	And User click on login button
	And User click on New User button
	And User enter login user details
		| FirstName | LastName  | UserName     | Password    |
		| AutoFname | AutoLname | AutoUserName | Test_pass1! |
	#And I accept alert
	Then 'Back To Login' button is vissible

@tag1
Scenario: Verify user is able to login and logout successfully
	When User click on 'Book Store Application'
	Then User should be on the Book Store page
	When User click on login button
	Then User is on the Login page
	When User enter user login details
		| UserName      | Password    |
		| AutoUserName1 | Test_pass1! |
	And User click on login button
	Then User should be on the Book Store page
	When User click on LogOut Button
	Then User is on the Login page

@SmokeTest
Scenario: Verify user is able to navigate to Widgets page and also user click Select Menu on Widgets page
	When User click on Widgets button
	Then User is on Widgets page
	And User scroll down to click Select Menu on Widgets page
	Then User is on Select Menu page
	When User click Mr. on Select One dropdown
	Then User should see selected Title Mr. in the Select One field
	And User select White on Old Style Select Menu dropdown
	Then User should see the colour selected White in the Old Style Select Menu field 

@SmokeTest
Scenario: Verify user is able to navigate to Widgets page and also validate sublist on menu page
	When User click on Widgets button
	Then User is on Widgets page
	And User scroll down to click Menu on Widgets page
	Then User is on Menu page
	When User hover mouse on Main item 2 dropdwon menu btn
	Then User is presented with a dropdown that contains Sub Sub Lists
	And User hover mouse on Sub Sub Lists
	Then User is presented with Sub Sub Item 1 and Sub Sub Item 2