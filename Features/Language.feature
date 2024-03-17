Feature: Language

As a Mars Portal User,
I want to add, delete and Edit language feature.
So that the people seeking for the languages can look at what details I hold.




@addLanguage
Scenario Outline: 1. Add new languages with valid input
	Given Language Tab is selected in Profile Page/
	And  Delete the last language if there is no add new button 
	When I click on Add New buttons
	When I give input '<language>','<level>' of language
	Then '<language>' should be added
	Then language should be reset

Examples:
	| language                                         | level          |
	| Hindi                                            | Native         |
	| Spaqwserdfggtt1234567890Spaqwserdfggtt1234567890qwqewwhiugfiyfysgshcioshioividifioshddoh | Conversational |
	| J@#$%^CV                                         | Basic          |
	| English                                          | Fluent         |

Scenario: 2.Add new language with invalid input
	Given Language Tab is selected in Profile Page/
	And Delete the last language if there is no add new button
	When I click on Add New buttons to give invalid input
	When I give space as input <'language'>,<'level'> for language
	Then <'language'> should not add
	Then language should be reset

Scenario: 3.Add new language without chossing any level
	Given Language Tab is selected in Profile Page/
	When I click on Add New buttons to give invalid input
	When I give input <'language'> to language but not choosen level of language
	Then <'language'> should not be added

Scenario Outline: 4. Add new language with dupliacte language input
	Given Language Tab is selected in Profile Page/
	When I click on Add New buttons
	And  Add Japanese as <'language'>,<'level'> as basic
	When I click on Add New buttons
	When I give existing input '<language>','<level>'  of language
	Then Duplicate '<language>' should not be added
	Then language should be reset

Examples:
	| language | level |
	| Japanese  | Basic |
	


@updateLanguage
Scenario: 5. Editing existing languages
	Given Language Tab is selected in Profile Page/
	And Delete the last language if there is no add new button
	When I click on Add New buttons
	And  Add Japanese as <'language'>,<'level'> as basic  
	When I click on Pencil icon buttons
	When I update language and level of language
	Then Language and level should be updated
	Then language should be reset
