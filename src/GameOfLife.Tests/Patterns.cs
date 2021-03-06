﻿namespace GameOfLife.Tests
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
                ".*\r\n" +
                "..*\r\n" +
                "***";

            public const string GliderVerifyStep1 =
                "...\r\n" +
                "*.*\r\n" +
                ".**\r\n" +
                ".*.";

            public const string GliderVerifyStep2 =
                "...\r\n" +
                "..*\r\n" +
                "*.*\r\n" +
                ".**";

            public const string GliderVerifyStep10 =
                ".....\r\n" +
                ".....\r\n" +
                ".....\r\n" +
                "....*\r\n" +
                "..*.*\r\n" +
                "...**";
        }

        public class Oscillators
        {
            public const string Blinker =
                "...\r\n" +
                "***\r\n" +
                "...";

            public const string BlinkerVerifyStep1 =
                ".*.\r\n" +
                ".*.\r\n" +
                ".*.";
        }
    }
}