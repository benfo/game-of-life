using System;
using System.Collections.Generic;

namespace GameOfLife.Core
{
    public class Life105PatternParser : IPatternParser
    {
        public IEnumerable<CellPattern> Parse(string pattern)
        {
            var rows = pattern.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var row = rows[rowIndex];
                for (var colIndex = 0; colIndex < row.Length; colIndex++)
                {
                    var patternCharacter = row[colIndex];
                    var state = patternCharacter == '*' ? CellState.Alive : CellState.Dead;

                    yield return new CellPattern
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