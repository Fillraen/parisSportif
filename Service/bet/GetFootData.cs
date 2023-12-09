using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SouliereTrehou_parisSportif.Service.bet
{
    internal class GetFootData
    {
        public string season { get; set; }
        
        string result;
        const string apiKey = "8539c8c6498047eeff3acde12c9dadc0";

        public GetFootData()
        {
            season = DateTime.Now.Year.ToString();
        }
        public async Task<string> GetStatus(string endpoint)
        {
            //fonction qui permet grace a l'url de l'api et l'endpoint rensaigner d'obtenir les resultat 
            //voulu ici notre statut donc nom, premon de de notre compteenvoyer par l'api ces reponce seront enregistrer dans la variable result
            //se qui permettera aprer de deserialiser la reponce
            
            string url = "https://v3.football.api-sports.io/" + endpoint;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);

            HttpResponseMessage responce = await client.GetAsync(url);
            if (responce.IsSuccessStatusCode)
            {
                var content = await responce.Content.ReadAsStringAsync();
                result = content;
            }
            else
            {
                result = "error";
            }
            return result;
        }

        public async Task<string> GetCurrentLeague(string endpoint)
        {
            //fonction qui permet grace a l'url de l'api et l'endpoint rensaigner d'obtenir les resultat 
            //voulu ici les league en cours envoyer par l'api ces reponce seront enregistrer dans la variable result
            //se qui permettera aprer de deserialiser la reponce
            
            string url = "https://v3.football.api-sports.io/" + endpoint;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);

            HttpResponseMessage responce = await client.GetAsync(url);

            if (responce.IsSuccessStatusCode)
            {
                var content = await responce.Content.ReadAsStringAsync();
                result = content;
            }
            else
            {
                result = "error";
            }
            return result;
        }


        public async Task<string> GetOdds(string endpoint, string league)
        {
            //fonction qui permet grace a l'url de l'api et l'endpoint rensaigner d'obtenir les resultat 
            //voulu ici sur les match disponible envoyer par l'api ces reponce seront enregistrer dans la variable result
            //se qui permettera aprer de deserialiser la reponce
            
            string url = "https://v3.football.api-sports.io/" + endpoint + league;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);

            HttpResponseMessage responce = await client.GetAsync(url);

            if (responce.IsSuccessStatusCode)
            {
                var content = await responce.Content.ReadAsStringAsync();
                result = content;
            }
            else
            {
                result = "error";
            }
            return result;
        }

        public async Task<string> GetFixture(string endpoint, string id)
        {
            //fonction qui permet grace a l'url de l'api et l'endpoint rensaigner d'obtenir les resultat 
            //voulu ici sur les donner de chaque match disponible comme les pari envoyer par l'api ces reponce seront enregistrer dans la variable result
            //se qui permettera aprer de deserialiser la reponce
            
            string url = "https://v3.football.api-sports.io/" + endpoint + id;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);

            HttpResponseMessage responce = await client.GetAsync(url);

            if (responce.IsSuccessStatusCode)
            {
                var content = await responce.Content.ReadAsStringAsync();
                result = content;
            }
            else
            {
                result = "error";
            }
            return result;
        }
    }
}