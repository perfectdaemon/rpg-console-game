using ClassicRPG.Enemies;

namespace ClassicRPG.Actions
{
    class FightActionResult : ActionResult
    {
        private Enemy _enemy;

        public override string Text => $"Вы столкнулись с врагом: {_enemy.EnemyName}, ур. {_enemy.Level}";

        public FightActionResult()
        {
            Do = DoInternal;
        }

        private void DoInternal(GameState gameState)
        {
            _enemy = new Enemy();
            _enemy.Generate(gameState, null);
        }

    }
}
