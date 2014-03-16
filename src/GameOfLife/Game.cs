namespace GameOfLife
{
    public class Game
    {
        public void Tick()
        {
            Generation += 1;
        }

        public int Generation { get; private set; }
    }
}
