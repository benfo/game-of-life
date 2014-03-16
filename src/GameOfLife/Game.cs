using System.Linq;

namespace GameOfLife
{
    public class Game
    {
        private Grid _grid;

        public Game(int columns, int rows)
        {
            _grid = new Grid(columns, rows);
        }
        public void Tick()
        {
            Generation += 1;

            foreach (var cell in _grid)
            {
                
            }
        }

        public int Generation { get; private set; }

        public Grid Grid
        {
            get { return _grid; }
        }
    }
}
