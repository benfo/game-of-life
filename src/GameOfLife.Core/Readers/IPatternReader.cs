using System.Collections.Generic;

namespace GameOfLife.Core.Readers
{
    public interface IPatternReader
    {
        IEnumerable<Cell> Read(string pattern);
    }
}