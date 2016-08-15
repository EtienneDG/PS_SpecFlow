using System;
using System.Collections;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;

namespace GameCore.Specs
{
    [Binding]
    public class PlayerCharacterSteps : TechTalk.SpecFlow.Steps
    {
        private readonly PlayerCharacterStepsContext _context;

        public PlayerCharacterSteps(PlayerCharacterStepsContext context)
        {
            _context = context;
        }

        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int damage)
        {
            _context.Player.Hit(damage);
        }

        [When(@"I take (.*) damage")]
        [Scope(Tag = "elf")]
        public void WhenITakeDamageAsAnElf(int damage)
        {
            _context.Player.Hit(damage);
        }

        [Then(@"My health should now be (.*)")]
        public void ThenMyHealthShouldNowBe(int expectedHealth)
        {
            Assert.Equal(_context.Player.Health, expectedHealth);
        }

        [Then(@"I should be deadd")]
        public void ThenIShouldBeDead()
        {
            Assert.True(_context.Player.IsDead);
        }


        [Given(@"I'm an Elf")]
        public void GivenImAnElf()
        {
            _context.Player.Race = "Elf";
        }

        [Given(@"I have a damage resistance of (.*)")]
        public void GivenIHaveADamageResistanceOf(int damageRes)
        {
            _context.Player.DamageResistance = damageRes;
        }

        [Given(@"I have the following attribute")]
        public void GivenIHaveTheFollowingAttribute(Table table)
        {
         //   var attributes = table.CreateInstance<PlayerAttributes>();
            dynamic attributes = table.CreateDynamicInstance();
            
            _context.Player.Race = attributes.Race;
            _context.Player.DamageResistance = attributes.DamageRes;

        }
        
        [Given(@"My character class is set to (.*)")]
        public void GivenMyCharacterClassIsSetToHealer(CharacterClass characterClass)
        {
            _context.Player.CharacterClass = characterClass;
        }


        [When(@"I cast a healing spell")]
        public void WhenICastAHealingSpell()
        {
            _context.Player.CastHealingSpell();
        }

        [Given(@"I have the following magical item")]
        public void GivenIHaveTheFollowingMagicalItem(Table table)
        {
            IEnumerable<MagicalItem> items = table.CreateSet<MagicalItem>();

            _context.Player.MagicalItems.AddRange(items);
        }

        [Then(@"My total magical power should be (.*)")]
        public void ThenMyTotalMagicalPowerShouldBe(int totalMagicalPower)
        {
            Assert.Equal(totalMagicalPower, _context.Player.MagicalPower);
        }

        [Given(@"I last slept (.* days ago)")]
        public void GivenILastSleptDaysAgo(DateTime lastTimeSlept)
        {
            _context.Player.LastSleepTime = lastTimeSlept;
        }

        [When(@"I use a restore health scroll")]
        public void WhenIUseARestoreHealthScroll()
        {
            _context.Player.ReadHealScroll();
        }


        [Given(@"I have the following weapon")]
        public void GivenIHaveTheFollowingWeapon(IEnumerable<Weapon> weapons)
        {
            _context.Player.Weapons.AddRange(weapons);
        }

        [Then(@"My weapons should be worth (.*)")]
        public void ThenMyWeaponsShouldBeWorth(int expectedWeaponValue)
        {
            var totalWeaponsValue = _context.Player.Weapons.Sum(x => x.Value);

            Assert.Equal(expectedWeaponValue,_context.Player.WeaponsValue);
        }

        [Given(@"I have an Amulet with a power of (.*)")]
        public void GivenIHaveAnAmuletWithAPowerOf(int power)
        {
            var amulet = new MagicalItem
            {
                Name = "Amulet",
                Power = power
            };

            _context.Player.MagicalItems.Add(amulet);

            _context.StartingMagicalPower = power;
        }

        [When(@"I use a magical Amulet")]
        public void WhenIUseAMagicalAmulet()
        {
            _context.Player.UseMagicalItem("Amulet");
        }

        [Then(@"the Amulet power should not be reduced")]
        public void ThenTheAmuletPowerShouldNotBeReduced()
        {
            int expectedPower = _context.StartingMagicalPower;

            Assert.Equal(expectedPower, _context.Player.MagicalItems.First(x => x.Name == "Amulet").Power);
        }


    }
}
