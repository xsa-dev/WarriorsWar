using WarriorWars.Equipment;
using WarriorWars.Enum;
using WarriorWars.Tools;
using System;

namespace warriors
{
    class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH = 100;
        private const int BAD_GUY_STARTING_HEALTH = 100;

        private readonly Faction faction;
        private int health;
        private string name;
        private bool isAlive;
        private Weapon weapon;
        private Armor armor;

        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
        }

        public Warrior(string name, Faction faction)
        {
            this.name = name;
            this.faction = faction;
            isAlive = true;

            switch (faction)
            {
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;

                    break;
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;

                    break;
                default:
                    break;
            }
        }

        public void Attact(Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armor.AmorPoints;

            enemy.health -= damage;

            if (enemy.health <= 0)
            {
                enemy.isAlive = false;

                Tools.ColorfulWriteLine($"{enemy.name} is dead!", ConsoleColor.Red);
                Tools.ColorfulWriteLine($"{name} is victorious!", ConsoleColor.Green);
            }
            else
            {
                Console.WriteLine($"{name} attacked {enemy.name}. {damage} damage is inflicted, remaining health of {enemy.name} is {enemy.health}");
            }

        }
    }
}