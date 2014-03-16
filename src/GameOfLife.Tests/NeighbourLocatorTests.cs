using GameOfLife.Core;
using NUnit.Framework;
using System.Linq;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class NeighbourLocatorTests
    {
        private Grid _grid;

        [SetUp]
        public void SetUp()
        {
            _grid = new Grid(3, 3);
        }

        [Test]
        [TestCase("xa ," +
                  "aaa," +
                  "a  ", 3)]
        [TestCase("ax ," +
                  "aaa," +
                  "a  ", 4)]
        [TestCase(" x ," +
                  " aa," +
                  "a  ", 2)]
        [TestCase(" a ," +
                  "axa," +
                  "a a", 5)]
        [TestCase("aaa," +
                  "axa," +
                  "aaa", 8)]
        public void Find_CellWithNeighbours_ReturnsAllTheNeighbours(string pattern, int neighbourCount)
        {
            var testCase = NeighbourTestCase.Create(_grid, pattern);

            var locator = new NeighbourLocator(_grid);
            var neighbours = locator
                .Find(testCase.Cell)
                .Where(cell => cell.State == CellState.Alive)
                .ToArray();

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
            _grid[1, 1].State = CellState.Alive;
            _grid[col, row].State = CellState.Alive;

            var locator = new NeighbourLocator(_grid);
            var neighbours = locator
                .Find(_grid[1, 1])
                .Where(cell => cell.State == CellState.Alive)
                .ToArray();

            Assert.That(neighbours.Length, Is.EqualTo(1));
            Assert.That(neighbours[0], Is.EqualTo(_grid[col, row]));
        }

        [Test]
        public void Find_CellWith2Neighbours_Returns2Neighbours()
        {
            _grid[1, 1].State = CellState.Alive;

            _grid[0, 0].State = CellState.Alive;
            _grid[1, 2].State = CellState.Alive;

            var locator = new NeighbourLocator(_grid);
            var neighbours = locator
                .Find(_grid[1, 1])
                .Where(cell => cell.State == CellState.Alive)
                .ToArray();

            Assert.That(neighbours.Length, Is.EqualTo(2));
            Assert.That(neighbours[0], Is.EqualTo(_grid[0, 0]));
            Assert.That(neighbours[1], Is.EqualTo(_grid[1, 2]));
        }

        [Test]
        public void Find_CellWithNoNeighbours_ReturnsNoNeighbours()
        {
            _grid[1, 1].State = CellState.Alive;

            var locator = new NeighbourLocator(_grid);
            var neighbours = locator
                .Find(_grid[1, 1])
                .Where(cell => cell.State == CellState.Alive)
                .ToArray();

            Assert.That(neighbours.Count(), Is.EqualTo(0));
        }
    }
}