using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouliereTrehou_parisSportif.Modele.bet
{
    public class ListDisplayedMatch
    {
        public List<DisplayedMatch> match { get; set; }
    }
    public class DisplayedMatch
    {
        public int id { get; set; }
        public string league { get; set; }
        public string leagueCountry { get; set; }
        public string leagueLogo { get; set; }

        public string startHour { get; set; }
        public string date { get; set; }
        
        public string team1 { get; set; }
        public string logoTeame1 { get; set; }
        public string team2 { get; set; }
        public string logoTeame2 { get; set; }
        public string status { get; set; }
        public string oddsName { get; set; }
        public double odds1 { get; set; }
        public double odds2 { get; set; }
        public double oddsN { get; set; }
        public double exactScore0_0 { get; set; }
        public double exactScore1_0 { get; set; }
        public double exactScore2_0 { get; set; }
        public double exactScore1_1 { get; set; }
        public double exactScore2_2 { get; set; }
        public double exactScore0_1 { get; set; }
        public double exactScore0_2 { get; set; }
        public double exactScore2_1 { get; set; }
        public double exactScore1_2 { get; set; }
        public double BothTeamsScoreYes { get; set; }
        public double BothTeamsScoreNo { get; set; }

    }
}
