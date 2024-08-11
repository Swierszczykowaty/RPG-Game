using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_warrior_expanded
{
    public class Wizard : Hero
    {
        private int startmana;
        private readonly int mana;
        private readonly int magicStrenght;
        readonly Random random = new();

        public Wizard(string type, string name, int health, int strength, int startmana, int mana, int magicStrenght,int wins, bool winner, bool loser) : base(type, name, health, strength, wins, winner, loser)
        {
            this.startmana = startmana;
            this.mana = mana;
            this.magicStrenght = magicStrenght;
        }

        public static Wizard GenerateRandomWizard()
        {
            Random random = new();
            string type = "Wizard";
            string randomName = Names[random.Next(Names.Length)];
            int randomHealth = random.Next(60, 91);
            int randomStrength = random.Next(10, 36);
            int startmana = 0;
            int randomMana = random.Next(80, 100);
            int randomMagicStrenght = random.Next(90, 121);
            int wins = 0;
            bool winner = false;
            bool loser = false;
            return new Wizard(type, randomName, randomHealth, randomStrength, startmana, randomMana, randomMagicStrenght, wins, winner, loser);
        }
        public override void Attack(Hero opponent)
        {
            int magic_attack = random.Next(magicStrenght / 2, magicStrenght);
            int power_attack = random.Next(strength / 2, strength); 
            bool crittrue = false;
            bool blocktrue = false;
            bool magictrue = false;
            int crit = random.Next(1, 101);
            if (crit < 10)
            {
                crittrue = true;
                power_attack *= 2;
                magic_attack*= 2;
            }
            int block = random.Next(1, 101);
            if (block < 5)
            {
                blocktrue = true;
                if(this.startmana == 100)
                {
                    this.startmana = 0;
                }
            }
            else if(this.startmana == 100)
            {
                opponent.health -= magic_attack;
                this.startmana = 0;
                magictrue= true;
            }
            else
            {
                opponent.health -= power_attack;
                this.startmana += random.Next(mana / 2, mana);
                if (this.startmana > 100)
                {
                    this.startmana = 100;
                }
            }
            if (opponent.health < 0)
            {
                opponent.health = 0;
            }
            //Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{type}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" {name} attacks for ");
            Console.ForegroundColor = ConsoleColor.Red;
            if (blocktrue == false)
            {
                if (magictrue == true)
                {
                    Console.Write($"{magic_attack}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($" magic damage");
                }
                else 
                {
                    Console.Write($"{power_attack}");
                }
            }
            else
            {
                Console.Write("0");
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (crittrue == true && blocktrue == false)
            {
                Console.Write(" [CRITICAL]");
            }
            if (blocktrue == true)
            {
                Console.Write(" [BLOCK]");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" damage and the opponent has ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{opponent.health}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" health left.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($" Wizard mana is {this.startmana}.\n");
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
    }
}
