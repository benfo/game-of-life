using System;
using System.Threading;

namespace GameOfLife
{
    public class Cell
    {
        internal Cell()
        {
        }
        
        public CellState State { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public override bool Equals(object obj)
        {
            var target = obj as Cell;
            
            if (target == null)
                return false;

            return target.State == State &&
                target.Row == Row &&
                target.Column == Column;
        }

        public override int GetHashCode()
        {
            return State.GetHashCode() ^ Row.GetHashCode() ^ Column.GetHashCode();
        }
    }
}