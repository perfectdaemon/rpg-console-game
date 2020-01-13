using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ClassicRPG.Enemies
{
    public class EnemyParams
    {

    }

    [Flags]
    public enum EnemyPrefix
    {
        [Description("Быстрый")]
        Quick = 1,

        [Description("Ядовитый")]
        Poison = 2,

        [Description("Огромный")]
        Huge = 4,
    }

    public enum EnemyType
    {
        [Description("Крыс")]
        Rat,

        [Description("Паук")]
        Spider,
    }

    [Flags]
    public enum EnemySuffix
    {
        [Description("с острым зрением")]
        WithPerfectEyes = 1,
    }

    public class Enemy
    {
        public int Level { get; private set; }

        public string EnemyName => string.Join(" ", Prefixes.Select(p => p.GetDescription()))
                                   + " "
                                   + Type.GetDescription()
                                   + " "
                                   + string.Join(" ", Suffixes.Select(p => p.GetDescription()));

        public ICollection<EnemyPrefix> Prefixes { get; set; } = new List<EnemyPrefix>();
        public EnemyType Type { get; set; }
        public ICollection<EnemySuffix> Suffixes { get; set; } = new List<EnemySuffix>();

        public void Generate(GameState gameState, EnemyParams enemyParams)
        {
            var random = new Random();
            Level = random.Next(0, 10);

            var prefixes = Enum.GetValues(typeof(EnemyPrefix)).Cast<EnemyPrefix>().ToList();

            var prefixCount = random.Next(prefixes.Count);

            for (var i = 0; i < prefixCount; ++i)
            {
                var index = random.Next(prefixes.Count);
                Prefixes.Add(prefixes[index]);
                prefixes.RemoveAt(index);
            }

            var suffixes = Enum.GetValues(typeof(EnemySuffix)).Cast<EnemySuffix>().ToList();

            var suffixCount = random.Next(suffixes.Count);

            for (var i = 0; i < suffixCount; ++i)
            {
                var index = random.Next(suffixes.Count);
                Suffixes.Add(suffixes[index]);
                suffixes.RemoveAt(index);
            }

            var types = Enum.GetValues(typeof(EnemyType)).Cast<EnemyType>().ToList();

            Type = (EnemyType)random.Next(types.Count);
        }
    }

    public static class Extensions
    {
        public static string GetDescription(this Enum self) => self.GetAttribute<DescriptionAttribute>().Description;

        public static TAttributeType GetAttribute<TAttributeType>(this Enum self)
        {
            var enumType = self.GetType();

            var fieldName = Enum.GetName(enumType, self);

            var attr = enumType.GetField(fieldName)
                .GetCustomAttributes(false)
                .OfType<TAttributeType>()
                .SingleOrDefault();

            return attr;
        }
    }
}
