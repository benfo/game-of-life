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
    }
}