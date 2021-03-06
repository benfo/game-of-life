﻿using System;
using System.Text;
using GameOfLife.Core;
using GameOfLife.Core.Readers;
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
        [TestCase(8, 7, Patterns.StillLifes.ClawWithTail)]
        public void Tick_StillLifePattern_NothingIsBornOrDies(int gameCols, int gameRows, string pattern)
        {
            //Using patterns from http://www.conwaylife.com/wiki/Category:Still_lifes
            var game = new Game(gameCols, gameRows);

            LoadPattern(game, pattern);

            game.Tick();
            game.Tick();
            game.Tick();
            game.Tick();

            VerifyPattern(game, pattern);
        }

        [Test]
        public void Tick_GliderPattern_Moves()
        {
            var game = new Game(10, 10);

            LoadPattern(game, Patterns.Spaceships.Glider);

            game.Tick();
            VerifyPattern(game, Patterns.Spaceships.GliderVerifyStep1);

            game.Tick();
            VerifyPattern(game, Patterns.Spaceships.GliderVerifyStep2);

            game.Tick();
            game.Tick();
            game.Tick();
            game.Tick();
            game.Tick();
            game.Tick();
            game.Tick();
            game.Tick();

            VerifyPattern(game, Patterns.Spaceships.GliderVerifyStep10);
        }

        [Test]
        public void Tick_BlinkerPattern_Moves()
        {
            var game = new Game(3, 3);

            LoadPattern(game, Patterns.Oscillators.Blinker);

            game.Tick();
            VerifyPattern(game, Patterns.Oscillators.BlinkerVerifyStep1);

            game.Tick();
            VerifyPattern(game, Patterns.Oscillators.Blinker);

            game.Tick();
            VerifyPattern(game, Patterns.Oscillators.BlinkerVerifyStep1);

            game.Tick();
            VerifyPattern(game, Patterns.Oscillators.Blinker);
        }

        private static void VerifyPattern(Game game, string pattern)
        {
            var cells = new Life105PatternReader().Read(pattern);
            foreach (var cell in cells)
            {
                Assert.That(game.Grid[cell.Column, cell.Row].State, Is.EqualTo(cell.State));
            }
        }

        private static void LoadPattern(Game game, string pattern)
        {
            var cells = new Life105PatternReader().Read(pattern);
            foreach (var cell in cells)
            {
                game.Grid[cell.Column, cell.Row].State = cell.State;
            }
        }
    }
}