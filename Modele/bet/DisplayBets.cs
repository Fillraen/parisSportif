using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouliereTrehou_parisSportif.Modele.bet
{
    public class DisplayedBet
    {
        public int idUser { get; set; }
        public List<DisplayedListBet> listBets { get; set; }
    }

    public class DisplayedListBet
    {
        //id of bet to check later if we won
        public int idBets { get; set; }

        //id of the match to check later if we won
        public int idFixture { get; set; }

        public string league { get; set; }
        public string leagueLogo { get; set; }

        //name of the team home
        public string teamHome { get; set; }
        public string logoTeamHome { get; set; }
        

        //name of the team away
        public string teamAway { get; set; }
        public string logoTeamAway { get; set; }

        //what you bet for theme
        public string userBetTheme { get; set; }

        //what you bet for
        public string userBet { get; set; }

        //odds of the bet
        public double odds { get; set; }

        //amount of the bet
        public int bet { get; set; }

        //date of the start of the match
        public string date { get; set; }
        public string dateDay { get; set; }
        public string dateHour { get; set; }


        //result of your bet
        public string? finalScore { get; set; }
        
        //how much you could win
        public double gain { get; set; }

        //status of the bet (won, lost, pending) 
        public string statusBet { get; set; }
    }

    public class DisplayedListBets
    {
        public List<DisplayedBet> bets { get; set; }
    }
}
