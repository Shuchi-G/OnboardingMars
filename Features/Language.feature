Feature: Language

As a Mars Portal User,
I want to add, delete and Edit language feature.
So that the people seeking for the languages can look at what details I hold.

@deleteLanguage
Scenario: 1. Delete existing languages
	Given Language Tab is selected in Profile Page/
	When I click on Cross icon buttons
	Then Existing languages deleted successfully


@addLanguage
Scenario Outline: 2. Add new languages with valid input
	Given Language Tab is selected in Profile Page/
	When I click on Add New buttons
	When I give input '<language>','<level>' of language
	Then '<language>' should be added

Examples:
	| language                                         | level          |
	| Hindi                                            | Native         |
	| Spaqwserdfggtt1234567890Spaqwserdfggtt1234567890qwqewwhiugfiyfysgshcioshioividifioshddoh | Conversational |
	| J@#$%^CV                                         | Basic          |
	| English                                          | Fluent         |

Scenario: 3.Add new language with invalid input
	Given Language Tab is selected in Profile Page/
	Given Add New button should be there
	When I click on Add New buttons to give invalid input
	When I give space as input <'language'>,<'level'> for language
	Then <'language'> should not add

Scenario: 4.Add new language without chossing any level
	Given Language Tab is selected in Profile Page/
	Given Add New button should be there
	When I click on Add New buttons to give invalid input
	When I give input <'language'> to language but not choosen level of language
	Then <'language'> should not be added

Scenario Outline: 5. Add new language with dupliacte language input
	Given Language Tab is selected in Profile Page/
	Given Add New button should be there
	When I click on Add New buttons
	When I give existing input '<language>','<level>'  of language
	Then Duplicate '<language>' should not be added

Examples:
	| language | level |
	| English  | Basic |


@updateLanguage
Scenario: 6. Editing existing languages
	Given Language Tab is selected in Profile Page/
	When I click on Pencil icon buttons
	When I update language and level of language
	Then Language and level should be updated
