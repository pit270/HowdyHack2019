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
using System.Data.OleDb;
using System.Configuration;

namespace HowdyHack2019
{ 
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        OleDbConnection connection;
        public Register()
        {
            connection = new OleDbConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["HowdyHack2019.Properties.Settings.hackrDBConnectionString"].ToString();
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            Random random = new Random();
            int r = random.Next();
            string query = $"INSERT INTO Accounts VALUES('{r}','{TbxUsername.Text}','{TbxEmail.Text}','{((bool)rdbPart.IsChecked ? 0 : 1)}','{passHash(TbxPassword.Text, TbxUsername.Text)}')";
            Console.WriteLine(query);
            OleDbCommand command = new OleDbCommand();
            command.CommandText = query;
            command.Connection = connection;

            int a = command.ExecuteNonQuery();
            //command.ExecuteReader();
            if (a != 1) MessageBox.Show("Insertion error. " + a);
            //Console.WriteLine(a);
            connection.Close();
            this.Close();
        }

        private int passHash(string pass, string usr)
        {
            Console.WriteLine(pass.GetHashCode() * usr.GetHashCode());
            return pass.GetHashCode() * usr.GetHashCode();
        }
    }
}
