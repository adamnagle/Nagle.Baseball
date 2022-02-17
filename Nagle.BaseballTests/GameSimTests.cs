using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagle.Baseball;
using System;
using System.Linq;

namespace Nagle.BaseballTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GameSimTests()
        {
            var game = setupGame();

            while (game.IsDone == false)
            {
                game.Next();
            }

            var snapshot = game.GenerateSnapshot();

            Assert.AreEqual(Game.INNINGS_COUNT, snapshot.Innings.Count());
        }

        private Game setupGame()
        {
            var homeTeam = new Team(new User("username123"));
            var awayTeam = new Team(new User("username234"));
            var game = new Game(homeTeam, awayTeam);

            Assert.AreEqual(Game.INNINGS_COUNT, game.Innings.Count());

            return game;
        }
    }
}
