using System;

namespace GameOfLife
{
    public class Cell
    {
        public int Column { get; set; }

        public int LivingNeighbourCount { get; set; }

        public int Row { get; set; }

        public CellState State { get; set; }

        public void Tick()
        {
        }
    }
}