﻿using System.Collections;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Grid : IEnumerable<Cell>
    {
        private readonly Cell[,] _cells;
        private readonly NeighbourLocator _neighbourLocator;

        public Grid(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;

            _cells = new Cell[columns, rows];
            _neighbourLocator = new NeighbourLocator(this);

            Initialize();
        }

        public int Columns { get; private set; }

        public int Rows { get; private set; }

        internal NeighbourLocator NeighbourLocator
        {
            get { return _neighbourLocator; }
        }

        public Cell this[int column, int row]
        {
            get { return _cells[column, row]; }
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    yield return this[column, row];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Initialize()
        {
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    _cells[column, row] = new Cell(this)
                    {
                        Column = column,
                        Row = row,
                        State = CellState.Dead
                    };
                }
            }
        }
    }
}