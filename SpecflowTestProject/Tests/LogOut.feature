Feature: LogOut
	In order to sign out of my account
	As a client of NewBookModels
	I want to be logged out 
@mytag
Scenario: It is possible to logout NewBookModels
	Given Client is log in
	And Account Setting page is opened
	When I click "Log out of your account" link
	Then I successfully logout NewBookModels 