namespace GameOfLife.Core.Boundary
{
    public class DefaultBoundaryStrategy : IBoundaryStrategy
    {
        private readonly int _columns;
        private readonly int _rows;

        public DefaultBoundaryStrategy(int columns, int rows)
        {
            _columns = columns;
            _rows = rows;
        }

        public bool OutOfBounds(int targetColumn, int targetRow)
        {
            return targetColumn < 0 || targetRow < 0 || targetColumn >= _columns || targetRow >= _rows;
        }

        public int GetColumn(int targetColumn)
        {
            return targetColumn;
        }

        public int GetRow(int targetRow)
        {
            return targetRow;
        }
    }
}