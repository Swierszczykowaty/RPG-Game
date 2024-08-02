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
            int win1 = 0; //class test
            int win2 = 0;
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
                if (warrior1.Wins == 1){ //class test
                    win1++;
                }
                else{
                    win2++;
                }
                Console.WriteLine($"Warrior: {win1}"); 
                Console.WriteLine($"Juggernaut: {win2}");
            } while (win1 != 1000 && win2 != 1000);
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}