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
            Warrior warrior1 = Warrior.GenerateRandomWarrior();
            Warrior warrior2;
            do
            {
                warrior2 = Warrior.GenerateRandomWarrior();
            } while (warrior2.Name.Equals(warrior1.Name));
            warrior1.Duel(warrior2);

            //Warrior warrior1 = Warrior.GenerateRandomWarrior();
            //Wizard wiz2;
            //do
            //{
            //    wiz2 = Wizard.GenerateRandomWizard();
            //} while (wiz2.Name.Equals(warrior1.Name));
            //wiz2.Duel(warrior1);
        }
    }
}
