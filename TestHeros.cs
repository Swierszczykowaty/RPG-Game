using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_warrior_expanded
{
    internal class TestHeros
    {
        static void Main(string[] args)
        {
            Warrior warrior1;
            Juggernaut warrior2;
            do
            {
                warrior1 = Warrior.GenerateRandomWarrior();
            do
            {
                warrior2 = Juggernaut.GenerateRandomJuggernaut();
            } while (warrior2.Name.Equals(warrior1.Name));
                warrior1.Duel(warrior2);
                Console.WriteLine(warrior1.Wins);
                Console.WriteLine(warrior2.Wins);
            } while (warrior1.Wins != 10 && warrior2.Wins != 10);
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}