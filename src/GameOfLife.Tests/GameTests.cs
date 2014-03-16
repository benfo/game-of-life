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
        public void Tick_StillLifePattern_NothingIsBornOrDies()
        {
            //Using pattern: http://www.conwaylife.com/wiki/Barge

            var game = new Game(6, 6);

            LoadPattern(game, 1, 1, Patterns.StillLifes.Barge);

            game.Tick();
            game.Tick();

            VerifyPattern(game, 1, 1, Patterns.StillLifes.Barge);
        }

        private static void VerifyPattern(Game game, int colOffset, int rowOffset, string pattern)
        {
            var rows = pattern.Split('|');

            for (int rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var row = rows[rowIndex];
                for (int colIndex = 0; colIndex < row.Length; colIndex++)
                {
                    var statePattern = row[colIndex];
                    var state = statePattern == 'a' ? CellState.Alive : CellState.Dead;

                    Assert.That(game.Grid[colIndex + colOffset, rowIndex + rowOffset].State, Is.EqualTo(state));
                }
            }
        }

        private static string[] LoadPattern(Game game, int colOffset, int rowOffset, string pattern)
        {
            var rows = pattern.Split('|');

            for (int rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var row = rows[rowIndex];
                for (int colIndex = 0; colIndex < row.Length; colIndex++)
                {
                    var statePattern = row[colIndex];
                    var state = statePattern == 'a' ? CellState.Alive : CellState.Dead;

                    game.Grid[colIndex + colOffset, rowIndex + rowOffset].State = state;
                }
            }
            return rows;
        }
    }
}