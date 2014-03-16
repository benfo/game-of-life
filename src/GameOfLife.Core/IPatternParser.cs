using System.Collections.Generic;

namespace GameOfLife.Core
{
    public interface IPatternParser
    {
        IEnumerable<CellPattern> Parse(string pattern);
    }
}