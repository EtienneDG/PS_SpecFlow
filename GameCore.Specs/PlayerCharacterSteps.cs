using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

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

        [Then(@"I should be dead")]
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
            var race = table.Rows.First(x => x["attribute"] == "Race")["value"];
            var damageRes = table.Rows.First(x => x["attribute"] == "DamageRes")["value"];

            _player.Race = race;
            _player.DamageResistance = int.Parse(damageRes);

        }



    }
}
