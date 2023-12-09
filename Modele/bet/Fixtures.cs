using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouliereTrehou_parisSportif.Modele.bet
{
    #region Fixtures

    public class FixturesAssist
    {
        public int? id { get; set; }
        public string? name { get; set; }
    }

    public class FixturesAway
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? logo { get; set; }
        public bool? winner { get; set; }
    }

    public class FixturesCards
    {
        public int? yellow { get; set; }
        public int? red { get; set; }
    }

    public class FixturesCoach
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? photo { get; set; }
    }

    public class FixturesColors
    {
        public FixturesPlayer player { get; set; }
        public FixturesGoalkeeper goalkeeper { get; set; }
    }

    public class FixturesDribbles
    {
        public int? attempts { get; set; }
        public int? success { get; set; }
        public int? past { get; set; }
    }

    public class FixturesDuels
    {
        public int? total { get; set; }
        public int? won { get; set; }
    }

    public class FixturesEvent
    {
        public FixturesTime time { get; set; }
        public FixturesTeam team { get; set; }
        public FixturesPlayer player { get; set; }
        public FixturesAssist assist { get; set; }
        public string? type { get; set; }
        public string? detail { get; set; }
        public string? comments { get; set; }
    }

    public class FixturesExtratime
    {
        public int? home { get; set; }
        public int? away { get; set; }
    }

    public class FixturesFixture
    {
        public int? id { get; set; }
        public string? referee { get; set; }
        public string? timezone { get; set; }
        public DateTime date { get; set; }
        public int? timestamp { get; set; }
        public FixturesPeriods periods { get; set; }
        public FixturesVenue venue { get; set; }
        public FixturesStatus status { get; set; }
    }

    public class FixturesFouls
    {
        public int? drawn { get; set; }
        public int? committed { get; set; }
    }

    public class FixturesFulltime
    {
        public int? home { get; set; }
        public int? away { get; set; }
    }

    public class FixturesGames
    {
        public int? minutes { get; set; }
        public int? number { get; set; }
        public string? position { get; set; }
        public string? rating { get; set; }
        public bool? captain { get; set; }
        public bool? substitute { get; set; }
    }

    public class FixturesGoalkeeper
    {
        public string? primary { get; set; }
        public string? number { get; set; }
        public string? border { get; set; }
    }

    public class FixturesGoals
    {
        public int? home { get; set; }
        public int? away { get; set; }
        public int? total { get; set; }
        public int? conceded { get; set; }
        public int? assists { get; set; }
        public int? saves { get; set; }
    }

    public class FixturesHalftime
    {
        public int? home { get; set; }
        public int? away { get; set; }
    }

    public class FixturesHome
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? logo { get; set; }
        public bool? winner { get; set; }
    }

    public class FixturesLeague
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? country { get; set; }
        public string? logo { get; set; }
        public object? flag { get; set; }
        public int? season { get; set; }
        public string? round { get; set; }
    }

    public class FixturesLineup
    {
        public FixturesTeam team { get; set; }
        public FixturesCoach coach { get; set; }
        public string? formation { get; set; }
        public List<FixturesStartXI> startXI { get; set; }
        public List<FixturesSubstitute> substitutes { get; set; }
    }

    public class FixturesPaging
    {
        public int? current { get; set; }
        public int? total { get; set; }
    }

    public class FixturesParameters
    {
        public string? id { get; set; }
    }

    public class FixturesPasses
    {
        public int? total { get; set; }
        public int? key { get; set; }
        public string? accuracy { get; set; }
    }

    public class FixturesPenalty
    {
        public int? home { get; set; }
        public int? away { get; set; }
        public object? won { get; set; }
        public object? commited { get; set; }
        public int? scored { get; set; }
        public int? missed { get; set; }
        public int? saved { get; set; }
    }

    public class FixturesPeriods
    {
        public int? first { get; set; }
        public int? second { get; set; }
    }

    public class FixturesPlayer
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? primary { get; set; }
        public string? number { get; set; }
        public string? border { get; set; }
        public string? pos { get; set; }
        public string? grid { get; set; }
        public string? photo { get; set; }
    }

    public class FixturesPlayer5
    {
        public FixturesTeam team { get; set; }
        public List<FixturesPlayer> players { get; set; }
        public FixturesPlayer player { get; set; }
        public List<FixturesStatistic> statistics { get; set; }
    }

    public class FixturesResponse
    {
        public FixturesFixture fixture { get; set; }
        public FixturesLeague league { get; set; }
        public FixturesTeams teams { get; set; }
        public FixturesGoals goals { get; set; }
        public FixturesScore score { get; set; }
        public List<FixturesEvent> events { get; set; }
        public List<FixturesLineup> lineups { get; set; }
        public List<FixturesStatistic> statistics { get; set; }
        public List<FixturesPlayer> players { get; set; }
    }

    public class FixturesRoot
    {
        public string? get { get; set; }
        public FixturesParameters parameters { get; set; }
        public List<object> errors { get; set; }
        public int? results { get; set; }
        public FixturesPaging paging { get; set; }
        public List<FixturesResponse> response { get; set; }
    }

    public class FixturesScore
    {
        public FixturesHalftime halftime { get; set; }
        public FixturesFulltime fulltime { get; set; }
        public FixturesExtratime extratime { get; set; }
        public FixturesPenalty penalty { get; set; }
    }

    public class FixturesShots
    {
        public int? total { get; set; }
        public int? on { get; set; }
    }

    public class FixturesStartXI
    {
        public FixturesPlayer player { get; set; }
    }

    public class FixturesStatistic
    {
        public FixturesTeam team { get; set; }
        public List<FixturesStatistic> statistics { get; set; }
        public string? type { get; set; }
        public object? value { get; set; }
        public FixturesGames games { get; set; }
        public int? offsides { get; set; }
        public FixturesShots shots { get; set; }
        public FixturesGoals goals { get; set; }
        public FixturesPasses passes { get; set; }
        public FixturesTackles tackles { get; set; }
        public FixturesDuels duels { get; set; }
        public FixturesDribbles dribbles { get; set; }
        public FixturesFouls fouls { get; set; }
        public FixturesCards cards { get; set; }
        public FixturesPenalty penalty { get; set; }
    }

    public class FixturesStatus
    {
        public string? @long { get; set; }
        public string? @short { get; set; }
        public int? elapsed { get; set; }
    }

    public class FixturesSubstitute
    {
        public FixturesPlayer player { get; set; }
    }

    public class FixturesTackles
    {
        public int? total { get; set; }
        public int? blocks { get; set; }
        public int? interceptions { get; set; }
    }

    public class FixturesTeam
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? logo { get; set; }
        public FixturesColors colors { get; set; }
        public DateTime update { get; set; }
    }

    public class FixturesTeams
    {
        public FixturesHome home { get; set; }
        public FixturesAway away { get; set; }
    }

    public class FixturesTime
    {
        public int? elapsed { get; set; }
        public int? extra { get; set; }
    }

    public class FixturesVenue
    {
        public object? id { get; set; }
        public string? name { get; set; }
        public string? city { get; set; }
    }

    #endregion
}
