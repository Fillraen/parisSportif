using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouliereTrehou_parisSportif.Service.user
{
    internal class GetUser
    {
        public GetUser()
        {

        }
        public string getAllUsers()
        {
            // return all the file content
            return System.IO.File.ReadAllText("../../../Resource/bdd/user.json");
        }
        public string getAllBets()    
        {
            // return all the file content
            return System.IO.File.ReadAllText("../../../Resource/bdd/bet.json");
        }
        
    }
}
