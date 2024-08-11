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
            int win3 = 0;
            int goalwin = 100;
            Warrior warrior1;
            Juggernaut warrior2;
            Wizard warrior3;
            do
            {
                warrior1 = Warrior.GenerateRandomWarrior();
                warrior2 = Juggernaut.GenerateRandomJuggernaut();
                warrior3 = Wizard.GenerateRandomWizard();
                //******* names bug fix **********
                //do
                //{
                //    warrior3 = Wizard.GenerateRandomWizard();
                //} while (warrior3.Name.Equals(warrior2.Name));
                //********************************
                //warrior1.Duel(warrior2);
                //warrior2.Duel(warrior3);
                warrior3.Duel(warrior2);
                // ********** class test **********
                if (warrior1.Wins == 1){ 
                    win1++;
                }
                else if(warrior2.Wins == 1){
                    win2++;
                }
                else
                {
                    win3++;
                }
                Console.WriteLine();
                Console.WriteLine($"{warrior1.type}: {win1}");
                Console.WriteLine($"{warrior2.type}: {win2}"); 
                Console.WriteLine($"{warrior3.type}: {win3}");
                Console.WriteLine();
            } while (win1 != goalwin && win2 != goalwin && win3 != goalwin);
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}