using System.Collections.Generic;

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
            _cells[cell.Column, cell.Row] = cell;
        }

        public Cell GetCell(int column, int row)
        {
            return _cells[column, row];
        }

        public IEnumerable<Cell> Cells
        {
            get
            {
                for (var row = 0; row < Rows; row++)
                {
                    for (var column = 0; column < Columns; column++)
                    {
                        var cell = _cells[column, row];
                        if (cell == null) continue;
                        yield return cell;
                    }
                }
            }
        }
    }
}