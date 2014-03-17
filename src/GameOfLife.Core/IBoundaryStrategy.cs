namespace GameOfLife.Core
{
    public interface IBoundaryStrategy
    {
        bool OutOfBounds(int targetColumn, int targetRow);
        int GetColumn(int targetColumn);
        int GetRow(int targetRow);
    }
}