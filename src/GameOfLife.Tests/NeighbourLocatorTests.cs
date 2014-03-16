using NUnit.Framework;
using System.Linq;

namespace GameOfLife.Tests
{
    public class NeighbourLocatorTests
    {
        [Test]
        public void Find_CellWithNoNeighbours_ReturnsNoNeighbours()
        {
            var locator = new NeighbourLocator();
            var cell = new Cell { Column = 0, Row = 0, State = CellState.Alive };
            var neighbours = locator.Find(cell);

            Assert.That(neighbours.Count(), Is.EqualTo(0));
        }
    }
}