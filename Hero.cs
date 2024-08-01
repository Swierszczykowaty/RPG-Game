using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_warrior_expanded
{
    public abstract class Hero
    {
        protected string type;
        protected static readonly string[] Names = {"El Roman", "Lord Michael", "Ignatius The Strong", "Gretel The Wise", "Jacob The Summoner", "Matthew The Honest", "King Arthur I", "Sir Christopher", "Great Knight Robin", "Princess Zoozee", "Royal Prince Wilson" };
        protected string name;
        protected int health;
        protected int strength;
        readonly Random random = new();
        public Hero(string type, string name, int health, int strength)
        {
            this.type = type;
            this.name = name;
            this.health = health;
            this.strength = strength;
        }
        public string Name => name;
        public int Health => health;
        public int Strength => strength;
        public void Damage(int power_attack)
        {
            this.health -= power_attack;
        }
        public void ZeroHealth()
        {
            this.health = 0;
        }
        public bool IsAlive() => health > 0;
        public virtual void Attack(Hero opponent)
        {
            int power_attack = random.Next(strength/2, strength); // this.strengt
            int crit = random.Next(1, 5);
            if (crit == 3) {
                power_attack *= 2;
            }
            opponent.health -= power_attack;
            if (opponent.health < 0 )
            {
                opponent.health = 0;
            }
            Thread.Sleep(700);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{type}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" {name} attacks for ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{power_attack}");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (crit == 3)
            {
                Console.Write(" critical");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" damage and the opponent has ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{opponent.health}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" health left.\n");
            //miss 5%
        }
        public abstract void Duel(Hero opponent);
    }
}