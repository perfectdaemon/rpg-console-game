namespace ClassicRPG
{
    public abstract class Action
    {
        public virtual string Name { get; }

        public virtual char Key { get; }

        public virtual bool CanSelect(GameState gameState) => true;

        public virtual bool ShouldDisplay(GameState gameState) => true;

        public virtual void Do(GameState gameState) { }
    }
}
