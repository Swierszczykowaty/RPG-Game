﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_warrior_expanded
{
    public abstract class Hero
    {
        protected static readonly string[] Names = { "El Waflo", "Lord Michael", "Drum The Strong", "Gocha The Wise", "Olga The Summoner", "Mefeeer The Honest", "King Hosuqa I", "Sir Radoslaw", "Great Knight Minio999", "Princess Zoozee", "Royal Prince Wilson" };
        protected string name;
        protected int health;
        protected int strength;
        readonly Random random = new();
        public Hero(string name, int health, int strength)
        {
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
            //Thread.Sleep(700);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Warrior {name} attacks for ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{power_attack}");
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