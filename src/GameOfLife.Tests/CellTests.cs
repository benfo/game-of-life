using GameOfLife.Core;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class CellTests
    {
        [Test]
        public void Tick_LivingCellWithFewerThenTwoLivingNeighbours_Dies()
        {
            var cell = new Cell
            {
                State = CellState.Alive,
                LivingNeighbourCount = 1
            };

            cell.Tick();

            Assert.That(cell.State == CellState.Dead);
        }

        [Test]
        public void Tick_LivingCellWithMoreThanThreeLivingNeighbours_Dies()
        {
            var cell = new Cell
            {
                State = CellState.Alive,
                LivingNeighbourCount = 4
            };

            cell.Tick();

            Assert.That(cell.State == CellState.Dead);
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public void Tick_LivingCellWithTwoOrThreeLivingNeighbours_RemainsLiving(int livingNeighbourCount)
        {
            var cell = new Cell
            {
                State = CellState.Alive,
                LivingNeighbourCount = livingNeighbourCount
            };

            cell.Tick();

            Assert.That(cell.State == CellState.Alive);
        }

        [Test]
        public void Tick_DeadCellWithThreeLiveNeighbours_ComesAlive()
        {
            var cell = new Cell
            {
                State = CellState.Dead,
                LivingNeighbourCount = 3
            };

            cell.Tick();

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

            cell.Tick();

            Assert.That(cell.State == CellState.Dead);
        }
    }
}