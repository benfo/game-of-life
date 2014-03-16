namespace GameOfLife.Tests
{
    public class Patterns
    {
        public class StillLifes
        {
            public const string Barge =
                "......\r\n" +
                "..*...\r\n" +
                ".*.*..\r\n" +
                "..*.*.\r\n" +
                "...*..\r\n" +
                "......";

            public const string Beehive =
                "......\r\n" +
                "..**..\r\n" +
                ".*..*.\r\n" +
                "..**..\r\n" +
                "......";

            public const string ClawWithTail =
                "........\r\n" +
                ".**.....\r\n" +
                "..*.....\r\n" +
                "..*.**..\r\n" +
                "...*..*.\r\n" +
                ".....**.\r\n" +
                "........";
        }

        public class Spaceships
        {
            public const string Glider =
                ".*.\r\n" +
                "..*\r\n" +
                "***";
        }
    }
}