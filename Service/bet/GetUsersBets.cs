using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouliereTrehou_parisSportif.Service.bet
{
    internal class GetUsersBets
    {
        public GetUsersBets()
        {
            
        }
        public string getAllUsersBets()
        {
            //return the content of the file
            return System.IO.File.ReadAllText("../../../Resource/bdd/bet.json");
        }
    }
}
