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

using System.Configuration;


namespace SouliereTrehou_parisSportif.View
{
    /// <summary>
    /// Logique d'interaction pour uc_home.xaml
    /// </summary>
    public partial class uc_home : UserControl
    {
        public uc_home()
        {
            InitializeComponent();
            //open the snackbar by default (pop-up)
            SnackbarFive.IsActive = true;

        }
        private void SnackbarMessage_ActionClick(object sender, RoutedEventArgs e)
        {
            // Code to execute when the action button is clicked. so you can close the snackbar
            SnackbarFive.IsActive = false;
        }
    }
}
