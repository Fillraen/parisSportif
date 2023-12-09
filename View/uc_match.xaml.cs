using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Printing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SouliereTrehou_parisSportif.Modele.bet;
using SouliereTrehou_parisSportif.Modele.user;
using SouliereTrehou_parisSportif.Service.bet;
using SouliereTrehou_parisSportif.Service.user;

namespace SouliereTrehou_parisSportif.View
{
    /// <summary>
    /// Logique d'interaction pour uc_match.xaml
    /// </summary>
    public partial class uc_match : UserControl
    {
        //declaration des variables
        public ObservableCollection<DisplayedMatch> ListMatch { get; set; } = new ObservableCollection<DisplayedMatch>();
        public ObservableCollection<DisplayedListBet> ListBets { get; set; } = new ObservableCollection<DisplayedListBet>();
        public ObservableCollection<string> ListLeague { get; set; } = new ObservableCollection<string>();
        private double betsTotals;
        private double gainsTotals;
        Bets bets;
        User user;
        ControlUser controlUser;
        AuthUser login;
        int idUser;
        public uc_match()
        {
            InitializeComponent();
            login = new AuthUser();
            controlUser = new ControlUser();

            // on récupère les données de l'utilisateur connecté 
            idUser = int.Parse(ConfigurationManager.AppSettings["userConnected"]);
            user = login.getUserDataFromID(idUser);

            updateTotals();
            
            //initialisation des données des matchs et des leagues
            bets = new Bets();
            getListMatch();
            getListLeagues();

            this.DataContext = this;
        }

        private void getListLeagues()
        {
            // on récupère la liste des ligues
            ListLeague.Clear();
            ListLeague.Add("All");
            foreach (var league in ListMatch.Select(x => x.league).Distinct())
            {
                ListLeague.Add(league);
            }
            
        }
        private void CB_listLeagueChanged(object sender, SelectionChangedEventArgs e)
        {
            // on récupère la ligue sélectionnée et on filtre la liste des matchs
            ListDisplayedMatch newList = bets.dataMatch;
            ListMatch.Clear();
            if (CB_listLeague.SelectedItem.ToString() != "All")
            {
                foreach (DisplayedMatch match in newList.match)
                {
                    
                    if (match.league == CB_listLeague.SelectedItem.ToString())
                    {
                        ListMatch.Add(match);
                    }
                }
            }
            else
            {
                foreach (DisplayedMatch match in newList.match)
                {
                    ListMatch.Add(match);
                }
            }
            this.DataContext = this;
        }


        private void getListMatch()
        {
            //recuperer tout les match selected from Bets
            ListDisplayedMatch newList = bets.dataMatch;
            ListMatch.Clear();
            foreach (DisplayedMatch match in newList.match)
            {
                ListMatch.Add(match);
            }
        }
        private void btn_betWinner_Click(object sender, RoutedEventArgs e)
        {
            // Quand on clique sur le bouton de notre paris selectione on recupere les infos et on les affiche en plus compacte dans une liste a droite
            Button btn = sender as Button;
            DisplayedMatch match = btn.DataContext as DisplayedMatch;
            DisplayedListBet bet = new DisplayedListBet();

            bet.idFixture = match.id;

            bet.league = match.league;
            bet.leagueLogo = match.leagueLogo;

            bet.teamHome = match.team1;
            bet.logoTeamHome = match.logoTeame1;

            bet.teamAway = match.team2;
            bet.logoTeamAway = match.logoTeame2;

            bet.date = match.date + " " + match.startHour;
            bet.dateDay = match.date;
            bet.dateHour = match.startHour;

            bet.statusBet = "pending";

            switch (btn.Name)
            {
                case "btn_betWinner1":
                    bet.userBetTheme = "Match Winner";
                    bet.userBet = match.team1;// team 1 winner
                    bet.odds = match.odds1;
                    bet.idBets = 1;
                    break;
                case "btn_betWinner2":
                    bet.userBetTheme = "Match Winner";
                    bet.userBet = match.team2; // team 2 winner
                    bet.odds = match.odds2;
                    bet.idBets = 1;
                    break;
                case "btn_betWinnerN":
                    bet.userBetTheme = "Match Winner";
                    bet.userBet = "Nul";
                    bet.odds = match.oddsN;
                    bet.idBets = 1;
                    break;
                case "btn_exactScore0_0":
                    bet.userBetTheme = "Score Exacte";
                    bet.userBet = "0:0";
                    bet.odds = match.exactScore0_0;
                    bet.idBets = 10;
                    break;
                case "btn_exactScore1_0":
                    bet.userBetTheme = "Score Exacte";
                    bet.idBets = 10;
                    bet.userBet = "1:0";
                    bet.odds = match.exactScore1_0;
                    break;
                case "btn_exactScore2_0":
                    bet.userBetTheme = "Score Exacte";
                    bet.idBets = 10;
                    bet.userBet = "2:0";
                    bet.odds = match.exactScore2_0;
                    break;
                case "btn_exactScore0_2":
                    bet.userBetTheme = "Score Exacte";
                    bet.idBets = 10;
                    bet.userBet = "0:2";
                    bet.odds = match.exactScore0_2;
                    break;
                case "btn_exactScore0_1":
                    bet.userBetTheme = "Score Exacte";
                    bet.idBets = 10;
                    bet.userBet = "0:1";
                    bet.odds = match.exactScore0_1;
                    break;
                case "btn_exactScore1_1":
                    bet.userBetTheme = "Score Exacte";
                    bet.idBets = 10;
                    bet.userBet = "1:1";
                    bet.odds = match.exactScore1_1;
                    break;
                case "btn_exactScore2_2":
                    bet.userBetTheme = "Score Exacte";
                    bet.idBets = 10;
                    bet.userBet = "2:2";
                    bet.odds = match.exactScore2_2;
                    break;
                case "btn_exactScore2_1":
                    bet.userBetTheme = "Score Exacte";
                    bet.idBets = 10;
                    bet.userBet = "2:1";
                    bet.odds = match.exactScore2_1;
                    break;
                case "btn_exactScore1_2":
                    bet.userBetTheme = "Score Exacte";
                    bet.idBets = 10;
                    bet.userBet = "1:2";
                    bet.odds = match.exactScore1_2;
                    break;
                case "btn_BothTeamsScoreYes":
                    bet.userBetTheme = "Both Teams Score";
                    bet.userBet = "YES";
                    bet.odds = match.BothTeamsScoreYes;
                    bet.idBets = 8;
                    break;
                case "btn_BothTeamsScoreNo":
                    bet.userBetTheme = "Both Teams Score";
                    bet.userBet = "NO";
                    bet.odds = match.BothTeamsScoreNo;
                    bet.idBets = 8;
                    break;
            }
            bet.bet = 10;
            bet.gain = Math.Round(bet.bet * bet.odds, 2);
            
            //verifie que le pari n'est pas deja dans la liste
            if (ListBets.Where(x => x.idFixture == bet.idFixture &&
                               x.userBetTheme == bet.userBetTheme && 
                               x.userBet == bet.userBet).Count() == 0)
            {
                ListBets.Add(bet);
                SC_scroll.ScrollToHome();
                updateTotals();

                this.DataContext = this;
            }
        }

