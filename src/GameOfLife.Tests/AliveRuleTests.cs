using GameOfLife.Core;
using GameOfLife.Core.Rules;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class AliveRuleTests
    {
        [Test]
        public void Tick_LivingCellWithFewerThenTwoLivingNeighbours_Dies()
        {
            var cell = new Cell
            {
                State = CellState.Alive,
                LivingNeighbourCount = 1
            };

            new AliveRule().Apply(cell);

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

            new AliveRule().Apply(cell);

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

            new AliveRule().Apply(cell);

            Assert.That(cell.State == CellState.Alive);
        }
    }
}