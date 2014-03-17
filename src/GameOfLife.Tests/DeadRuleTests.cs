using GameOfLife.Core;
using GameOfLife.Core.Rules;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class DeadRuleTests
    {
        [Test]
        public void Tick_DeadCellWithThreeLiveNeighbours_ComesAlive()
        {
            var cell = new Cell
            {
                State = CellState.Dead,
                LivingNeighbourCount = 3
            };

            new DeadRule().Apply(cell);

            Assert.That(cell.State == CellState.Alive);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void Tick_DeadCellWithAnythingElseThanThreeLivingCells_RemainsDead(int livingNeighbourCount)
        {
            var cell = new Cell
            {
                State = CellState.Dead,
                LivingNeighbourCount = livingNeighbourCount
            };

            new DeadRule().Apply(cell);

            Assert.That(cell.State == CellState.Dead);
        }
    }
}