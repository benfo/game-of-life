using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public static class CellExtensions
    {
        public static IEnumerable<Cell> LivingNeighbours(this Cell cell)
        {
            return cell.Grid
                .NeighbourLocator
                .Find(cell)
                .Where(c => c.State == CellState.Alive);
        }

        public static IEnumerable<Cell> Neighbours(this Cell cell)
        {
            return cell.Grid
                .NeighbourLocator
                .Find(cell);
        }
    }
}