        private void updateTotals()
        {
            // on met a jour les totaux
            betsTotals = 0;
            gainsTotals = 0;
            for (int i = 0; i < ListBets.Count; i++)
            {
                betsTotals += ListBets[i].bet;
                gainsTotals += ListBets[i].gain;
            }
            Math.Round(gainsTotals, 2);
            Math.Round(betsTotals, 2);
            
            TB_allBets.Text = betsTotals.ToString() + " €";
            TB_allGains.Text = gainsTotals.ToString() + " €";
        }

        private void btn_deleteBet_Click(object sender, RoutedEventArgs e)
        {
            //supprime le pari de la liste
            Button btn = sender as Button;
            DisplayedListBet bet = btn.DataContext as DisplayedListBet;
            ListBets.Remove(bet);
            updateTotals();
            this.DataContext = this;
        }
        private void btn_clearAllBet_Click(object sender, RoutedEventArgs e)
        {
            //supprime tout les paris de la liste
            ListBets.Clear();
            updateTotals();
            this.DataContext = this;
        }
        
        private void btn_addBet_Click(object sender, RoutedEventArgs e)
        {
            //add 10€ to our bet
            Button btn = sender as Button;
            DisplayedListBet bet = btn.DataContext as DisplayedListBet;

            bet.bet += 10;
            bet.gain = Math.Round(bet.bet * bet.odds, 2);

            this.DataContext = this;

            // on force la mise a jour de la liste
            DG_listBets.CommitEdit();
            DG_listBets.CommitEdit();

            updateTotals();

        }
        private void btn_lessBet_Click(object sender, RoutedEventArgs e)
        {
            // remove 10€ to our bet
            Button btn = sender as Button;
            DisplayedListBet bet = btn.DataContext as DisplayedListBet;
            if (bet.bet > 10)
            {
                bet.bet -= 10;
                bet.gain = Math.Round(bet.bet * bet.odds, 2);

                this.DataContext = this;

                DG_listBets.CommitEdit();
                DG_listBets.CommitEdit();

                updateTotals();
                
            }
        }

        private void btn_saveBetsList_Click(object sender, RoutedEventArgs e)
        {
            //validate the list of bets and save it in the json file
            List<DisplayedListBet> list = new List<DisplayedListBet>();
            if (ListBets.Count > 0)
            {
                if (betsTotals > user.balance)
                {
                    MessageBox.Show("Solde insuffisant"
                        , "Paris Sportif"
                        , MessageBoxButton.OK
                        , MessageBoxImage.Error);
                }
                else
                {
                    
                    foreach (DisplayedListBet bet in ListBets)
                    {
                        list.Add(bet);
                    }

                    user.balance -= betsTotals;
                    controlUser.editUser(user);

                    bets.saveNewBets(list);
                    MessageBox.Show("Paris enregistré"
                        , "Paris Sportif"
                        , MessageBoxButton.OK
                        , MessageBoxImage.Information);
                    ListBets.Clear();

                    updateTotals();
                    this.DataContext = this;
                }
                
            }
            else
            {
                MessageBox.Show("Aucun paris enregistré"
                              , "Paris Sportif"
                              , MessageBoxButton.OK
                              , MessageBoxImage.Information);
            }
        }
    }
}
