using ClassicRPG.Content;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassicRPG
{
    class Program
    {        
        static void Main(string[] args)
        {
            var game = new Game();

            game.Start();

            MyConsole.WriteLine(Texts.CanExitNow);
            Console.ReadKey();
        }
    }
}
