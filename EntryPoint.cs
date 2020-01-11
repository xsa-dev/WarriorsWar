using System;
using WarriorWars.Enum;
using WarriorWars;
using System.Threading;

namespace warriors
{
    class EntryPoint
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Warrior BadGuy = new Warrior("Bob", Faction.BadGuy);
            Warrior GoodGuy = new Warrior("Bill", Faction.GoodGuy);

            GoodGuy.Attact(BadGuy);

            while (BadGuy.IsAlive && GoodGuy.IsAlive)
            {
                if (rnd.Next(0, 10) < 5)
                {
                    GoodGuy.Attact(BadGuy);
                }
                else
                {
                    BadGuy.Attact(GoodGuy);
                }

                Thread.Sleep(100);
            }
        }
    }
}
