using System.Collections.Generic;
using System.Globalization;

namespace GameOfLife.Tests
{
    public class NeighbourTestCase
    {
        public NeighbourTestCase()
        {
            NeighbouringCells = new List<Cell>();
        }

        public Cell Cell { get; set; }

        public List<Cell> NeighbouringCells { get; set; }
    
        public static NeighbourTestCase Create(Grid grid, string pattern)
        {
            var neighbourTestCase = new NeighbourTestCase();

            var rows = pattern.Split(',');
            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var row = rows[rowIndex];
                for (var colIndex = 0; colIndex < row.Length; colIndex++)
                {
                    var cellPattern = row[colIndex].ToString(CultureInfo.InvariantCulture);

                    if (string.IsNullOrWhiteSpace(cellPattern))
                        continue;

                    grid[colIndex, rowIndex].State = CellState.Alive;
                    switch (cellPattern)
                    {
                        case "x":
                            neighbourTestCase.Cell = grid[colIndex, rowIndex];
                            break;

                        case "a":
                            neighbourTestCase.NeighbouringCells.Add(grid[colIndex, rowIndex]);
                            break;
                    }
                }
            }
            return neighbourTestCase;
        }

    }
}