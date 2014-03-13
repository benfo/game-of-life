namespace GameOfLife
{
    public class Grid
    {
        public Grid(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
        }

        public int Columns { get; private set; }

        public int Rows { get; private set; }
    }
}