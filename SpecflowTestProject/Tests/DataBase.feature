Feature: DataBase
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Does lead exist in Database after registration
	Given Connection to localDb is opened
	When I add new row in '[Shop].[dbo].[Clients]' Database Table
	| Id   | FirstName   | LastName   | PhoneNumber   |
	| <Id> | <FirstName> | <LastName> | <PhoneNumber> |
	Then Row with data is existed in '[Shop].[dbo].[Clients]' Database Table
	| Id   | FirstName | LastName   | PhoneNumber   |
	| <Id> | FirstName | <LastName> | <PhoneNumber> |
	When I close connection to localDB
Examples:
	| Id | FirstName | LastName | PhoneNumber |
	| 1  | 'Grysha'  | 'Kozvol' | 123123123   |
	| 2  | 'Grysha'  | 'Kozvol' | 123123123   |
	| 3  | 'Grysha'  | 'Kozvol' | 123123123   |
	| 4  | 'Grysha'  | 'Kozvol' | 123123123   |
	| 5  | 'Grysha'  | 'Kozvol' | 123123123   |
