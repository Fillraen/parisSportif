using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using SouliereTrehou_parisSportif.Modele.bet;
using Newtonsoft.Json;
using SouliereTrehou_parisSportif.View;
using SouliereTrehou_parisSportif.Modele.user;
using System.Configuration;
using System.IO;
using SouliereTrehou_parisSportif.Service.user;

namespace SouliereTrehou_parisSportif.Service.bet
{
    internal partial class Bets
    {
        public ListDisplayedMatch dataMatch { get; set; }
        public int requestLeft { get; set; }
        public string state { get; set; }
        
        private GetUsersBets _getUsersBets;
        private GetFootData rawMatchData;
        private Status status;
        private CurrentLeague currentleague;
        private Odds odds;
        private FixturesRoot fixturesroot;
        private DisplayedMatch match;
        private DisplayedListBets displaylistBets;
        private User user;
        private AuthUser login;
        private string result;
        private int idUser;
        private int nbLeague;
        private int nbDay;
        int idBookmaker;
        
        public Bets()
        {
            displaylistBets = new DisplayedListBets();
            _getUsersBets = new GetUsersBets();
            rawMatchData = new GetFootData();
            status = new Status();
            currentleague = new CurrentLeague();
            odds = new Odds();
            fixturesroot = new FixturesRoot();
            dataMatch = new ListDisplayedMatch();
            dataMatch.match = new List<DisplayedMatch>();
            login = new AuthUser();
            //get the id of the user connected and data of the user
            idUser = int.Parse(ConfigurationManager.AppSettings["userConnected"]);
            user = login.getUserDataFromID(idUser);
            idBookmaker = int.Parse(ConfigurationManager.AppSettings["bookmakers"]);


            //Define How many leagues we kept in the list at the maximum
            nbLeague = 5;

            //Define How many days before the match . so 1 the the actual Day
            nbDay = int.Parse(ConfigurationManager.AppSettings["day"]);

            //check if a file exist
            string pathJson = "../../../Resource/DataMatchs";
            string nameJson = getMatchDataFileName();
            string pathJsonFile = pathJson + "/" + nameJson;
            if (File.Exists(pathJsonFile))
            {
                //if the file exist, we get the content of the file
                dataMatch = JsonConvert.DeserializeObject<ListDisplayedMatch>(File.ReadAllText(pathJsonFile));

                //we check if the file is up to date
                for (int i = 0; i < dataMatch.match.Count; i++)
                {
                    DateTime dateMatch = DateTime.Parse(dataMatch.match[i].date + " " + dataMatch.match[i].startHour);
                    if (dateMatch < DateTime.Now)
                    {
                        dataMatch.match.RemoveAt(i);
                    }
                }
            }
            else
            {
                //if the file doesn't exist, we get the content of the API
                #region GetData from API
                //Get if API is OK
                result = getStatus();
                if (result == "success")
                {
                    //get how many request left
                    int limitRequestDay = status.response.requests.limit_day;
                    int currentRequestDay = status.response.requests.current;

                    requestLeft = limitRequestDay - currentRequestDay;

                    //get all current leagues
                    result = getCurrentLeague();
                    if (result == "success")
                    {
                        List<CurrentLeagueResponse> response = new List<CurrentLeagueResponse>();

                        //get all current leagues with bets ON
                        for (int i = 0; i < currentleague.response.Count; i++)
                        {
                            if (currentleague.response[i].seasons[0].coverage.odds == true)
                            {
                                CurrentLeagueResponse responseToAdd = currentleague.response[i];
                                response.Add(responseToAdd);
                            }
                        }
                        //Sort league by id (lesser is More important)
                        response.Sort((league1, league2) => { return league1.league.id.CompareTo(league2.league.id); });

                        List<CurrentLeagueResponse> league = new List<CurrentLeagueResponse>();

                        //get only the X first leagues
                        for (int i = 0; i < nbLeague; i++)
                        {
                            //CurrentLeagueResponse thisLeague = response[i];
                            //league.Add(thisLeague);
                        }
                        //get all matches for each league
                        for (int i = 0; i < league.Count; i++)
                        {
                            result = getOdds(league[i].league.id.ToString());
                            matchinfo();
                        }
                    }
                    else
                    {
                        state = "failed request current league";
                    }
                }
                else
                {
                    state = "API Connexion failed";
                }
                #endregion
            }
        }

