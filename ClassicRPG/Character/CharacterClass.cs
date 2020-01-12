namespace ClassicRPG.Character
{
    public abstract class CharacterClass
    {
        public abstract string DisplayName { get; }
    }

    public class Unclassed : CharacterClass
    {
        public override string DisplayName => "Без класса";
    }

    public class Warrior : CharacterClass
    {
        public override string DisplayName => "Воин";
    }

    public class Scoundrel : CharacterClass
    {
        public override string DisplayName => "Разбойник";
    }

    public class Mage : CharacterClass
    {
        public override string DisplayName => "Маг";
    }
}
