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

using SouliereTrehou_parisSportif.Service.user;
using SouliereTrehou_parisSportif.Modele.user;

namespace SouliereTrehou_parisSportif
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isLogin = false;
        AuthUser login;
        public MainWindow()
        {
            InitializeComponent();

            login = new AuthUser();
            
            //if user is already logged in then open pariSportif
            if (login.Islogin())
            {
                isLogin = true;
                displayPariSportif();
            }
        }
        private void loginClick(object sender, RoutedEventArgs e)
        {
            //try to login the user with the given credentials
            isLogin = login.login(username.Text, password.Password);

            //if loggin true then open pariSportif else error
            if (isLogin)
            {
                displayPariSportif();
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect");
            }
        }

        private void displayPariSportif()
        {
            // display pari sportif window
            ParisSportif windowParis = new ParisSportif();
            windowParis.Show();
            this.Visibility = Visibility.Hidden;
        }
    }
}
