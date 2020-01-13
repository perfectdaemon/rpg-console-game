using ClassicRPG.Actions;
using ClassicRPG.Content;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassicRPG
{
    public class Game
    {
        private readonly Dictionary<Type, Action> _actions = new Dictionary<Type, Action>();

        public void RegisterAction<TAction>()
            where TAction : Action, new()
        {
            var action = new TAction();
            _actions.Add(typeof(TAction), action);
        }

        public void UnregisterAction<TAction>()
        {
            var actionType = typeof(TAction);
            var hasAction = _actions.TryGetValue(actionType, out var action);
            if (hasAction)
            {
                _actions.Remove(actionType);
            }
        }

        public void Start()
        {
            var gameState = new GameState();

            RegisterAction<StartGameAction>();
            RegisterAction<ExitGameAction>();
            RegisterAction<StartTutorial>();

            while (gameState.IsPlaying)
            {
                var visibleActions = _actions.Values.Where(action => action.ShouldDisplay(gameState));

                Display(visibleActions);

                var keyInfo = GetPlayerInput();

                var actionMap = visibleActions.ToDictionary(action => action.Key);

                if (!actionMap.TryGetValue(keyInfo.KeyChar, out var choosedAction))
                    continue;

                if (!choosedAction.CanSelect(gameState))
                    continue;

                choosedAction.Do(gameState);
            }
        }

        void Display(IEnumerable<Action> actions)
        {
            foreach (var action in actions)
            {
                MyConsole.Write($"> {action.Key}", ConsoleColor.Green);
                MyConsole.Write(" ");
                MyConsole.WriteLine(action.Name);
            }
        }

        ConsoleKeyInfo GetPlayerInput()
        {
            Console.WriteLine();
            MyConsole.Write("> ", ConsoleColor.Green);
            var keyInfo = MyConsole.ReadKey(ConsoleColor.Green);
            Console.WriteLine();
            return keyInfo;
        }
    }
}
