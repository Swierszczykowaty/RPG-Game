namespace RPG_warrior_expanded
{
    internal class Army
    {
        private string name;
        private Hero[] myArmy;

        public Army(int size, string name)
        {
            this.name = name;
            myArmy = new Hero[size];
        }

        public static Army generateRandomArmy(int size, string name)
        {
            Army army = new Army(size, name);

            for (int i = 0; i < size; i++)
            {
                if (i % 2 == 1)
                {
                    army.myArmy[i] = Warrior.GenerateRandomWarrior();
                }
                else
                {
                    army.myArmy[i] = Wizard.GenerateRandomWizard();
                }
            }
            return army;
        }
    }
}
