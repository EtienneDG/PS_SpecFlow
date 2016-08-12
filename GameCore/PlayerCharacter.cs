using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public class PlayerCharacter
    {
        public int Health { get; private set; } = 100;
        public bool IsDead { get; private set; }
        public int DamageResistance { get; set; }
        public string Race { get; set; }
        public List<MagicalItem> MagicalItems { get; set; } = new List<MagicalItem>();
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public CharacterClass CharacterClass { get; set; }
        public DateTime LastSleepTime { get; set; }
        public int MagicalPower => MagicalItems.Sum(x => x.Power);
        public int WeaponPower => Weapons.Sum(x => x.Value);


        public void Hit(int damage)
        {
            var raceSpecificDamageRes = 0;

            if (Race == "Elf")
            {
                raceSpecificDamageRes = 20;
            }

            var damageTaken = Math.Max(damage - raceSpecificDamageRes - DamageResistance, 0);

            Health = Math.Max(Health - damageTaken, 0);

            if (Health <= 0)
            {
                IsDead = true;
            }
        }

        public void CastHealingSpell()
        {
            if (CharacterClass == CharacterClass.Healer)
            {
                Health = 100;
            }
            else
            {
                Health += 10;
            }
        }

        public void ReadHealScroll()
        {
            var daySinceLastSleep = DateTime.Now.Subtract(LastSleepTime).Days;

            if (daySinceLastSleep < 2)
            {
                Health = 100;
            }
        }

        public void UseMagicalItem(string itemName)
        {
            int powerReduction = 10;

            if (Race == "Elf")
            {
                powerReduction = 0;
            }
            var itemToReduce = MagicalItems.First(x => x.Name == itemName);

            itemToReduce.Power -= powerReduction;

        }

    }
}
