using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGameApp
{
    class Weapons
    {
        public int BonusDoubleDamage(int damageVal)
        {
            return damageVal * 2;
        }
        public int BonusTripleDamage(int damageVal)
        {
            return damageVal * 3;
        }
        public int BonusDoubleBlock(int blockVal)
        {
            return blockVal * 3;
        }
        public int BonusTripleBlock(int blockVal)
        {
            return blockVal * 3;
        }

        public int EvadeAttack()
        {
            return 100;
        }
        public int MaxAttackWeapon()
        {
            return 25;
        }
    }
}
