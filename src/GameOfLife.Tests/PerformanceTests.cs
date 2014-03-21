using GameOfLife.Core;
using NUnit.Framework;
using System.Diagnostics;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class PerformanceTests
    {
        [Test]
        public void PerformanceTest1()
        {
            var game = new Game(100, 100);
            var random = new Randomizer(1);
            for (int row = 0; row < 100; row++)
            {
                for (int col = 0; col < 100; col++)
                {
                    game.Grid[col, row].State = random.Next(0, 1) == 1 ? CellState.Alive : CellState.Dead;
                }
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                game.Tick();
            }
            stopwatch.Stop();
            Assert.Inconclusive("Elapsed time: " + stopwatch.ElapsedMilliseconds.ToString());
        }
    }
}