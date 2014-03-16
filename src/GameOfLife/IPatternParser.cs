using System.Collections.Generic;

namespace GameOfLife
{
    public interface IPatternParser
    {
        IEnumerable<CellPattern> Parse(string pattern);
    }
}