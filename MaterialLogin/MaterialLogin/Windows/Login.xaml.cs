
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

            SQLiteConnection connection = new SQLiteConnection("Data Source=dbEducons.db;Version=3;");
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {
                String query = "select count(1) from users where user=@korisnik and password=@sifra";
                SQLiteCommand command = new SQLiteCommand(query, connection);

                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@korisnik", txtKorisnik.Text);
                command.Parameters.AddWithValue("@sifra", passLozinka.Password);
                int count = Convert.ToInt32(command.ExecuteScalar());

                if(count == 1)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();

                } else
                {
                    SnackbarOne.IsActive = true;
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                connection.Close();
            }


           
         }
    }


}

