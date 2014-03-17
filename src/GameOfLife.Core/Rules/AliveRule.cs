namespace GameOfLife.Core.Rules
{
    public class AliveRule : IAliveRule
    {
        public void Apply(Cell cell)
        {
            if (cell.LivingNeighbourCount < 2 || cell.LivingNeighbourCount > 3)
            {
                cell.State = CellState.Dead;
            }
        }
    }
}