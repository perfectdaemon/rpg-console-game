using ClassicRPG.Content;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassicRPG
{
    class Program
    {
        static void DisplayResult(ActionResult actionResult)
        {
            MyConsole.WriteLine(actionResult.Text);
        }

        static void Display(IEnumerable<Action> actions)
        {
            foreach (var action in actions)
            {
                MyConsole.Write($"> {action.Key}", ConsoleColor.Green);
                MyConsole.Write(" ");
                MyConsole.WriteLine(action.Text);
            }
        }

        static ConsoleKeyInfo GetPlayerInput()
        {
            Console.WriteLine();
            MyConsole.Write("> ", ConsoleColor.Green);
            var keyInfo = MyConsole.ReadKey(ConsoleColor.Green);
            Console.WriteLine();
            return keyInfo;
        }

        static void DisplayCannotSelect(Action action)
        {
            MyConsole.Write(Texts.CannotSelect, ConsoleColor.Red);
            MyConsole.Write(" ");
            MyConsole.WriteLine(action.Text, ConsoleColor.Green);

            if (!string.IsNullOrWhiteSpace(action.CannotSelectText))
                MyConsole.WriteLine(action.CannotSelectText);
        }        

        static void StartGame(ActionResult currentActionResult, GameState gameState)
        {
            while (gameState.IsPlaying)
            {
                Console.WriteLine();

                DisplayResult(currentActionResult);

                var visibleActions = currentActionResult.AvailableActions.Where(action => action.ShouldDiplay(gameState));
                var visibleActionKeys = visibleActions.ToDictionary(action => action.Key);

                Display(visibleActions);

                var keyInfo = GetPlayerInput();

                if (!visibleActionKeys.ContainsKey(keyInfo.KeyChar))
                    continue;

                var choosedAction = visibleActionKeys[keyInfo.KeyChar];

                var canChoose = choosedAction.CanSelect(gameState);

                if (!canChoose)
                {
                    DisplayCannotSelect(choosedAction);
                    continue;
                }

                currentActionResult = choosedAction.Result;
                currentActionResult.Do(gameState);
            }
        }

        static void Main(string[] args)
        {
            var gameState = new GameState();

            var currentActionResult = SetupMenu.CreateMenu();

            StartGame(currentActionResult, gameState);

            MyConsole.WriteLine(Texts.CanExitNow);
            Console.ReadKey();
        }
    }
}
