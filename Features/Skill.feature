Feature: Skill

As a Mars Portal User,
I want to add, delete and Edit Skill feature.
So that the people seeking for the skill can look at what details I hold.


@deleteSkill
Scenario: 1. Delete existing Skill
	Given Skill Tab is selected in Profile Page
	When I click on cross icon buttons
	Then Existing skill delete successfully


@addSkill
Scenario Outline: 2. Add new skill with valid input
	Given Skill Tab is selected in Profile Page
	When I click on add New buttons
	When I give input '<skill>','<level>' of skill
	Then '<skill>' should be added in
Examples:
	| skill                                                | level        |
	| Specflow                                             | Beginner     |
	| 123                                                  | Intermediate |
	| C#@$%                                                | Expert       |
	| qwert12345yugfdawwer!@#$%^&&*()KJJHHhhhh()))))000000 | Beginner     |


Scenario: 3.Add new skill with invalid input in Skill textbox
	Given Skill Tab is selected in Profile Page
	When I click on add New buttons to give invalid input
	When I give space as input <'skill'>,<'level'> for skill
	Then <'skill'> should not added 

Scenario: 4.Add new skill without choosing any level
	Given Skill Tab is selected in Profile Page
	When I click on add New buttons to give invalid input
	When I give input <'skill'> to skill but not choosen level of skill
	Then <'skill'> should not be added in

Scenario Outline: 5. Add new skill with dupliacate skill input
	Given Skill Tab is selected in Profile Page
	When I click on add New buttons
	When I give existing input '<skill>','<level>'  of skill
	Then Duplicate '<skill>' should not be added in

Examples:
	| skill    | level    |
	| Specflow | Beginner |


@updateLanguage
Scenario: 6. Editing existing skill
	Given Skill Tab is selected in Profile Page
	When I click on pencil icon buttons
	When I update skill and level of skill
	Then skill and level should be updated