        private string getMatchDataFileName()
        {
            //function to get the name of the json file depending on the option selected
            string fileName = "DataMatchs";
            fileName += "_" + DateTime.Now.ToString("yyyy-MM-dd");
            fileName += "_" + nbDay;
            fileName += ".json";
            
            return fileName;
        }
        private void saveMatchData()
        {
            // function to save the data of the match in a json file
            string pathJson = "../../../Resource/DataMatchs";
            string nameJson = getMatchDataFileName();
                    
            string finalPath = pathJson + "/" + nameJson;


            string json = JsonConvert.SerializeObject(dataMatch);
            writeJsonFile(finalPath, json);
        }
        private void matchinfo()
        {
            //function to get data from a match to the list validMatch

            //get all the date of prediction we accept
            List<DateTime> listDays = new List<DateTime>();

            for (int i = 0; i < nbDay; i++)
            {
                listDays.Add(DateTime.Now.AddDays(i));
            }

            List<OddsResponse> ValidMatch = new List<OddsResponse>();

            for (int i = 0; i < odds.response.Count; i++)
            {
                DateTime dateWhole = odds.response[i].fixture.date;

                //verify if the match is in the list of days we accept
                for (int j = 0; j < listDays.Count; j++)
                {
                    //the match need to be in the day we accept and the match need to be after the current hour and minute
                    if (dateWhole.Day == listDays[j].Day && dateWhole.Month == listDays[j].Month && dateWhole.Year == listDays[j].Year)
                    {
                        if (dateWhole.Hour > DateTime.Now.Hour)
                        {
                            ValidMatch.Add(odds.response[i]);
                        }
                        else if (dateWhole.Hour == DateTime.Now.Hour)
                        {
                            if (dateWhole.Minute > DateTime.Now.Minute)
                            {
                                ValidMatch.Add(odds.response[i]);
                            }
                        }

                    }
                }
            }
            //get the data we needs from each match
            for (int i = 0; i < ValidMatch.Count; i++)
            {
                result = getFixtures(ValidMatch[i].fixture.id.ToString());
                if (result == "success")
                {
                    match = new DisplayedMatch();

                    //we got enought data only if there's more than 10 odds available
                    if (ValidMatch[i].bookmakers[idBookmaker].bets.Count > 10)
                    {
                        match = new DisplayedMatch();
                        
                        match.id = ValidMatch[i].fixture.id;
                        match.league = fixturesroot.response[0].league.name;
                        match.leagueCountry = fixturesroot.response[0].league.country;
                        match.leagueLogo = fixturesroot.response[0].league.logo;

                        match.startHour = fixturesroot.response[0].fixture.date.ToString("HH:mm");
                        match.date = fixturesroot.response[0].fixture.date.ToString("yyyy-MM-dd");
                        match.team1 = fixturesroot.response[0].teams.home.name;
                        match.logoTeame1 = fixturesroot.response[0].teams.home.logo;
                        match.team2 = fixturesroot.response[0].teams.away.name;
                        match.logoTeame2 = fixturesroot.response[0].teams.away.logo;
                        match.status = fixturesroot.response[0].fixture.status.@long;
                        match.oddsName = ValidMatch[i].bookmakers[idBookmaker].bets[0].name;
                        match.odds1 = double.Parse(ValidMatch[i].bookmakers[idBookmaker].bets[0].values[0].odd.Replace(".", ","));
                        match.odds2 = double.Parse(ValidMatch[i].bookmakers[idBookmaker].bets[2].values[0].odd.Replace(".", ","));
                        match.oddsN = double.Parse(ValidMatch[i].bookmakers[idBookmaker].bets[1].values[0].odd.Replace(".", ","));


                        int nbr_pari_scorExact = ValidMatch[i].bookmakers[idBookmaker].bets[10].values.Count;
                        for (int j = 0; j < nbr_pari_scorExact; j++)
                        {

                            string value_exactScore = ValidMatch[i].bookmakers[idBookmaker].bets[10].values[j].value.ToString();
                            
                            switch (value_exactScore)
                            {
                                case "0:0":
                                    match.exactScore0_0 = double.Parse(ValidMatch[i].bookmakers[idBookmaker].bets[10].values[j].odd.Replace(".", ","));
                                    break;
                                case "1:0":
                                    match.exactScore1_0 = double.Parse(ValidMatch[i].bookmakers[idBookmaker].bets[10].values[j].odd.Replace(".", ","));
                                    break;
                                case "2:0":
                                    match.exactScore2_0 = double.Parse(ValidMatch[i].bookmakers[idBookmaker].bets[10].values[j].odd.Replace(".", ","));
                                    break;
                                case "1:1":
                                    match.exactScore1_1 = double.Parse(ValidMatch[i].bookmakers[idBookmaker].bets[10].values[j].odd.Replace(".", ","));
                                    break;
                                case "2:2":
                                    match.exactScore2_2 = double.Parse(ValidMatch[i].bookmakers[idBookmaker].bets[10].values[j].odd.Replace(".", ","));
                                    break;
                                case "2:1":
                                    match.exactScore2_1 = double.Parse(ValidMatch[i].bookmakers[idBookmaker].bets[10].values[j].odd.Replace(".", ","));
                                    break;
                                case "0:1":
                                    match.exactScore0_1 = double.Parse(ValidMatch[i].bookmakers[idBookmaker].bets[10].values[j].odd.Replace(".", ","));
                                    break;
                                case "0:2":
                                    match.exactScore0_2 = double.Parse(ValidMatch[i].bookmakers[idBookmaker].bets[10].values[j].odd.Replace(".", ","));
                                    break;
                                case "1:2":
                                    match.exactScore1_2 = double.Parse(ValidMatch[i].bookmakers[idBookmaker].bets[10].values[j].odd.Replace(".", ","));
                                    break;
                                default:
                                    //instruction
                                    break;
                            }
                        }
                        match.BothTeamsScoreYes = double.Parse(ValidMatch[i].bookmakers[idBookmaker].bets[8].values[0].odd.Replace(".", ","));
                        match.BothTeamsScoreNo = double.Parse(ValidMatch[i].bookmakers[idBookmaker].bets[8].values[1].odd.Replace(".", ","));

                        dataMatch.match.Add(match);
                    }
                }
                else
                {
                    state = "failed request fixtures";
                }
            }
            //dataMatch.match sort by DateTime
            dataMatch.match.Sort((x, y) => DateTime.Compare(DateTime.Parse(x.date), DateTime.Parse(y.date)));
            
            saveMatchData();
            //write in a dynamic name json file
        }
        
