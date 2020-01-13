using System;
using ClassicRPG.Enemies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassicRPG.Tests
{
    [TestClass]
    public class EnemyTests
    {
        [TestMethod]
        public void TestGenerate()
        {
            var enemy = new Enemy();
            enemy.Generate(null, null);

            Assert.IsNotNull(enemy.EnemyName);
        }
    }
}
