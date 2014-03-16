using System.Collections.Generic;

namespace GameOfLife
{
    public class PatternParser
    {
        public IEnumerable<CellPattern> Parse(string pattern)
        {
            var rows = pattern.Split('|');

            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var row = rows[rowIndex];
                for (var colIndex = 0; colIndex < row.Length; colIndex++)
                {
                    var patternCharacter = row[colIndex];
                    var state = patternCharacter == 'a' ? CellState.Alive : CellState.Dead;

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