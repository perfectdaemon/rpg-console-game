using System;
using System.Collections.Generic;

namespace ClassicRPG
{
    public class ActionResult
    {
        public virtual string Text { get; set; }

        public Action<GameState> Do { get; set; } = gs => { };

        public List<Action> AvailableActions { get; set; } = new List<Action>();
    }
}
