namespace GameOfLife
{
    public class Cell
    {
        private readonly Grid _grid;

        internal Cell(Grid grid)
        {
            _grid = grid;
        }

        public int Column { get; set; }

        public int Row { get; set; }

        public CellState State { get; set; }

        internal Grid Grid
        {
            get { return _grid; }
        }
    }
}