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
                    //random
                    int warrior1Attack = CalculateAttackBlock(warrior1.MaxAttack); 
                    int warrior2Block = CalculateAttackBlock(warrior2.MaxBlock); 

                    if (warrior1Attack > warrior2Block)
                    {
                        int damage = warrior1Attack - warrior2Block;
                        warrior2.Health -= damage;
                        Console.WriteLine("Attacker:{0}, attack value {1}, Defender: {2}, block value {3}","W1", warrior1Attack, "w2", warrior2Block);
                        Console.WriteLine("Winner of this round {0}, damage: {1}, remaining health of the loser {2}", "w1", damage, warrior2.Health);
                        Console.WriteLine("***********");
                    } else if (warrior1Attack <= warrior2Block)
                    {
                        Console.WriteLine("{0} block the attack","W2");
                        Console.WriteLine("***********");
                    }
                
                    round = 1;                 
                }
                else
                {
                    int warrior2Attack = CalculateAttackBlock(warrior2.MaxAttack);
                    int warrior1Block = CalculateAttackBlock(warrior1.MaxBlock);

                    if(warrior2Attack > warrior1Block)
                    {
                        int damage = warrior2Attack - warrior1Block;
                        warrior1.Health -= damage;
                        Console.WriteLine("Attacker:{0}, attack value {1}, Defender: {2}, block value {3}", "W2", warrior2Attack, "w1", warrior1Block);
                        Console.WriteLine("Winner of this round {0}, damage: {1}, remaining health of the loser {2}", "w2", damage, warrior1.Health);
                        Console.WriteLine("***********");
                    }
                    else if (warrior2Attack <= warrior1Block)
                    {
                        Console.WriteLine("{0} block the attack", "W1");
                        Console.WriteLine("***********");
                    }
                    round = 0;

                }

                if (warrior1.Health > 0 && warrior2.Health <= 0) 
                {
                    Console.WriteLine("{0} win", "W1");
                    return;
                }
                if (warrior2.Health > 0 && warrior1.Health <= 0)
                {
                    Console.WriteLine("{0} win", "W2");
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
