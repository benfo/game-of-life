using System.Linq;

namespace GameOfLife
{
    public class Game
    {
        private readonly Grid _grid;
        private readonly NeighbourLocator _neighbourLocator;

        public Game(int columns, int rows)
        {
            _grid = new Grid(columns, rows);
            _neighbourLocator = new NeighbourLocator(_grid);
        }

        public void Tick()
        {
            CalculateLivingNeighbours();

            EvolveCells();

            Generation += 1;
        }

        private void EvolveCells()
        {
            foreach (var cell in _grid)
            {
                cell.Tick();
            }
        }

        private void CalculateLivingNeighbours()
        {
            foreach (var cell in _grid)
            {
                cell.LivingNeighbourCount = _neighbourLocator
                    .Find(cell)
                    .Count(n => n.State == CellState.Alive);
            }
        }

        public int Generation { get; private set; }

        public Grid Grid
        {
            get { return _grid; }
        }
    }
}