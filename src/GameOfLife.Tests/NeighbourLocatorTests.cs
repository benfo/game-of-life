using System.Globalization;
using NUnit.Framework;
using System;
using System.Linq;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class NeighbourLocatorTests
    {
        private Grid _grid3X3;

        [SetUp]
        public void SetUp()
        {
            _grid3X3 = new Grid(3, 3);
        }

        [Test]
        [TestCase("cp ," +
                  "ppp," +
                  "p  ", 3)]
        [TestCase("pc ," +
                  "ppp," +
                  "p  ", 4)]
        [TestCase(" c ," +
                  " pp," +
                  "p  ", 2)]
        [TestCase(" p ," +
                  "pcp," +
                  "p p", 5)]
        [TestCase("ppp," +
                  "pcp," +
                  "ppp", 8)]
        public void Find_CellWithNeighbours_ReturnsAllTheNeighbours(string pattern, int neighbourCount)
        {
            var testCase = NeighbourTestCase.Create(_grid3X3, pattern);

            var locator = new NeighbourLocator(_grid3X3);
            var neighbours = locator.Find(testCase.Cell).ToArray();

            Assert.That(neighbours.Length, Is.EqualTo(neighbourCount));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(0, 1)]
        [TestCase(2, 1)]
        [TestCase(0, 2)]
        [TestCase(1, 2)]
        [TestCase(2, 2)]
        public void Find_CellWith1Neighbour_Returns1Neighbour(int col, int row)
        {
            var cell = new Cell { Column = 1, Row = 1, State = CellState.Alive };
            _grid3X3.AddCell(cell);

            var ncell = new Cell { Column = col, Row = row, State = CellState.Alive };
            _grid3X3.AddCell(ncell);

            var locator = new NeighbourLocator(_grid3X3);
            var neighbours = locator.Find(cell).ToArray();

            Assert.That(neighbours.Length, Is.EqualTo(1));
            Assert.That(neighbours[0], Is.EqualTo(ncell));
        }

        [Test]
        public void Find_CellWith2Neighbours_Returns2Neighbours()
        {
            var cell = new Cell { Column = 1, Row = 1, State = CellState.Alive };
            _grid3X3.AddCell(cell);

            var ncell1 = new Cell { Column = 0, Row = 0, State = CellState.Alive };
            var ncell2 = new Cell { Column = 1, Row = 2, State = CellState.Alive };
            _grid3X3.AddCell(ncell1);
            _grid3X3.AddCell(ncell2);

            var locator = new NeighbourLocator(_grid3X3);
            var neighbours = locator.Find(cell).ToArray();

            Assert.That(neighbours.Length, Is.EqualTo(2));
            Assert.That(neighbours[0], Is.EqualTo(ncell1));
            Assert.That(neighbours[1], Is.EqualTo(ncell2));
        }

        [Test]
        public void Find_CellWithNoNeighbours_ReturnsNoNeighbours()
        {
            var cell = new Cell { Column = 1, Row = 1, State = CellState.Alive };
            _grid3X3.AddCell(cell);

            var locator = new NeighbourLocator(_grid3X3);
            var neighbours = locator.Find(cell);

            Assert.That(neighbours.Count(), Is.EqualTo(0));
        }


    }
}