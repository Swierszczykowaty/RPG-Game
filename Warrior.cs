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
    }
}