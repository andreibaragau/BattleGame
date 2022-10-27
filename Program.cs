using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGameApp
{
    class Program
    {
        static void Main(string[] args)
        {          
            Rules rules = new Rules();
            rules.Play();
            Console.Read();
        }
    }
}
