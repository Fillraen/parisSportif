using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SouliereTrehou_parisSportif.Modele.user;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace SouliereTrehou_parisSportif.Service.user
{
    internal class AuthUser
    {
        //declare the variable
        GetUser usersContent;
        ListUsers users;
        public AuthUser()
        {
            usersContent = new GetUser();
            deserializeUsers();
        }
        private void deserializeUsers()
        {
            // get the content of the file user.json and deserialize it 
            string content = usersContent.getAllUsers();
            users = JsonConvert.DeserializeObject<ListUsers>(content);
        }

        public User getUserDataFromID(int id)
        {
            // get the user from the list of users with the id given in parameter and send choosen data
            User user = new User();
            
            if (Islogin())
            {
                user = users.user.Find(x => x.id == id);
            }
            return user;
        }
        public void logOut()
        {
            if (Islogin())
            {
                //set the log condig to -1 and save it in the app.config
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("userConnected");
                config.AppSettings.Settings.Add("userConnected", "-1");

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }      
        public bool Islogin()
        {
            //check if the user is connected 
            int idUser = int.Parse(ConfigurationManager.AppSettings["userConnected"]);

            if (idUser >= 0)
            {
                return true;
            }
            return false;
        }
        
        public bool login(string username, string password)
        {
            /*
            Method to login a user 
            param1: username
            param2: password
            return: true if user is found 
                    false if user is not found
            */
            string hashPwd = Hash(password);
            foreach (User user in users.user)
            {
                if (user.name == username && user.password == hashPwd)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings.Remove("userConnected");
                    config.AppSettings.Settings.Add("userConnected", user.id.ToString());

                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    return true;
                }
            }
            return false;
        }
        private string Hash(string input)
        {
            // hash the password with SHA256 
            // and return the hash as a string
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            
            // byte[) is a type that represent a sequence of bytes
            // the hash is a sequence of bytes
            // so we need to convert it to a string in lowercase "x2"
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}

