using System;
using System.Collections.Generic;

namespace ClassicRPG
{
    abstract class ActionResult
    {
        public string Text { get; set; }

        public Action<GameState> Do { get; set; } = gs => { };

        public List<Action> AvailableActions { get; set; } = new List<Action>();
    }
}
