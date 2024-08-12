namespace RPG_warrior_expanded
{
    internal class TestHeros
    {
        static void Main(string[] args)
        {
            int winPlayer = 0;
            int winOpponent = 0;
            int goalwin;
            string playerChoice;
            int battleCounter = 1;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Choose your class (number 1 - 3):");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Warrior - Well trained solider.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2. Juggernaut - More Health, less attack damage.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("3. Wizard - Less health and attack damage, but can cast magic spells.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            playerChoice = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("How many wins do you want to play to?");
            string input;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                input = Console.ReadLine();
                if (int.TryParse(input, out goalwin))
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"You have chosen a game to {goalwin} wins.");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid number of games. Please enter a valid integer.");
                }
            }
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
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                if (playerStarts)
                {
                    //Console.WriteLine("Gracz zaczyna pierwszy!");
                    player.Duel(opponent, ref battleCounter);
                }
                else
                {
                    //Console.WriteLine("Przeciwnik zaczyna pierwszy!");
                    opponent.Duel(player, ref battleCounter);
                }
                if (player.Winner)
                {
                    winPlayer++;
                }
                else if (opponent.Winner)
                {
                    winOpponent++;
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine($"Your {player.Type} have total {winPlayer} wins");
                Console.WriteLine($"Opponent have total {winOpponent} wins");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                battleCounter++;
                Thread.Sleep(1000);

            } while (winPlayer < goalwin && winOpponent < goalwin);
            Console.ForegroundColor = ConsoleColor.Red;
            if (winPlayer == goalwin)
            {
                Console.WriteLine($"The winner is your {player.Type}!");
            }
            else
            {
                Console.WriteLine($"The winner is the opponent forces!");
            }
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