using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public class PlayerCharacter
    {
        public void Hit(int damage)
        {
            var raceSpecificDamageRes = 0;

            if (Race == "Elf")
            {
                raceSpecificDamageRes = 20;
            }

            var damageTaken = Math.Max(damage - raceSpecificDamageRes - DamageResistance,0);

            Health = Math.Max(Health - damageTaken,0);

            if (Health <= 0)
            {
                IsDead = true;
            }
        }

        public int Health { get; private set; } = 100;
        public bool IsDead { get; private set; }
        public int DamageResistance { get; set; }
        public string Race { get; set; }
    }
}
