using System;
using System.Collections.Generic;

namespace GameOfLife.Core.Readers
{
    public class Life105PatternReader : IPatternReader
    {
        public IEnumerable<Cell> Read(string pattern)
        {
            var rows = pattern.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var row = rows[rowIndex];
                for (var colIndex = 0; colIndex < row.Length; colIndex++)
                {
                    var patternCharacter = row[colIndex];
                    var state = patternCharacter == '*' ? CellState.Alive : CellState.Dead;

                    yield return new Cell
                    {
                        Column = colIndex,
                        Row = rowIndex,
                        State = state
                    };
                }
            }
        }
    }
}