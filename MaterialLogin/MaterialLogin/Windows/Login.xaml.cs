using MaterialLogin.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
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

namespace MaterialLogin
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        LoginHandler loginHandler = new LoginHandler("admin", "admin");

        public Login()
        {
            InitializeComponent();
        }

        private void BtnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void BtnUloguj_Click(object sender, RoutedEventArgs e)
        {
            String user = txtKorisnik.Text;
            String pass = passLozinka.Password;

            if (loginHandler.IsLoginIn(user, pass))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                Close();
            } else
            {
                SnackbarOne.IsActive = true;
                txtKorisnik.Text = null;
                passLozinka.Password = null;
            }
           
         }
    }


}

