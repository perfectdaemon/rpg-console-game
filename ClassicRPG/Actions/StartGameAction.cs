namespace ClassicRPG.Actions
{
    public class StartGameAction : MenuAction
    {
        public override char Key => '1';

        public override string Name => "Начать новую игру";

        public override void Do(GameState gameState)
        {
            gameState.Place = Place.Tutorial;
        }
    }

    public class ExitGameAction : MenuAction
    {
        public override char Key => '0';

        public override string Name => "Выход";

        public override void Do(GameState gameState)
        {
            gameState.IsPlaying = false;
        }
    }
}
