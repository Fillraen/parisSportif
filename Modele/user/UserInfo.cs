using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouliereTrehou_parisSportif.Modele.user
{
    public class ListUsers
    {
        public List<User> user { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public double balance { get; set; }
        public string permission { get; set; }
    }
}
