using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_warrior_expanded
{
    public class Warrior : Hero
    {
        public Warrior(string type, string name, int health, int strength, int wins, bool winner, bool loser) : base(type, name, health, strength, wins, winner, loser)
        {
        }
        public static Warrior GenerateRandomWarrior()
        {
            Random random = new();
            string type = "Warrior";
            string randomName = Names[random.Next(Names.Length)];
            int randomHealth = random.Next(60, 121);
            int randomStrength = random.Next(20, 41);
            int wins = 0;
            bool winner = false;
            bool loser = false;
            return new Warrior(type, randomName, randomHealth, randomStrength, wins, winner, loser);
        }
        public override void Duel(Hero opponent)
        {
            this.winner = false;
            this.loser = false;
            SetWinner(opponent.Winner);
            SetLoser(opponent.Loser);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"========= Battle between {this.type} {this.name} and {opponent.Type} {opponent.Name}! =========\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{this.name} have {this.health} health and {this.strength} strength.");
            Console.WriteLine($"{opponent.Name} have {opponent.Health} health and {opponent.Strength} strength.\n");

            while (this.IsAlive() && opponent.IsAlive())
            {
                this.Attack(opponent);
                if (opponent.IsAlive())
                {
                    opponent.Attack(this);
                }
            }
            if (this.IsAlive())
            {
                this.winner = true;
                this.wins++;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n========= Winner is {this.type} {this.name} with {this.health} health =========");
            }
            else if (opponent.IsAlive())
            {
                opponent.winner = true;
                opponent.wins++;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n========= Winner is {opponent.Type} {opponent.Name} with {opponent.Health} health =========");
            }
            else
            {
                Console.WriteLine("Both dead, gg, tie");
            }
        }
    }
}