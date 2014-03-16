using System.Collections.Generic;

namespace GameOfLife.Core
{
    public interface IPatternReader
    {
        IEnumerable<CellPattern> Read(string pattern);
    }
}