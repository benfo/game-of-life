namespace GameOfLife.Core
{
    public class Cell
    {
        public int Column { get; set; }

        public int LivingNeighbourCount { get; set; }

        public int Row { get; set; }

        public CellState State { get; set; }

        public void Tick()
        {
            if (State == CellState.Alive)
            {
                HandleLivingCell();
            }
            else
            {
                HandleDeadCell();
            }
        }

        private void HandleLivingCell()
        {
            if (LivingNeighbourCount < 2 || LivingNeighbourCount > 3)
            {
                State = CellState.Dead;
            }
        }

        private void HandleDeadCell()
        {
            if (LivingNeighbourCount == 3)
            {
                State = CellState.Alive;
            }
        }
    }
}