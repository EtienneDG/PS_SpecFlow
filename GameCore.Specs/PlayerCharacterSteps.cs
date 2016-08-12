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
    public class PlayerCharacterSteps
    {
        private PlayerCharacter _player { get; set; }

        [Given(@"I'm a new player")]
        public void GivenImANewPlayer()
        {
            _player = new PlayerCharacter();
        }

        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int damage)
        {
            _player.Hit(damage);
        }

        [Then(@"My health should now be (.*)")]
        public void ThenMyHealthShouldNowBe(int expectedHealth)
        {
            Assert.Equal(_player.Health, expectedHealth);
        }

        [Then(@"I should be deadd")]
        public void ThenIShouldBeDead()
        {
            Assert.True(_player.IsDead);
        }


        [Given(@"I'm an Elf")]
        public void GivenImAnElf()
        {
            _player.Race = "Elf";
        }

        [Given(@"I have a damage resistance of (.*)")]
        public void GivenIHaveADamageResistanceOf(int damageRes)
        {
            _player.DamageResistance = damageRes;
        }

        [Given(@"I have the following attribute")]
        public void GivenIHaveTheFollowingAttribute(Table table)
        {
         //   var attributes = table.CreateInstance<PlayerAttributes>();
            dynamic attributes = table.CreateDynamicInstance();
            
            _player.Race = attributes.Race;
            _player.DamageResistance = attributes.DamageRes;

        }
        
        [Given(@"My character class is set to (.*)")]
        public void GivenMyCharacterClassIsSetToHealer(CharacterClass characterClass)
        {
            _player.CharacterClass = characterClass;
        }


        [When(@"I cast a healing spell")]
        public void WhenICastAHealingSpell()
        {
            _player.CastHealingSpell();
        }

        [Given(@"I have the following magical item")]
        public void GivenIHaveTheFollowingMagicalItem(Table table)
        {
            IEnumerable<MagicalItem> items = table.CreateSet<MagicalItem>();

            _player.MagicalItems.AddRange(items);
        }

        [Then(@"My total magical power should be (.*)")]
        public void ThenMyTotalMagicalPowerShouldBe(int totalMagicalPower)
        {
            Assert.Equal(totalMagicalPower, _player.MagicalPower);
        }

        [Given(@"I last slept (.* days ago)")]
        public void GivenILastSleptDaysAgo(DateTime lastTimeSlept)
        {
            _player.LastSleepTime = lastTimeSlept;
        }

        [When(@"I use a restore health scroll")]
        public void WhenIUseARestoreHealthScroll()
        {
            _player.ReadHealScroll();
        }

    }
}
