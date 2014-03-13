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
        [TestCase(2, 2)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void AddCell_GivenACellWithColumnAndRow_AddsCellIntoThatColumn(int column, int row)
        {
            var grid = new Grid(4, 4);
            var cell = new Cell {Column = column, Row = row};

            grid.AddCell(cell);

            var addedCell = grid.GetCell(column, row);
            Assert.That(addedCell.Column, Is.EqualTo(column));
            Assert.That(addedCell.Row, Is.EqualTo(row));
        }

        [Test]
        public void Cells_ValidCellsAreAdded_ReturnsAddedCells()
        {
            var grid = new Grid(4, 4);
            var cell1 = new Cell { Column = 0, Row = 1 };
            var cell2 = new Cell { Column = 2, Row = 1 };
            var cell3 = new Cell { Column = 3, Row = 3 };
            var cell4 = new Cell { Column = 2, Row = 3 };

            grid.AddCell(cell1);
            grid.AddCell(cell2);
            grid.AddCell(cell3);
            grid.AddCell(cell4);

            var cells = grid.Cells;
            Assert.That(cells.ElementAt(0), Is.EqualTo(cell1));
        }
    }
}
