using System;
using System.Collections.Generic;
using System.Linq;
using static Nagle.Baseball.Game;

namespace Nagle.Baseball
{
    public class GameSnapshot
    {
        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public DateTime CreationTime { get; private set; }

        public GameSnapshot(Team homeTeam, Team awayTeam, List<Inning> innings)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            CreationTime = DateTime.Now;
            Innings = innings.Select(i => new InningSnapshot(i)).ToList();
        }

        public List<InningSnapshot> Innings { get; set; } = new List<InningSnapshot>();

        public class InningSnapshot
        {
            public int Number { get; private set; }

            public int HomeTeamRuns { get; private set; }
            public int AwayTeamRuns { get; private set; }

            public InningSnapshot(Inning inning)
            {
                Number = inning.Number;
                HomeTeamRuns = inning.HomeTeamRuns;
                AwayTeamRuns = inning.AwayTeamRuns;
            }
        }

        public override string ToString()
        {
            return $@" Game Score from {CreationTime.ToShortDateString()} {CreationTime.ToShortTimeString()}
    Inning1: {Innings[0].HomeTeamRuns} - {Innings[0].AwayTeamRuns}
    Inning1: {Innings[1].HomeTeamRuns} - {Innings[1].AwayTeamRuns}
    Inning1: {Innings[2].HomeTeamRuns} - {Innings[2].AwayTeamRuns}
    Inning1: {Innings[3].HomeTeamRuns} - {Innings[3].AwayTeamRuns}
    Inning1: {Innings[4].HomeTeamRuns} - {Innings[4].AwayTeamRuns}
    Inning1: {Innings[5].HomeTeamRuns} - {Innings[5].AwayTeamRuns}
    Inning1: {Innings[6].HomeTeamRuns} - {Innings[6].AwayTeamRuns}
    Inning1: {Innings[7].HomeTeamRuns} - {Innings[7].AwayTeamRuns}
    Inning1: {Innings[8].HomeTeamRuns} - {Innings[8].AwayTeamRuns}
";
        }
    }
}