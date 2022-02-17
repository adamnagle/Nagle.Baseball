using System;
using System.Collections.Generic;
using System.Linq;
using static Nagle.Baseball.Game;

namespace Nagle.Baseball
{
    public class GameSnapshot
    {
        public Team HomeTeam { get; private set; }

        public Team AwayTeam { get; private set; }

        public DateTime CreationTime { get; private set; }

        public GameSnapshot(Team homeTeam, Team awayTeam, List<Inning> innings)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            CreationTime = DateTime.Now;
            Innings = innings.Select(i => new InningSnapshot(i)).ToList();
            HomeTeamScore = Innings.Sum(i => i.HomeTeamRuns);
            AwayTeamScore = Innings.Sum(i => i.AwayTeamRuns);
        }

        public List<InningSnapshot> Innings { get; set; } = new List<InningSnapshot>();
        public int HomeTeamScore { get; }
        public int AwayTeamScore { get; }

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
            return $@" Game Score {HomeTeamScore} to {AwayTeamScore}
    Inning 1: {Innings[0].HomeTeamRuns} - {Innings[0].AwayTeamRuns}
    Inning 2: {Innings[1].HomeTeamRuns} - {Innings[1].AwayTeamRuns}
    Inning 3: {Innings[2].HomeTeamRuns} - {Innings[2].AwayTeamRuns}
    Inning 4: {Innings[3].HomeTeamRuns} - {Innings[3].AwayTeamRuns}
    Inning 5: {Innings[4].HomeTeamRuns} - {Innings[4].AwayTeamRuns}
    Inning 6: {Innings[5].HomeTeamRuns} - {Innings[5].AwayTeamRuns}
    Inning 7: {Innings[6].HomeTeamRuns} - {Innings[6].AwayTeamRuns}
    Inning 8: {Innings[7].HomeTeamRuns} - {Innings[7].AwayTeamRuns}
    Inning 9: {Innings[8].HomeTeamRuns} - {Innings[8].AwayTeamRuns}
";
        }
    }
}