        public void MinRequestLeft(int minusNumber)
        {
            //fonction qui permet de determiner le nombre de requete encore possible pour l'api
            //a comme parametre minusnumber qui corespond au nombre de requete fait a l'instant

            requestLeft -= minusNumber;
        }

        public void saveNewBets(List<DisplayedListBet> bets)
        {
            //get every user's bets
            string content = _getUsersBets.getAllUsersBets();
            displaylistBets = JsonConvert.DeserializeObject<DisplayedListBets>(content);

            //check if user exist
            bool userExist = false;
            int indexUser = 0;

            //find is this user aleready have bets !!BUG 
            for (int i = 0; i < displaylistBets.bets.Count; i++)
            {
                if (displaylistBets.bets[i].idUser == idUser)
                {
                    userExist = true;
                    indexUser = i;
                }
            }

            if (userExist)
            {
                //add new bets to user's bets
                foreach (DisplayedListBet bet in bets)
                {
                    displaylistBets.bets[indexUser].listBets.Add(bet);
                }
            }
            else
            {
                //create new item in list of bets
                DisplayedListBet DisplayedListBetbetToAdd;
                DisplayedBet betToAdd;
                betToAdd = new DisplayedBet();
                DisplayedListBetbetToAdd = new DisplayedListBet();
                betToAdd.idUser = idUser;
                betToAdd.listBets = new List<DisplayedListBet>();
                foreach (DisplayedListBet bet in bets)
                {
                    betToAdd.listBets.Add(bet);
                }

                displaylistBets.bets.Add(betToAdd);
            }

            //write new bets in file json
            string json = JsonConvert.SerializeObject(displaylistBets);
            writeJsonFile("../../../Resource/bdd/bet.json", json);
        }

