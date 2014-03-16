using NUnit.Framework;
using System.Linq;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class NeighbourLocatorTests
    {
        private Grid _grid3X3;

        [SetUp]
        public void SetUp()
        {
            _grid3X3 = new Grid(3, 3);
        }

        [Test]
        public void Find_CellWithNoNeighbours_ReturnsNoNeighbours()
        {
            var cell = new Cell {Column = 1, Row = 1, State = CellState.Alive};
            _grid3X3.AddCell(cell);
            
            var locator = new NeighbourLocator(_grid3X3);
            var neighbours = locator.Find(cell);

            Assert.That(neighbours.Count(), Is.EqualTo(0));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(0, 1)]
        [TestCase(2, 1)]
        [TestCase(0, 2)]
        [TestCase(1, 2)]
        [TestCase(2, 2)]
        public void Find_CellWith1Neighbour_Returns1Neighbour(int col, int row)
        {
            var cell = new Cell { Column = 1, Row = 1, State = CellState.Alive };
            _grid3X3.AddCell(cell);

            _grid3X3.AddCell(new Cell { Column = col, Row = row, State = CellState.Alive });
            
            var locator = new NeighbourLocator(_grid3X3);
            var neighbours = locator.Find(cell);

            Assert.That(neighbours.Count(), Is.EqualTo(1));
        }
    }
}