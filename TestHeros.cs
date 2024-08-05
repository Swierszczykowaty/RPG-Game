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
            Wizard warrior3;
            do
            {
                warrior2 = Juggernaut.GenerateRandomJuggernaut();
                do
                {
                    warrior3 = Wizard.GenerateRandomWizard();
                } while (warrior3.Name.Equals(warrior2.Name));
                warrior2.Duel(warrior3);
                if (warrior2.Wins == 1){ //class test
                    win1++;
                }
                else{
                    win2++;
                }
                Console.WriteLine($"{warrior2.type}: {win1}"); 
                Console.WriteLine($"{warrior3.type}: {win2}");
            } while (win1 != 1000 && win2 != 1000);

            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}