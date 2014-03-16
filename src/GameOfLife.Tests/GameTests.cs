using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Constructor_Using3x3_ShouldReturn3x3Grid()
        {
            var game = new Game(3, 3);

            Assert.That(game.Grid.Columns, Is.EqualTo(3));
            Assert.That(game.Grid.Rows, Is.EqualTo(3));
        }

        [Test]
        public void Tick_GivenANewGame_IncreaseGenerationTo1()
        {
            var game = new Game(3, 3);

            game.Tick();

            Assert.That(game.Generation, Is.EqualTo(1));
        }

        [Test]
        public void Tick_Underpopulation_DiesOff()
        {
            var game = new Game(10, 10);
            game.Grid[5, 5].State = CellState.Alive;

            game.Tick();

            Assert.That(game.Grid[5, 5].State, Is.EqualTo(CellState.Dead));
        }

        [Test]
        [TestCase(6, 6, Patterns.StillLifes.Barge)]
        [TestCase(6, 5, Patterns.StillLifes.Beehive)]
        public void Tick_StillLifePattern_NothingIsBornOrDies(int gameCols, int gameRows, string pattern)
        {
            //Using pattern: http://www.conwaylife.com/wiki/Barge

            var game = new Game(gameCols, gameRows);

            LoadPattern(game, pattern);

            game.Tick();
            game.Tick();
            game.Tick();
            game.Tick();

            VerifyPattern(game, pattern);
        }

        private static void VerifyPattern(Game game, string pattern)
        {
            var cellPatterns = new PatternParser().Parse(pattern);
            foreach (var cellPattern in cellPatterns)
            {
                Assert.That(game.Grid[cellPattern.Column, cellPattern.Row].State, Is.EqualTo(cellPattern.State));
            }
        }

        private static void LoadPattern(Game game, string pattern)
        {
            var cellPatterns = new PatternParser().Parse(pattern);
            foreach (var cellPattern in cellPatterns)
            {
                game.Grid[cellPattern.Column, cellPattern.Row].State = cellPattern.State;
            }
        }
    }
}