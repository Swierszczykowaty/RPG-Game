using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_warrior_expanded
{
    public class Juggernaut :Hero
    {
        public Juggernaut(string type,string name, int health, int strength, int wins, bool winner, bool loser) : base(type, name, health, strength, wins, winner, loser)
        {
        }
        public static Juggernaut GenerateRandomJuggernaut()
        {
            Random random = new();
            string type = "Juggernaut";
            string randomName = Names[random.Next(Names.Length)];
            int randomHealth = random.Next(120, 151);
            int randomStrength = random.Next(14, 30);
            int wins = 0;
            bool winner = false;
            bool loser = false;
            return new Juggernaut(type, randomName, randomHealth, randomStrength, wins, winner, loser);
        }
    }
}