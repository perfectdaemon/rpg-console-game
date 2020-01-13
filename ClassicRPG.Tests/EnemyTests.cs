using ClassicRPG.Enemies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;

namespace ClassicRPG.Tests
{
    [TestClass]
    public class EnemyTests
    {
        [TestMethod]
        public void TestGenerate()
        {
            for (int i = 0; i < 10; ++i)
            {
                Thread.Sleep(32);
                var enemy = new Enemy();
                enemy.Generate(null, null);
                Debug.WriteLine(enemy.EnemyName);
            }
        }
    }
}
