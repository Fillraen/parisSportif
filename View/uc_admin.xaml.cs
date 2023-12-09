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
using SouliereTrehou_parisSportif.Modele.user;
using SouliereTrehou_parisSportif.Service.user;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Configuration;

namespace SouliereTrehou_parisSportif.View
{
    /// <summary>
    /// Logique d'interaction pour uc_admin.xaml
    /// </summary>
    public partial class uc_admin : UserControl
    {
        //Declaration des variables
        public int numberOfDay { get; set; }
        public string iDBookmakers { get; set; }
        public ObservableCollection<User> ListUsers { get; set; } = new ObservableCollection<User>();

        ControlUser controlUser;
        AuthUser login;
        private int idUser;
        public uc_admin()
        {
            InitializeComponent();
            login = new AuthUser();
            idUser = int.Parse(ConfigurationManager.AppSettings["userConnected"]);
            controlUser = new ControlUser();
            updateUsers();

            SP_addUser.Visibility = Visibility.Hidden;


            //On recupere le nombre de jour et de bookmakers
            numberOfDay = int.Parse(ConfigurationManager.AppSettings["day"]);
            iDBookmakers = ConfigurationManager.AppSettings["bookmakers"];

            //Si jamais il y a un reset de l'app Config decommenter les lignes suivantes changez les options et commentez les lignes suivantes
            //numberOfDay = 5;
            //iDBookmakers = "0";

            //On affiche le nombre de jour et de bookmakers
            switch (numberOfDay)
            {
                case 1:
                    btn_day_1.IsChecked = true;
                    break;
                case 2:
                    btn_day_2.IsChecked = true;
                    break;
                case 3:
                    btn_day_3.IsChecked = true;
                    break;
                case 4:
                    btn_day_4.IsChecked = true;
                    break;
                case 5:
                    btn_day_5.IsChecked = true;
                    break;
            }

            //select the first bookmaker by default 
            //DONT FORGET TO CHANGE THE INDEX IF YOU ADD A BOOKMAKER AND MAKE IT BY DEFAULT
            Cb_bookmakers.SelectedIndex = 0;
        }
        private void editUser(object sender, RoutedEventArgs e)
        {
            SP_addUser.Visibility = Visibility.Visible;
            //On recupere l'id de l'utilisateur selectionne
            //et affiche les infos a modifier
            var user = (sender as Button).DataContext as User;
            //write data in the form on the left
            LB_editId.Content = user.id;
            TB_editUsername.Text = user.name;
            TB_editEmail.Text = user.email;
            CB_editPerm.Text = user.permission;
            TB_editBalance.Text = user.balance.ToString();
            PB_editPassword.Password = user.password;

            
        }
        private void editUserSubmit(object sender, RoutedEventArgs e)
        {
            //Veririe que les champs ne sont pas vide
            if (TB_editUsername.Text != "" && TB_editEmail.Text != "" && CB_editPerm.Text != "" && TB_editBalance.Text != "" && PB_editPassword.Password != "")
            {
                //remplace les donnees de l'utilisateur par les nouvelles
                User user = new User()
                {
                    id = int.Parse(LB_editId.Content.ToString()),
                    name = TB_editUsername.Text,
                    email = TB_editEmail.Text,
                    permission = CB_editPerm.Text,
                    password = PB_editPassword.Password,
                    //verifier balance bon format
                    balance = double.Parse(TB_editBalance.Text)
                };

                //Si le mot de passe a ete modifie on le modifie sinon on ne le modifie pas
                bool passModified;
                if (MaterialDesignOutlinedPasswordBoxEnabledComboBox.IsChecked == true)
                {
                    passModified = true;
                }
                else
                {
                    passModified = false;
                }
                controlUser.editUser(user, passModified);
                updateUsers();
                infoMsgBox("Edition de l'utilisateur " + user.name + " effectuée");

                TB_editBalance.Text = "";
                TB_editEmail.Text = "";
                TB_editUsername.Text = "";
                PB_editPassword.Password = "";
                CB_editPerm.Text = "";

                SP_addUser.Visibility = Visibility.Hidden;
            }
            else
            {
                infoMsgBox("Vérifier que vous avez bien remplie tout les champs");
            } 
        }
        private void deleteUser(object sender, RoutedEventArgs e)
        {
            // On recupere l'id de l'utilisateur selectionne et on le supprime
            var user = (sender as Button).DataContext as User;

            controlUser.deleteUser(user.id);
            updateUsers();
            infoMsgBox("Supression de l'utilisateur " + user.name + " effectuée");
        }

        private void addUser(object sender, RoutedEventArgs e)
        {
            //creer un nouvel utilisateur et l'ajoute a la liste des utilisateurs 
            if (TB_username.Text == "" || TB_email.Text == "" || CB_Perm.Text == "" || PB_password.Password == "")
            {
                infoMsgBox("Vérifier que vous avez bien remplie tout les champs");
            }
            else
            {
                controlUser.addUser(TB_username.Text, TB_email.Text, CB_Perm.Text, PB_password.Password);
                updateUsers();
                infoMsgBox("Ajout de l'utilisateur " + TB_username.Text + " effectuée");
                tabControl.SelectedIndex = 0;
                TB_username.Text = "";
                TB_email.Text = "";
                CB_Perm.Text = "";
                PB_password.Password = "";
            }
        }

        private void updateUsers()
        {
            //On recupere la liste des utilisateurs et on l'affiche (permet de rafraichir les informations s'il y a eu des changements
            ListUsers.Clear();
            ListUsers users = controlUser.getAllUsers();
            for (int i = 0; i < users.user.Count; i++)
            {
                ListUsers.Add(users.user[i]);
            }

            this.DataContext = this;
        }
        private void infoMsgBox(string content)
        {
            //Affiche une message box avec le contenu en parametre
            MessageBox.Show(content
                          , "Paris Sportif"
                          , MessageBoxButton.OK
                          , MessageBoxImage.Information);
        }

        private void btn_day_Click(object sender, RoutedEventArgs e)
        {
            // On recupere le bouton selectionne et on change la valeur de numberOfDay (jour de prevision sur les matchs
            RadioButton btn = sender as RadioButton;
            btn.IsChecked = true;
            switch (btn.Name)
            {
                case "btn_day_1":
                    numberOfDay = 1;
                    break;
                case "btn_day_2":
                    numberOfDay = 2;
                    break;
                case "btn_day_3":
                    numberOfDay = 3;
                    break;
                case "btn_day_4":
                    numberOfDay = 4;
                    break;
                case "btn_day_5":
                    numberOfDay = 5;
                    break;
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("day");
            config.AppSettings.Settings.Add("day", numberOfDay.ToString());
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("Settings");
        }
        private void Cb_Bookmaker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // On recupere le bookmaker selectionne et on change la valeur de iDBookmakers (id du bookmaker selectionne)
            string choiceBookmakers = Cb_bookmakers.SelectedValue.ToString();
            string[] arrayOfBookmakers = choiceBookmakers.Split(':');
            iDBookmakers = arrayOfBookmakers[1];
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("bookmakers");
            config.AppSettings.Settings.Add("bookmakers", iDBookmakers.ToString());
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("Settings");
        }
    }
}