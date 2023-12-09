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

using SouliereTrehou_parisSportif.View;
using System.Configuration;
using SouliereTrehou_parisSportif.Service.user;
using SouliereTrehou_parisSportif.Modele.user;


namespace SouliereTrehou_parisSportif.View.user
{
    /// <summary>
    /// Logique d'interaction pour uc_user_data.xaml
    /// </summary>
    public partial class uc_user_data : UserControl
    {
        AuthUser login;
        int idUser;
        User user;
        ControlUser controlUser;

        public uc_user_data()
        {
            InitializeComponent();
            controlUser =new ControlUser();
            login = new AuthUser();
            // Récupération de l'id de l'utilisateur connecté puis récupération des données de l'utilisateur
            idUser = int.Parse(ConfigurationManager.AppSettings["userConnected"]);
            user = login.getUserDataFromID(idUser);
            
            // Affichage des données de l'utilisateur
            TB_email.Text = user.email;
            PB_Password.Password = user.password;
            TB_Perm.Text = user.permission;
            TB_username.Text = user.name;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Modification des données de l'utilisateur
            
            bool infoBt = false;
            Button btn = sender as Button;

            //Si le bouton cliqué est le bouton de modification du mot de passe alors le mot de passe est modifié sinon il ne l'est pas
            if (btn.Name == "bt_mp")
            {
                user.password = PB_Password.Password;
                infoBt = true;
            }

            user.name = TB_username.Text;
            user.email = TB_email.Text;
            
            controlUser.editUser(user,infoBt);
            
            MessageBox.Show("Modification effectuée"
                , "Paris Sportif"
                , MessageBoxButton.OK
                , MessageBoxImage.Information);
        }
    }
}
