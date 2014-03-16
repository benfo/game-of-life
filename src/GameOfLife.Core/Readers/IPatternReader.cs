using System.Collections.Generic;

namespace GameOfLife.Core.Readers
{
    public interface IPatternReader
    {
        IEnumerable<CellPattern> Read(string pattern);
    }
}