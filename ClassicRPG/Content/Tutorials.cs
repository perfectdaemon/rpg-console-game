using ClassicRPG.Actions;
using System.Collections.Generic;

namespace ClassicRPG.Content
{
    public class StartTutorial : MonologueAction
    {
        protected override IList<string> DisplayTexts => new List<string>()
        {
            "Добро пожаловать в игру! Нажмите кнопку желаемого действия (цифра 1), чтобы продолжить",
            "Очень удобно, правда?",
            "И совсем не надоедает!",
            "А самое главное - всегда есть выбор!"
        };

        public override bool ShouldDisplay(GameState gameState) => base.ShouldDisplay(gameState) && gameState.Place == Place.Tutorial;
    }
}
