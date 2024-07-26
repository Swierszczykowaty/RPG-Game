﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_warrior_expanded
{
    public class Warrior : Hero
    {
        public Warrior(string name, int health, int strength) : base(name, health, strength)
        {
        }
        public static Warrior GenerateRandomWarrior()
        {
            Random random = new();
            string randomName = Names[random.Next(Names.Length)];
            int randomHealth = random.Next(60, 121);
            int randomStrength = random.Next(20, 41);

            return new Warrior(randomName, randomHealth, randomStrength);
        }
        public override void Duel(Hero opponent)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"========= Battle between {this.name} and {opponent.Name}! =========\n");
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
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n========= Winner is {this.name} with {this.health} health =========");
                Console.ForegroundColor = ConsoleColor.Black;

            }
            else if (opponent.IsAlive())
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n========= Winner is {opponent.Name} with {opponent.Health} health =========");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.WriteLine("Both dead, gg, tie");
            }
        }
    }
}