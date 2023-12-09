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
using System.Windows.Shapes;

using SouliereTrehou_parisSportif.Service.user;
using System.Configuration;
using SouliereTrehou_parisSportif.Modele.user;
using SouliereTrehou_parisSportif.View;
using SouliereTrehou_parisSportif.View.user;
using System.Windows.Threading;
using System.IO;

namespace SouliereTrehou_parisSportif
{
    /// <summary>
    /// Logique d'interaction pour ParisSportif.xaml
    /// </summary>
    public partial class ParisSportif : Window
    {
        AuthUser login;
        int idUser;
        public User user { get; set; } 
        
        public ParisSportif()
        {
            //get data from the user connected
            idUser = int.Parse(ConfigurationManager.AppSettings["userConnected"]);

            InitializeComponent();

            updateDataUser();
            //if the user is a admin we show the admin menu
            if (user.permission == "Admin")
            {
                MenuItemAdmin.Visibility = Visibility.Visible;
                MenuItemAdmin.IsEnabled = true;
            }
            else
            {
                MenuItemAdmin.Visibility = Visibility.Hidden;
                MenuItemAdmin.IsEnabled = false;
            }
            
            navigation();

            //setup a dispatcher timer
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        { 
            updateDataUser();
        }
        public void updateDataUser()
        {
            login = new AuthUser();
            user = login.getUserDataFromID(idUser);
            TB_Balance.Text = user.balance.ToString() + " €";
            TB_Pseudo.Text = user.name;
        }

        private void logOutClick(object sender, RoutedEventArgs e)
        {
            //logout the user
            login.logOut();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Visibility = Visibility.Hidden;

        }
        private void btnNavClick(object sender, RoutedEventArgs e)
        {
            //get the name of the button clicked and send it to the navigation function to display the right page
            MenuItem menuItem = sender as MenuItem;
            string name = menuItem.Name;
            navigation(name);
        }

        private void navigation(string page = "MenuItemHome")
        {
            //display the right page from the name of the button clicked
            Container.Children.Clear();
            switch (page)
            {
                case "MenuItemAdmin":
                    uc_admin adminListUser = new uc_admin();
                    Container.Children.Add(adminListUser);
                    break;
                case "MenuItemHome":
                    uc_home home = new uc_home();
                    Container.Children.Add(home);
                    break;
                case "MenuItemMatchs":
                    uc_match listMatchs = new uc_match();
                    Container.Children.Add(listMatchs);
                    break;
                case "MenuItemMyBets":
                    uc_user_allBets listParis = new uc_user_allBets();
                    Container.Children.Add(listParis);
                    break;
                case "MenuItemMyData":
                    uc_user_data myData = new uc_user_data();
                    Container.Children.Add(myData);
                    break;
            }
        }
    }
}
