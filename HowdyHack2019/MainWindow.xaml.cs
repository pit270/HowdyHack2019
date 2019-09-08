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
using System.Data.OleDb;
using System.Configuration;
using System.Security;

namespace HowdyHack2019
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection connection = new OleDbConnection();
        public MainWindow()
        {
            InitializeComponent();
            connection.Close();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["HowdyHack2019.Properties.Settings.hackrDBConnectionString"].ToString();
        }

        private void Label_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Window window = new Register();
            window.Show();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            
            connection.Open();
            //SELECT PassHash from Accounts WHERE username=<user>
            String queryString = "SELECT PassHash from Accounts WHERE username='" + usernametxt.Text + "'";
            Console.WriteLine(queryString);
            OleDbCommand command = new OleDbCommand();
            command.CommandText = queryString;
            command.Connection = connection;

            OleDbDataReader reader = command.ExecuteReader();

            int storedHash = 0;
            int passwordHash = passHash(passwordtxt.Text, usernametxt.Text.ToLower());
            while (reader.Read())
            {
                storedHash = reader.GetInt32(0);
            }
            Console.WriteLine("test");
            if(storedHash.Equals(passwordHash))
            {
                Window window = new Participant(this, usernametxt.Text);
                window.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
            // always call Close when done reading.
            reader.Close();
            connection.Close();
            return;
            
            
        }

        private int passHash(string pass, string usr)
        {
            Console.WriteLine(pass.GetHashCode() * usr.GetHashCode());
            return pass.GetHashCode() * usr.GetHashCode();
        }
    }
}