        public void saveBets(List<DisplayedListBet> bets)
        {
            //get every usedr's bets
            string content = _getUsersBets.getAllUsersBets();
            displaylistBets = JsonConvert.DeserializeObject<DisplayedListBets>(content);
            //check if user exist
            int indexUser = 0;

            // find is this user aleready have bets
            for (int i = 0; i < displaylistBets.bets.Count; i++)
            {
                if (displaylistBets.bets[i].idUser == idUser)
                {
                    indexUser = i;
                }
            }

            //add new bets to user's bets
            displaylistBets.bets[indexUser].listBets = bets;

            //write new bets in file json
            string json = JsonConvert.SerializeObject(displaylistBets);
            writeJsonFile("../../../Resource/bdd/bet.json", json);
        }

        public void writeJsonFile(string pathFile, string content)
        {
            //fonction qui permet d'ecrire le contenue du lien dans le fichier json
            File.WriteAllText(pathFile, content);
        }
        
        public DisplayedListBet checkBet(DisplayedListBet bet)
        {

            result = getFixtures(bet.idFixture.ToString());
            //check if the match is end
            if (fixturesroot.response[0].fixture.status.@long == "Match Finished")
            {
                //check the result of the match
                string exactResult = fixturesroot.response[0].score.fulltime.home + " - " + fixturesroot.response[0].score.fulltime.away;
                bet.finalScore = exactResult;
                if (bet.idBets == 1)
                {
                    //check who wins the match and compare with the bet
                    if (fixturesroot.response[0].teams.home.winner == true &&
                        bet.userBet == fixturesroot.response[0].teams.home.name)
                    {
                        bet.statusBet = "win";
                    }
                    else if (fixturesroot.response[0].teams.away.winner == true &&
                             bet.userBet == fixturesroot.response[0].teams.away.name)
                    {
                        bet.statusBet = "win";
                    }
                    else if (fixturesroot.response[0].teams.home.winner == false &&
                             fixturesroot.response[0].teams.away.winner == false &&
                             bet.userBet == "Nul")
                    {
                        bet.statusBet = "win";
                    }
                    else
                    {
                        bet.statusBet = "lose";
                    }
                }
                else if (bet.idBets == 10)
                {
                    switch (exactResult)
                    {
                        case "0 - 0":
                            bet.statusBet = bet.userBet == "0:0" ? "win" : "lose";
                            break;
                        case "1 - 1":
                            bet.statusBet = bet.userBet == "1:1" ? "win" : "lose";
                            break;
                        case "2 - 2":
                            bet.statusBet = bet.userBet == "2:2" ? "win" : "lose";
                            break;
                        case "0 - 1":
                            bet.statusBet = bet.userBet == "0:1" ? "win" : "lose";
                            break;
                        case "0 - 2":
                            bet.statusBet = bet.userBet == "0:2" ? "win" : "lose";
                            break;
                        case "1 - 2":
                            bet.statusBet = bet.userBet == "1:2" ? "win" : "lose";
                            break;
                        case "1 - 0":
                            bet.statusBet = bet.userBet == "1:0" ? "win" : "lose";
                            break;
                        case "2 - 0":
                            bet.statusBet = bet.userBet == "2:0" ? "win" : "lose";
                            break;
                        case "2 - 1":
                            bet.statusBet = bet.userBet == "2:1" ? "win" : "lose";
                            break;
                        default:
                            bet.statusBet = "lose";
                            break;
                    }
                }
                else if (bet.idBets == 8)
                {
                     //check if both team score
                     if (fixturesroot.response[0].score.fulltime is { home: > 0, away: > 0 })
                     {
                         bet.statusBet = bet.userBet == "YES" ? "win" : "lose";
                     }
                     else
                     {
                         bet.statusBet = bet.userBet == "NO" ? "win" : "lose";
                     }
                }
            }
            //return the bet with the result of the match or not if not finished
            return bet;
        }

