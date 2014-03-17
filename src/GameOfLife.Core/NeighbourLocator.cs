using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Core
{
    public class NeighbourLocator
    {
        private readonly Grid _grid;
        private readonly IBoundaryStrategy _boundaryStrategy;

        private static readonly Tuple<int,int>[] NeighbourOffsets =
        {
            new Tuple<int, int>(-1, -1), new Tuple<int, int>(0, -1), new Tuple<int, int>(1, -1),
            new Tuple<int, int>(-1, 0),  new Tuple<int, int>(1, 0),
            new Tuple<int, int>(-1, 1),  new Tuple<int, int>(0, 1), new Tuple<int, int>(1, 1)
        };


        public NeighbourLocator(Grid grid)
        {
            _grid = grid;
            _boundaryStrategy = new DefaultBoundaryStrategy(_grid.Columns, _grid.Rows);
        }

        public IEnumerable<Cell> Find(Cell cell)
        {
            var neighbouringCells =
                from offset in NeighbourOffsets
                select NeighbourAt(cell.Column + offset.Item1, cell.Row + offset.Item2);

            return neighbouringCells
                .Where(neighbour => neighbour != null);
        }

        private Cell NeighbourAt(int column, int row)
        {
            if (_boundaryStrategy.OutOfBounds(column, row)) return null;

            return _grid[_boundaryStrategy.GetColumn(column), _boundaryStrategy.GetRow(row)];
        }
    }
}