﻿using System;
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
        public int wins;
        public bool winner = false;
        public bool loser = false;
        readonly Random random = new();
        public Hero(string type, string name, int health, int strength, int wins, bool winner, bool loser)
        {
            this.type = type;
            this.name = name;
            this.health = health;
            this.strength = strength;
            this.wins = wins;
            this.winner = winner;
            this.loser = loser;
        }
        public string Type => type;
        public string Name => name;
        public int Health => health;
        public int Strength => strength;
        public int Wins => wins;
        public bool Winner => winner;
        public bool Loser => loser;
        public void SetWinner(bool winner)
        {
            this.winner = false;
        }
        public void SetLoser(bool loser)
        {
            this.loser = false;
        }
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
            bool crittrue = false;
            bool blocktrue = false;
            int crit = random.Next(1, 101);
            if (crit < 10) {
                crittrue = true;
                power_attack *= 2;
            }
            int block = random.Next(1, 101);
            if (block < 5) {
                blocktrue= true;
            }
            else{
                opponent.health -= power_attack;
            }
            if (opponent.health < 0 )
            {
                opponent.health = 0;
            }
            //Thread.Sleep(50);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{type}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" {name} attacks for ");
            Console.ForegroundColor = ConsoleColor.Red;
            if (blocktrue == false)
            {
                Console.Write($"{power_attack}");
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
            if (blocktrue== true)
            {
                Console.Write(" [BLOCK]");
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