        #region getAsynchdata

        public string getStatus()
        {
            //fonction qui permet d'obtenir les info sur le statut de notre compte sur l'api 
            //notament si on peut encore faire des requete
            
            var asyncTask = Task.Run(async () => await rawMatchData.GetStatus("status"));
            asyncTask.Wait();
            var asyncResult = asyncTask.Result;
            result = deserializeStatus(asyncResult.ToString());
            return result;
        }

        public string getCurrentLeague()
        {
            //fonction qui permet d'obtenir les info sur les league disponible dans l'api

            var asyncTaskLeague = Task.Run(async () => await rawMatchData.GetCurrentLeague("leagues?season=2022&current=true"));
            asyncTaskLeague.Wait();
            var asyncResultLeague = asyncTaskLeague.Result;
            result = deserializeLeagues(asyncResultLeague.ToString());
            return result;
        }

        public string getOdds(string id)
        {
            //fonction qui permet d'obtenir les info sur les match disponible dans la league choisi dans l'api

            var asyncTaskOddsL1 = Task.Run(async () => await rawMatchData.GetOdds("odds?season=2022&bookmaker=1&league=", id));
            asyncTaskOddsL1.Wait();
            var asyncResultOddsL1 = asyncTaskOddsL1.Result;
            result = deserializeOdds(asyncResultOddsL1.ToString());
            return result;
        }

        public string getFixtures(string id)
        {
            //fonction qui permet d'obtenir les info sur le match choisi qui se trouve dans la league choisi disponible dans l'api

            var asyncTaskFixturesroot = Task.Run(async () => await rawMatchData.GetFixture("fixtures?id=", id));
            asyncTaskFixturesroot.Wait();
            var asyncResultFixturesroot = asyncTaskFixturesroot.Result;
            result = deserializeFixturesroot(asyncResultFixturesroot.ToString());
            return result;
        }

        #endregion
        #region deserialize

        private string deserializeStatus(string content)
        {
            //fonction qui permet de deserialiser les donner obtenue precedament afin d'obtenir des classe d'objet avec 
            //les valeur
            //return si la deserialisation a etait un succes ou pas
            
            status = JsonConvert.DeserializeObject<Status>(content);
            
            if (content == "error" || status.errors.Count > 0)
            {
                return "error";
            }

            return "success";
        }

        private string deserializeLeagues(string content)
        {
            //fonction qui permet de deserialiser les donner obtenue precedament afin d'obtenir des classe d'objet avec 
            //les valeur
            //return si la deserialisation a etait un succes ou pas
            
            currentleague = JsonConvert.DeserializeObject<CurrentLeague>(content);
            if (content == "error" || status.errors.Count > 0)
            {
                return "error";
            }

            return "success";
        }

        private string deserializeOdds(string content)
        {
            //fonction qui permet de deserialiser les donner obtenue precedament afin d'obtenir des classe d'objet avec 
            //les valeur
            //return si la deserialisation a etait un succes ou pas
            
            odds = JsonConvert.DeserializeObject<Odds>(content);
            if (content == "error" || status.errors.Count > 0)
            {
                return "error";
            }

            return "success";
        }

        private string deserializeFixturesroot(string content)
        {
            //fonction qui permet de deserialiser les donner obtenue precedament afin d'obtenir des classe d'objet avec 
            //les valeur
            //return si la deserialisation a etait un succes ou pas
            
            fixturesroot = JsonConvert.DeserializeObject<FixturesRoot>(content);
            if (content == "error")
            {
                return "error";
            }

            return "success";
        }

        #endregion
    }
}
