using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGameApp
{
    class Rules
    {
        Warrior warrior1 = new Warrior();
        Warrior warrior2 = new Warrior();

        Random rnd = new Random();
        public int CalculateAttackBlock(int maxVal)
        {
            
            return rnd.Next(0, maxVal);
        }
             
        public int switchWeaponsAttack(Warrior warrior)
        {
            Weapons weapons = new Weapons();
            int opt = rnd.Next(4);
            switch(opt)
            {
                case 1: return weapons.BonusDoubleDamage(CalculateAttackBlock(warrior.MaxAttack));

                case 2: return weapons.BonusTripleDamage(CalculateAttackBlock(warrior.MaxAttack));
                
                case 3: return weapons.MaxAttackWeapon();
                
                default: return CalculateAttackBlock(warrior1.MaxAttack); 
            }
            
        }

        public int switchWeaponsDefend(Warrior warrior)
        {
            Weapons weapons = new Weapons();
            int opt = rnd.Next(6);
            switch (opt)
            {
                case 1: return weapons.BonusDoubleBlock(CalculateAttackBlock(warrior.MaxBlock));

                case 2: return weapons.BonusTripleDamage(CalculateAttackBlock(warrior.MaxBlock));
                
                case 3: return weapons.EvadeAttack();
                
                default: return CalculateAttackBlock(warrior1.MaxBlock);
            }

        }

        public void switchWizzard(Warrior warrior)
        {
            Wizard wizard = new Wizard();
            int opt = rnd.Next(8);
            switch (opt)
            {
                case 1:
                    {
                        wizard.RestoreHealth(warrior);
                        Console.WriteLine("wizard restore health");
                        break;
                    }
                case 2:
                    {
                        wizard.HealthIcrease(warrior);
                        Console.WriteLine("wizard increase health");
                        break;
                    }
                case 3:
                    {
                        wizard.MaxAttackIncrease(warrior);
                        Console.WriteLine("wizard increase max attack");
                        break;
                    }
                case 4:
                    {
                        wizard.MaxBlockIncrease(warrior);
                        Console.WriteLine("wizard increase max block");
                        break;
                    }
                default:break;
                    
            }
        }
        public void Play()
        {
            warrior1.Health = 100;
            warrior1.MaxAttack = 10;
            warrior1.MaxBlock = 5;
            warrior2.Health = 100;
            warrior2.MaxAttack = 15;
            warrior2.MaxBlock = 10;

            int round = 0;
                    
            while (true)
            {
                if (round == 0)
                {
                    switchWizzard(warrior1);
                    switchWizzard(warrior2);
                    int warrior1Attack = switchWeaponsAttack(warrior1);
                    int warrior2Block = switchWeaponsDefend(warrior2);

                    if (warrior1Attack > warrior2Block)
                    {
                        int damage = warrior1Attack - warrior2Block;
                        warrior2.Health -= damage;
                        Console.WriteLine("Attacker:{0}, attack value {1}, Defender: {2}, block value {3}","Warrior1", warrior1Attack, "Warrior2", warrior2Block);
                        Console.WriteLine("Winner of this round {0}, damage: {1}, remaining health of the loser {2}", "Warrior1", damage, warrior2.Health);
                        Console.WriteLine("health w1->{0}, w2->{1}", warrior1.Health, warrior2.Health);
                        Console.WriteLine("***********");
                    } else if (warrior1Attack <= warrior2Block)
                    {
                        Console.WriteLine("{0} block the attack", "Warrior2");
                        Console.WriteLine("***********");
                    }
                
                    round = 1;                 
                }
                else
                {
                    switchWizzard(warrior1);
                    switchWizzard(warrior2);
                    int warrior2Attack = switchWeaponsAttack(warrior2);
                    int warrior1Block = switchWeaponsDefend(warrior1);

                    if (warrior2Attack > warrior1Block)
                    {
                        int damage = warrior2Attack - warrior1Block;
                        warrior1.Health -= damage;
                        Console.WriteLine("Attacker:{0}, attack value {1}, Defender: {2}, block value {3}", "Warrior2", warrior2Attack, "Warrior1", warrior1Block);
                        Console.WriteLine("Winner of this round {0}, damage: {1}, remaining health of the loser {2}", "Warrior2", damage, warrior1.Health);
                        Console.WriteLine("health Warrior1->{0}, Warrior2->{1}", warrior1.Health, warrior2.Health);
                        Console.WriteLine("***********");
                    }
                    else if (warrior2Attack <= warrior1Block)
                    {
                        Console.WriteLine("{0} block the attack", "Warrior1");
                        Console.WriteLine("***********");
                    }
                    round = 0;

                }

                if (warrior1.Health > 0 && warrior2.Health <= 0) 
                {
                    Console.WriteLine("{0} win", "Warrior1");
                    return;
                }
                if (warrior2.Health > 0 && warrior1.Health <= 0)
                {
                    Console.WriteLine("{0} win", "Warrior2");
                    return;
                }
                if (warrior1.Health <= 0 && warrior2.Health <= 0)
                {
                    Console.WriteLine("Equal");
                    return;
                }
            }
        }
    
    }
}
