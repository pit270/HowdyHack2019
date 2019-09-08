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
    /// Interaction logic for Participant.xaml
    /// </summary>
    public partial class Participant : Window
    {
        string usr;
        bool surveyTaken;
        Window parent;
        OleDbConnection connection;
        public Participant()
        {
            InitializeComponent();
            connection = new OleDbConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["HowdyHack2019.Properties.Settings.hackrDBConnectionString"].ToString();
            surveyTaken = hasTakenSurvey();
            Console.WriteLine(surveyTaken);
            if (!surveyTaken) surveyBtn.IsEnabled = true;
        }

        public Participant(Window parent, string usr)
        {
            this.usr = usr;
            this.parent = parent;
            InitializeComponent();
            connection = new OleDbConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["HowdyHack2019.Properties.Settings.hackrDBConnectionString"].ToString();
            surveyTaken = hasTakenSurvey();
            Console.WriteLine(surveyTaken);
            if (!surveyTaken) surveyBtn.IsEnabled = true;
        }

        private bool hasTakenSurvey()
        {
            connection.Open();
            string query = "SELECT username FROM responses WHERE username='" + usr + "'";
            Console.WriteLine(query);
            OleDbCommand command = new OleDbCommand();
            command.CommandText = query;
            command.Connection = connection;

            OleDbDataReader reader = command.ExecuteReader();

            string storedUsr = "";
            while (reader.Read())
            {
                storedUsr = reader.GetString(0);
            }
            reader.Close();
            connection.Close();
            Console.WriteLine("stored: " + storedUsr + "\tself: " + usr);
            if (storedUsr.Equals(usr)) return true;
            else return false;
        }

        private void SurveyBtn_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Survey(this, usr);
            window.Show();
            this.Hide();
        }
        
    }
}
