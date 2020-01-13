using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicRPG.Actions
{
    public abstract class MenuAction : Action
    {
        public override bool CanSelect(GameState gameState) => gameState.Place == Place.Menu;
    }
}
