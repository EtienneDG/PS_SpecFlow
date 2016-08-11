Feature: PlayerCharacter
	In order to play the game
	As a player
	I want my character to be correctly represented

Background: 
	Given I'm a new player

@healthMgmt
Scenario Outline: Health reduction
	When I take <damage> damage
	Then My health should now be <remainingHealth>
	Examples: 
	| damage | remainingHealth |
	| 0      | 100             |
	| 40     | 60              |
	| 80     | 20              |
	| 100    | 0               |
	| 120    | 0               |

Scenario: Taking too much damages results in player death
	When I take 100 damage
	Then I should be dead
	
	
Scenario: Elf race players get 20 additional damage res
		And I'm an Elf
		And I have a damage resistance of 10
	When I take 40 damage
	Then My health should now be 90

Scenario: Elf race players get 20 additional damage res (data table)
		And I have the following attribute
		| attribute | value |
		| DamageRes | 10    |
		| Race      | "Elf" |
