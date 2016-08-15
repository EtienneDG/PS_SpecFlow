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
	Then I should be deadd
	
	
Scenario: Elf race players get 20 additional damage res
		And I'm an Elf
		And I have a damage resistance of 10
	When I take 40 damage
	Then My health should now be 90

Scenario: Elf race players get 20 additional damage res (data table)
		And I have the following attribute
		| attribute | value |
		| DamageRes | 10    |
		| Race      | Elf   |

		
Scenario Outline: Healer restore full health
	Given My character class is set to <characterClass>
	When I take <damage> damage
		And I cast a healing spell
	Then My health should now be <remainingHealth>
	Examples:
	| characterClass | damage | remainingHealth |
	| Healer         | 10     | 100             |
	| Healer         | 30     | 100             |
	| Healer         | 50     | 100             |
	| Healer         | 70     | 100             |
	| Healer         | 90     | 100             |
	| Warrior        | 10     | 100             |
	| Warrior        | 30     | 80              |
	| Warrior        | 50     | 60              |
	| Warrior        | 70     | 40              |
	| Warrior        | 90     | 20              |

Scenario: Total magical power
	Given I have the following magical item
         | name   | value | power |
         | Ring   | 200   | 100   |
         | Amulet | 400   | 200   |
         | Gloves | 100   | 400   |
	Then My total magical power should be 700


Scenario Outline: Healing scroll usage
	Given I last slept <nbDays> days ago
	When I take <damage> damage
		And I use a restore health scroll
	Then My health should now be <remainingHealth>
	Examples:
	| nbDays | damage | remainingHealth |
	| 1      | 20     | 100             |
	| 1      | 80     | 100             |
	| 2      | 10     | 90              |
	| 2      | 50     | 50              |
	| 3      | 40     | 60              |
	| 3      | 90     | 10              |



Scenario: Weapons are worth money
	Given I have the following weapon
         | name  | value |
         | Sword | 50    |
         | Pick  | 40    |
         | Knife | 10    |
	Then My weapons should be worth 100


Scenario: Elf characters dont lose magical item power
	Given I'm an Elf
		And I have an Amulet with a power of 200
	When I use a magical Amulet
	Then the Amulet power should not be reduced