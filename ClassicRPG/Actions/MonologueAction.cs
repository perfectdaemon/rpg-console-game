using System.Collections.Generic;

namespace ClassicRPG.Actions
{
    public abstract class MonologueAction : Action
    {
        private int _index;
        protected abstract IList<string> DisplayTexts { get; }

        public override char Key => '1';

        public override string Name => "Далее";

        public override bool CanSelect(GameState gameState) => _index < DisplayTexts.Count;

        public override bool ShouldDisplay(GameState gameState) => CanSelect(gameState);

        public override void Do(GameState gameState)
        {
            MyConsole.WriteLine(DisplayTexts[_index]);
            MyConsole.WriteLine();
            ++_index;
        }
    }
}
