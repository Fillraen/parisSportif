using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.Configuration;
using Newtonsoft.Json;
using SouliereTrehou_parisSportif.Modele.bet;
using SouliereTrehou_parisSportif.Modele.user;
using SouliereTrehou_parisSportif.Service.bet;
using SouliereTrehou_parisSportif.Service.user;
using System.Windows.Ink;
using System.Windows.Data;

namespace SouliereTrehou_parisSportif.Service.user
{
    internal class ControlUser
    {
        //declare the variable
        
        const string pathUserDataJson = "../../../Resource/bdd/user.json";
        GetUser usersContent;
        GetUsersBets betsContent;
        DisplayedListBets displayListBets;
        ParisSportif paris;

        int idUser;
        ListUsers users { get; set; }
        public ControlUser()
        {
            idUser = int.Parse(ConfigurationManager.AppSettings["userConnected"]);

            paris = new ParisSportif();
            usersContent = new GetUser();
            betsContent = new GetUsersBets();
            displayListBets = new DisplayedListBets();
            
            getAllUsers();
            getAllBet();
        }
        private void deserializeUsers()
        {
            // get the content of the file user.json and deserialize it
            string content = usersContent.getAllUsers();
            users = JsonConvert.DeserializeObject<ListUsers>(content);
        }
        private void getAllBet()
        {
            // get the content of the file bet.json and deserialize it
            string content = usersContent.getAllBets();
            displayListBets = JsonConvert.DeserializeObject<DisplayedListBets>(content);
        }
        public DisplayedBet getUserBets(int idUser)
        {
            // get the user from the list of users with the id given in parameter and send his bets
            return displayListBets.bets.Find(x => x.idUser == idUser);
        }

        public ListUsers getAllUsers()
        {
            //return the list of all users
            deserializeUsers();
            return users;
        }
        public void addUser(string name, string email, string permission, string password)
        {
            // add a new user in the list of users and save it in the file user.json

            //get the last id of the list of users and add 1 to it to make a new id
            int lastIdUserCreated = int.Parse(ConfigurationManager.AppSettings["lastIdUserCreated"]);
            int newIdUserCreated = lastIdUserCreated + 1;
            
            //create a user
            User user = new User();
            user.id = newIdUserCreated;
            user.name = name;
            user.email = email;
            user.password = Hash(password);
            user.permission = permission;
            user.balance = 100;

            users.user.Add(user);
            string json = JsonConvert.SerializeObject(users);
            writeJson(json, pathUserDataJson);

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("lastIdUserCreated");
            config.AppSettings.Settings.Add("lastIdUserCreated", newIdUserCreated.ToString());

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        public void editUser(User editUser, bool isPasswordModified = false)
        {
            // edit a user in the list of users and save it in the file user.json 
            // if the password is modified, hash it before saving it
            // if the password is not modified, save the password as it is
            
            for (int i = 0; i < users.user.Count; i++)
            {
                if (users.user[i].id == editUser.id)
                {
                    users.user[i].name = editUser.name;
                    users.user[i].email = editUser.email;
                    users.user[i].permission = editUser.permission;
                    users.user[i].password = isPasswordModified ? Hash(editUser.password) : editUser.password;
                    users.user[i].balance = Math.Round(editUser.balance, 2);
                    break;
                }
            }
            string json = JsonConvert.SerializeObject(users);
            writeJson(json, pathUserDataJson);

            
        }
        public void deleteUser(int idUser)
        {
            // delete a user in the list of users and save it in the file user.json
            users.user.RemoveAll(x => x.id == idUser);
            string json = JsonConvert.SerializeObject(users);
            writeJson(json, pathUserDataJson);
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
        private void writeJson(string contentJson, string pathFileJson)
        { 
            //fonction qui permet d'ecrire le contenue du lien dans le fichier json
            System.IO.File.WriteAllText(pathFileJson, contentJson);
        }
    }
}

