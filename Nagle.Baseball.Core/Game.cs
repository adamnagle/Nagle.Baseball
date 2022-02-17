using System;
using System.Collections.Generic;
using System.Linq;

namespace Nagle.Baseball
{
    public class Game
    {
        public const int INNINGS_COUNT = 9;
        private Random rnd = new Random();

        public Team HomeTeam { get; }
        public Team AwayTeam { get; }

        public int CurrentInningIndex { get; private set; } = 0;
        public Inning CurrentInning => Innings.ElementAt(CurrentInningIndex);

        public bool IsDone { get; set; }

        public Game(Team homeTeam, Team awayTeam)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }

        /// <summary>
        /// Simulate next action
        /// </summary>
        public void Next()
        {
            //please pardon how simple this sim is :-)
            if (IsDone == false)
            {
                if (CurrentInning.TeamsBatted >= 2)
                {
                    NextInning();
                }

                var runs = rnd.Next(0, 9);

                if(CurrentInning.TeamAtBat == TeamType.HomeTeam)
                {
                    CurrentInning.HomeTeamRuns = runs;
                }
                else
                {
                    CurrentInning.AwayTeamRuns = runs;
                }

                CurrentInning.TeamsBatted++;
            }
        }

        public List<Inning> Innings { get; set; } =
            Enumerable.Range(1, INNINGS_COUNT)  //this will never ever, ever, change :-)
            .Select(i => new Inning(i))
            .ToList();

        public class Inning
        {
            public int Number { get; internal set; }

            internal TeamType TeamAtBat { get; private set; }

            public int HomeTeamRuns { get; internal set; } = 0;
            public int AwayTeamRuns { get; internal set; } = 0;

            public int TeamsBatted = 0;

            public Inning(int number)
            {
                Number = number;

                //Visiting Team bats first
                var isOddInning = number % 2 == 1;
                TeamAtBat = isOddInning ? TeamType.AwayTeam : TeamType.HomeTeam;

            }
        }

        private void NextInning()
        {
            if (CurrentInningIndex >= INNINGS_COUNT-1)
            {
                EndGame();
            }
            else
            {
                CurrentInningIndex++;
            }
        }

        private void EndGame()
        {
            IsDone = true;
        }

        public GameSnapshot GenerateSnapshot()
        {
            var snapshot = new GameSnapshot(HomeTeam, AwayTeam, Innings);
            return snapshot;
        }
    }
}