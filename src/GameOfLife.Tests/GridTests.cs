using System.Linq;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class GridTests
    {
        [Test]
        [TestCase(5, 5)]
        [TestCase(10, 5)]
        [TestCase(5, 10)]
        public void Constructor_GivenRowsAndColumns_ReturnsGivenRowAndColumnCount(int columns, int rows)
        {
            var grid = new Grid(columns, rows);

            Assert.That(grid.Rows, Is.EqualTo(rows));
            Assert.That(grid.Columns, Is.EqualTo(columns));
        }

        [Test]
        [TestCase(5, 5)]
        [TestCase(10, 5)]
        [TestCase(5, 10)]
        public void Constructor_GivenRowsAndColumn_GridIsInitializedWithDeadCells(int columns, int rows)
        {
            var grid = new Grid(columns, rows);

            var count = grid.Count(cell => cell.State == CellState.Dead);

            Assert.That(count, Is.EqualTo(columns * rows));
        }
    }
}
