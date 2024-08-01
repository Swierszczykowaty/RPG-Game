using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_warrior_expanded
{
    public class Wizard : Hero, Magic
    {
        private int mana;
        readonly Random random = new();

        public Wizard(string type, string name, int health, int strength, int mana, int wins, bool winner, bool loser) : base(type, name, health, strength, wins, winner, loser)
        {
            this.mana = mana;
        }

        public static Wizard GenerateRandomWizard()
        {
            Random random = new();
            string type = "Wizard";
            string randomName = Names[random.Next(Names.Length)];
            int randomHealth = random.Next(50, 91);
            int randomStrength = random.Next(10, 26);
            int randomMana = random.Next(30, 51);
            int wins = 0;
            bool winner = false;
            bool loser = false;
            return new Wizard(type, randomName, randomHealth, randomStrength, randomMana, wins, winner, loser);
        }
        public override void Attack(Hero opponent)
        {
            if(opponent is Magic)
            {
                base.Attack(opponent);
            }
            else
            {
                MagicAttack(opponent);
            }
        }
        public void MagicAttack(Hero opponent)
        {
            int power_attack = random.Next(mana / 2, mana); // this.strengt
            int crit = random.Next(1, 5);
            if (crit == 3)
            {
                power_attack *= 2;
            }
            opponent.Damage(power_attack);
            //Thread.Sleep(700);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Wizard {name} casts a spell for ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{power_attack}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" damage and the opponent has ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{opponent.Health}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" health left.\n");
        }
        public override void Duel(Hero opponent)
        {
            //info o duel
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"========= Battle between {this.type} {this.name} and {opponent.Type} {opponent.Name}! =========\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{this.name} have {this.health} health, {this.strength} strength and {this.mana} mana.");
            Console.WriteLine($"{opponent.Name} have {opponent.Health} health, {opponent.Strength} strength\n");
            //bitwe
            while (this.IsAlive() && opponent.IsAlive())
            {

                this.Attack(opponent);
                if (opponent.IsAlive())
                {
                    opponent.Attack(this);
                }
                if (opponent.Health < 0)
                {
                    opponent.ZeroHealth();
                }
            }
            if (this.IsAlive())
            {
                this.winner = true;
                wins++;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n========= Winner is {this.name} with {this.health} health =========");
            }
            else if (opponent.IsAlive())
            {   
                opponent.winner = true;
                wins++;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n========= Winner is {opponent.Name} with {opponent.Health} health =========");
            }
            else
            {
                Console.WriteLine("Both dead, gg, tie");
            }
        }
    }
}
