Feature: Logout1
	In order to sign out of my account
	As a client of NewBookModels
	I want to be logged out 
@mytag
Scenario: It is possible to logout of NewBookModels site
	Given client on newbookmodel.com
	And is log in 
	When client go to account setting page
	And click logout button
	Then client is signout 
