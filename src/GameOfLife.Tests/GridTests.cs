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
        [TestCase(2, 2)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void AddCell_GivenACellWithColumnAndRow_AddsCellIntoThatColumn(int column, int row)
        {
            var grid = new Grid(4, 4);
            var cell = new Cell {Column = column, Row = row};

            grid.AddCell(cell);

            Cell addedCell = grid.GetCell(column, row);
            Assert.That(addedCell.Column, Is.EqualTo(column));
            Assert.That(addedCell.Row, Is.EqualTo(row));
        }
    }
}
