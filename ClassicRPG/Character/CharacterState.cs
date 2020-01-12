using ClassicRPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassicRPG.Character
{
    public struct DamageInfo
    {
        public bool Missed { get; set; }

        public bool Critical { get; set; }

        public int Damage { get; set; }
    }

    public class CharacterState
    {
        public CharacterClass Class { get; set; } = new Unclassed();

        public int Physical { get; set; } = 1;

        public int Intelligence { get; set; } = 1;

        public int Luck { get; set; } = 1;

        public List<Item> Items { get; set; } = new List<Item>();

        public DamageInfo GetDamage()
        {
            var weapons = Items
                .Where(item => item is WeaponItem)
                .Select(item => item as WeaponItem)
                .ToList();

            var damage = Physical + weapons.Sum(weapon => weapon.Damage);

            var luckRoll = Math.Min(new Random().Next(), 1.0);

            if (luckRoll < 0.05 - (Luck * 0.01))
                return new DamageInfo { Critical = true, Missed = true, Damage = 0 };

            if (luckRoll < 0.1 - (Luck * 0.01))
                return new DamageInfo { Critical = false, Missed = true, Damage = 0 };

            if (luckRoll < 0.9 - (Luck * 0.02))
                return new DamageInfo { Critical = false, Missed = false, Damage = damage };

            return new DamageInfo { Critical = true, Missed = false, Damage = damage };
        }

        public void Display()
        {
            MyConsole.WriteLine("");

            MyConsole.Write("Класс:\t\t");
            MyConsole.WriteLine(Class.DisplayName, ConsoleColor.Blue);
            MyConsole.WriteLine("");

            MyConsole.Write("Тело:\t\t");
            MyConsole.WriteLine($"{Physical} пт.", ConsoleColor.Green);

            MyConsole.Write("Интеллект:\t");
            MyConsole.WriteLine($"{Intelligence} пт.", ConsoleColor.Green);

            MyConsole.Write("Удача:\t\t");
            MyConsole.WriteLine($"{Luck} пт.", ConsoleColor.Green);

            MyConsole.WriteLine("");
        }
    }
}
