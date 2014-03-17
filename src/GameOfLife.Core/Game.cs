using System.Linq;
using GameOfLife.Core.Rules;

namespace GameOfLife.Core
{
    public class Game
    {
        private readonly IAliveRule _aliveRule;
        private readonly IDeadRule _deadRule;
        private readonly Grid _grid;
        private readonly NeighbourLocator _neighbourLocator;
        public Game(int columns, int rows)
        {
            _grid = new Grid(columns, rows);
            _neighbourLocator = new NeighbourLocator(_grid);
            _deadRule = new DeadRule();
            _aliveRule = new AliveRule();
        }

        public int Generation { get; private set; }

        public Grid Grid
        {
            get { return _grid; }
        }

        public void Tick()
        {
            CalculateLivingNeighbours();

            EvolveCells();

            Generation += 1;
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

        private void EvolveCells()
        {
            foreach (var cell in _grid)
            {
                if (cell.State == CellState.Alive)
                {
                    _aliveRule.Apply(cell);
                }
                else
                {
                    _deadRule.Apply(cell);
                }
            }
        }
    }
}