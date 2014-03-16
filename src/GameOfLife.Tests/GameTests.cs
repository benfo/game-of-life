using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Tick_GivenANewGame_IncreaseGenerationTo1()
        {
            var game = new Game();
            
            game.Tick();

            Assert.That(game.Generation, Is.EqualTo(1));
        }
    }
}
