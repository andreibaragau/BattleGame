using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGameApp
{
    class Wizard:Warrior
    {
        
        public void RestoreHealth(Warrior warrior)
        {
            warrior.Health = 100;
        }
        public void HealthIcrease(Warrior warrior)
        {
            warrior.Health += 20;
            if(warrior.Health>100)
            {
                warrior.Health = 100;
            }
        }

        public void MaxAttackIncrease(Warrior warrior)
        {
            warrior.MaxAttack += 10;
        }
        public void MaxBlockIncrease(Warrior warrior)
        {
            warrior.MaxBlock += 10;
        }

    }
}
