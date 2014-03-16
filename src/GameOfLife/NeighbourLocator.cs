using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class NeighbourLocator
    {
        private readonly Grid _grid;

        private static readonly Offset[] NeighbourOffsets =
        {
            new Offset( -1, -1 ), new Offset( 0, -1 ), new Offset( 1, -1 ),
            new Offset( -1, 0 ), new Offset( 1, 0 ),
            new Offset( -1, 1 ), new Offset( 0, 1 ),new Offset( 1, 1 )
        };

        public NeighbourLocator(Grid grid)
        {
            _grid = grid;
        }

        public IEnumerable<Cell> Find(Cell cell)
        {
            var neighbouringCells = 
                from offset in NeighbourOffsets
                select NeighbourAt(cell.Column + offset.ColumnOffset, cell.Row + offset.RowOffset);

            return neighbouringCells
                .Where(neighbour => neighbour != null);
        }

        private Cell NeighbourAt(int column, int row)
        {
            if (OutOfBounds(column, row)) return null;
            
            return _grid[column, row];
        }

        private bool OutOfBounds(int column, int row)
        {
            return column < 0 || row < 0 || column >= _grid.Columns || row >= _grid.Rows;
        }

        private class Offset
        {
            public Offset(int columnOffset, int rowOffset)
            {
                RowOffset = rowOffset;
                ColumnOffset = columnOffset;
            }

            public int ColumnOffset { get; private set; }

            public int RowOffset { get; private set; }
        }
    }
}