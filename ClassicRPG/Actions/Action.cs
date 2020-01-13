using System;

namespace ClassicRPG
{
    class Action
    {
        public string Text { get; set; }

        public char Key { get; set; }

        public Func<GameState, bool> CanSelect { get; set; } = gs => true;

        public string CannotSelectText { get; set; }

        public Func<GameState, bool> ShouldDiplay { get; set; } = gs => true;

        public ActionResult Result { get; set; }
    }
}
