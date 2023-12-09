using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouliereTrehou_parisSportif.Modele.bet
{
    #region class status
    public class Account
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
    }

    public class Paging
    {
        public int current { get; set; }
        public int total { get; set; }
    }

    public class Requests
    {
        public int current { get; set; }
        public int limit_day { get; set; }
    }

    public class Response
    {
        public Account account { get; set; }
        public Subscription subscription { get; set; }
        public Requests requests { get; set; }
    }

    public class Status
    {
        public string get { get; set; }
        public List<object> parameters { get; set; }
        public List<object> errors { get; set; }
        public int results { get; set; }
        public Paging paging { get; set; }
        public Response response { get; set; }
    }

    public class Subscription
    {
        public string plan { get; set; }
        public DateTime end { get; set; }
        public bool active { get; set; }
    }



    #endregion

}
