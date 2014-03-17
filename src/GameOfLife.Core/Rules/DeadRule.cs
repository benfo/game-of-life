namespace GameOfLife.Core.Rules
{
    public class DeadRule : IDeadRule
    {
        public void Apply(Cell cell)
        {
            if (cell.LivingNeighbourCount == 3)
            {
                cell.State = CellState.Alive;
            }
        }
    }
}