using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouliereTrehou_parisSportif.Modele.bet
{
    #region odds

    public class OddsBet
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<OddsValue> values { get; set; }
    }

    public class OddsBookmaker
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<OddsBet> bets { get; set; }
    }

    public class OddsFixture
    {
        public int id { get; set; }
        public string timezone { get; set; }
        public DateTime date { get; set; }
        public int timestamp { get; set; }
    }

    public class OddsLeague
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string logo { get; set; }
        public object flag { get; set; }
        public int season { get; set; }
    }

    public class OddsPaging
    {
        public int current { get; set; }
        public int total { get; set; }
    }

    public class OddsParameters
    {
        public string season { get; set; }
        public string bookmaker { get; set; }
        public string league { get; set; }
    }

    public class OddsResponse
    {
        public OddsLeague league { get; set; }
        public OddsFixture fixture { get; set; }
        public DateTime update { get; set; }
        public List<OddsBookmaker> bookmakers { get; set; }
    }

    public class Odds
    {
        public string get { get; set; }
        public OddsParameters parameters { get; set; }
        public List<object> errors { get; set; }
        public int results { get; set; }
        public OddsPaging paging { get; set; }
        public List<OddsResponse> response { get; set; }
    }

    public class OddsValue
    {
        public object value { get; set; }
        public string odd { get; set; }
    }


    #endregion
}
