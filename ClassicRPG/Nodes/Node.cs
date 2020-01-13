using ClassicRPG.Enemies;
using System.Collections.Generic;

namespace ClassicRPG.Nodes
{
    public abstract class Node
    {
        public virtual void OnEnter(GameState gameState, Node fromNode) { }

        public ICollection<Transition> Transitions { get; set; }
    }

    public abstract class Transition
    {
        public virtual Node From { get; }

        public virtual Node To { get; }

        public virtual string Name { get; }

        public virtual char Key { get; }

        public virtual bool CanSelect(GameState gameState) => true;

        public virtual bool ShouldDisplay(GameState gameState) => true;
    }

    public class MenuNode : Node
    {
        protected virtual string Text { get; }

        public MenuNode(string text)
        {
            Text = text;
        }

        public override void OnEnter(GameState gameState, Node fromNode)
        {
            base.OnEnter(gameState, fromNode);
            MyConsole.WriteLine(Text);
        }
    }

    public class CloseCombatHitTransition : Transition
    {

    }

    public class FightEnemyNode : Node
    {
        public override void OnEnter(GameState gameState, Node fromNode)
        {
            base.OnEnter(gameState, fromNode);
            
            var enemy = new Enemy();
            enemy.Generate(gameState, null);

            
        }
    }

    public static class Test
    {
        public static void Do()
        {

        }
    }
}
