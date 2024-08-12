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
            int winPlayer = 0;
            int winOpponent = 0;
            int goalwin = 10;
            string playerChoice;

            Console.WriteLine("Wybierz swoją klasę:");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Juggernaut");
            Console.WriteLine("3. Wizard");
            playerChoice = Console.ReadLine();
            Hero player;
            Hero opponent;
            do
            {
                if (playerChoice == "1")
                {
                    player = Warrior.GenerateRandomWarrior();
                }
                else if (playerChoice == "2")
                {
                    player = Juggernaut.GenerateRandomJuggernaut();
                }
                else
                {
                    player = Wizard.GenerateRandomWizard();
                }
                int opponentClass = new Random().Next(1, 4);
                if (opponentClass == 1)
                {
                    opponent = Warrior.GenerateRandomWarrior();
                }
                else if (opponentClass == 2)
                {
                    opponent = Juggernaut.GenerateRandomJuggernaut();
                }
                else
                {
                    opponent = Wizard.GenerateRandomWizard();
                }
                bool playerStarts = new Random().Next(0, 2) == 0;
                if (playerStarts)
                {
                    Console.WriteLine("Gracz zaczyna pierwszy!");
                    player.Duel(opponent);
                }
                else
                {
                    Console.WriteLine("Przeciwnik zaczyna pierwszy!");
                    opponent.Duel(player);
                }
                // Zliczanie zwycięstw
                if (player.Winner)
                {
                    winPlayer++;
                }
                else if (opponent.Winner)
                {
                    winOpponent++;
                }

                Console.WriteLine();
                Console.WriteLine($"{player.Type} (Gracz): {winPlayer} zwycięstw");
                Console.WriteLine($"{opponent.Type} (Przeciwnik): {winOpponent} zwycięstw");
                Console.WriteLine();

            } while (winPlayer < goalwin && winOpponent < goalwin);
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}


//******* names bug fix **********
//do
//{
//    warrior3 = Wizard.GenerateRandomWizard();
//} while (warrior3.Name.Equals(warrior2.Name));
//********************************