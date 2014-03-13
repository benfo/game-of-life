using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Grid
    {
        private readonly Cell[,] _cells;

        public Grid(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
            _cells = new Cell[columns, rows];
        }

        public int Columns { get; private set; }

        public int Rows { get; private set; }

        public void AddCell(Cell cell)
        {
            _cells[cell.Column - 1, cell.Row - 1] = cell;
        }

        public Cell GetCell(int column, int row)
        {
            return _cells[column - 1, row - 1];
        }
    }
}