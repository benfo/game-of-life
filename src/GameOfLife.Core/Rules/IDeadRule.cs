namespace GameOfLife.Core.Rules
{
    public interface IDeadRule
    {
        void Apply(Cell cell);
    }
}