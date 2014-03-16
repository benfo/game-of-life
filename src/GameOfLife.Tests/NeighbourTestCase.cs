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

                    var cell = new Cell { Column = colIndex, Row = rowIndex };
                    grid.AddCell(cell);
                    switch (cellPattern)
                    {
                        case "c":
                            neighbourTestCase.Cell = cell;
                            break;

                        case "p":
                            neighbourTestCase.NeighbouringCells.Add(cell);
                            break;
                    }
                }
            }
            return neighbourTestCase;
        }

    }
}