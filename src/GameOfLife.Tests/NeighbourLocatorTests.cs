using NUnit.Framework;
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
            _grid3X3[1, 1].State = CellState.Alive;
            _grid3X3[col, row].State = CellState.Alive;

            var locator = new NeighbourLocator(_grid3X3);
            var neighbours = locator
                .Find(_grid3X3[1, 1])
                .Where(cell => cell.State == CellState.Alive)
                .ToArray();

            Assert.That(neighbours.Length, Is.EqualTo(1));
            Assert.That(neighbours[0], Is.EqualTo(_grid3X3[col, row]));
        }

        [Test]
        public void Find_CellWith2Neighbours_Returns2Neighbours()
        {
            _grid3X3[1, 1].State = CellState.Alive;

            _grid3X3[0, 0].State = CellState.Alive;
            _grid3X3[1, 2].State = CellState.Alive;

            var locator = new NeighbourLocator(_grid3X3);
            var neighbours = locator
                .Find(_grid3X3[1, 1])
                .Where(cell => cell.State == CellState.Alive)
                .ToArray();

            Assert.That(neighbours.Length, Is.EqualTo(2));
            Assert.That(neighbours[0], Is.EqualTo(_grid3X3[0, 0]));
            Assert.That(neighbours[1], Is.EqualTo(_grid3X3[1, 2]));
        }

        [Test]
        public void Find_CellWithNoNeighbours_ReturnsNoNeighbours()
        {
            _grid3X3[1, 1].State = CellState.Alive;

            var locator = new NeighbourLocator(_grid3X3);
            var neighbours = locator
                .Find(_grid3X3[1, 1])
                .Where(cell => cell.State == CellState.Alive)
                .ToArray();

            Assert.That(neighbours.Count(), Is.EqualTo(0));
        }
    }
}