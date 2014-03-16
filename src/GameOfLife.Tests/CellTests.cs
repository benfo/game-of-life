using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class CellTests
    {
        [Test]
        public void Tick_FewerThenTwoLivingNeighbours_Dies()
        {
            var cell = new Cell
            {
                State = CellState.Alive,
                LivingNeighbourCount = 1
            };
            
            cell.Tick();

            Assert.That(cell.State == CellState.Dead);
        }
    }
}