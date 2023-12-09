using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

using System.Collections.ObjectModel;
using SouliereTrehou_parisSportif.Service.bet;
using SouliereTrehou_parisSportif.Service.user;
using Newtonsoft.Json;
using SouliereTrehou_parisSportif.Modele.bet;
using SouliereTrehou_parisSportif.Modele.user;
using System.Configuration;
using System.Net;

namespace SouliereTrehou_parisSportif.View.user
{
    /// <summary>
    /// Logique d'interaction pour uc_user_allBets.xaml
    /// </summary>
    public partial class uc_user_allBets : UserControl
    {
        //Declaration des variables
        public ObservableCollection<DisplayedListBet> betsInProgress { get; set; } = new ObservableCollection<DisplayedListBet>();
        public ObservableCollection<DisplayedListBet> betsWins { get; set; } = new ObservableCollection<DisplayedListBet>();
        public ObservableCollection<DisplayedListBet> betsList { get; set; } = new ObservableCollection<DisplayedListBet>();

        ControlUser controlUser;
        AuthUser login;
        DisplayedBet userBets;
        User user;
        Bets bets;
        
        int idUser;
        public uc_user_allBets()
        {
            InitializeComponent();
            controlUser = new ControlUser();
            login = new AuthUser();
            bets = new Bets();
            idUser = int.Parse(ConfigurationManager.AppSettings["userConnected"]);

            user = login.getUserDataFromID(idUser);
            userBets = controlUser.getUserBets(idUser);

            // On parcours la liste des paris de l'utilisateur
            if (userBets.listBets != null)
            {
                double moneyToAdd = 0;
                for (int i = 0; i < userBets.listBets.Count; i++)
                {
                    //Verifie si le pari n'as pas encore ete verifie ou le match n'as pas eu lieu 
                    //Si oui on l'ajoute a la liste des paris en cours et verifie si le match est fini ou non
                    if (userBets.listBets[i].statusBet == "pending")
                    {
                        DateTime date = DateTime.Parse(userBets.listBets[i].date);
                        if (date < DateTime.Now)
                        {
                            userBets.listBets[i] = checkBet(userBets.listBets[i]);

                           
                            if (userBets.listBets[i].statusBet == "win")
                            {
                                moneyToAdd += userBets.listBets[i].gain;
                            }

                        }
                    }
                    //range le paris dans la bonne liste
                    if (userBets.listBets[i].statusBet == "win")
                    {
                        betsWins.Add(userBets.listBets[i]);
                    }
                    else if (userBets.listBets[i].statusBet == "pending")
                    {
                        betsInProgress.Add(userBets.listBets[i]);
                    }

                    betsList.Add(userBets.listBets[i]);
                }

                user.balance += moneyToAdd;
                controlUser.editUser(user);
            }
            else
            {
                MessageBox.Show("Aucun pari enregistré", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
            bets.saveBets(userBets.listBets);
            this.DataContext = this;

        }
        private DisplayedListBet checkBet(DisplayedListBet betToCheck)
        {
            // On recupere le resultat du match
            DisplayedListBet bet = bets.checkBet(betToCheck);
            return bet;
        }
    }
}
