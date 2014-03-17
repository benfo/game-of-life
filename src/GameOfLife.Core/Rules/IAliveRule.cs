namespace GameOfLife.Core.Rules
{
    public interface IAliveRule
    {
        void Apply(Cell cell);
    }
}