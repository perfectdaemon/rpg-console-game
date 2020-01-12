using System;

namespace ClassicRPG
{
    static class MyConsole
    {
        public static void Write(string text, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            WriteWrapper(text, foregroundColor, backgroundColor, Console.Write);
        }

        public static void WriteLine(string text, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            WriteWrapper(text, foregroundColor, backgroundColor, Console.WriteLine);
        }

        public static ConsoleKeyInfo ReadKey(ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            return WriteWrapper(foregroundColor, backgroundColor, Console.ReadKey);
        }

        private static void WriteWrapper(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, Action<string> consoleAction)
        {
            var previousText = Console.ForegroundColor;
            var previousBack = Console.BackgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            consoleAction(text);
            Console.ForegroundColor = previousText;
            Console.BackgroundColor = previousBack;
        }

        private static T WriteWrapper<T>(ConsoleColor foregroundColor, ConsoleColor backgroundColor, Func<T> consoleAction)
        {
            var previousText = Console.ForegroundColor;
            var previousBack = Console.BackgroundColor;

            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            var result = consoleAction();

            Console.ForegroundColor = previousText;
            Console.BackgroundColor = previousBack;

            return result;
        }
    }
}
