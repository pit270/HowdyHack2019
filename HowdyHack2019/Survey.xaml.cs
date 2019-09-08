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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Survey : Window
    {
        Window parent;
        string usr;
        OleDbConnection connection;
        public Survey(Window parent, string usr)
        {
            this.parent = parent;
            this.usr = usr;
            connection = new OleDbConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["HowdyHack2019.Properties.Settings.hackrDBConnectionString"].ToString();
            InitializeComponent();

        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string language = languageComboBox.SelectedItem.ToString();
            /* string language = e.AddedItems[0].ToString();

              switch(language)
              {
                  case "C":
                      break;
                  case "C++":
                      break;
                  case "C#":
                      break;
                  case "Java":
                      break;
                  case "JavaScript":
                      break;
                  case "Python":
                      break;
                  case "Ruby":
                      break;
                  case "Swift":
                      break;
                  case "Go":
                      break;
              }*/
            //store value in actual csv file
            Console.WriteLine(language);
        }


        private void Years_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double ExperienceValue = years.Value;
            Console.WriteLine(ExperienceValue);
        }

        private void GradeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string grade = gradeComboBox.SelectedItem.ToString();
            Console.WriteLine(grade);
        }


        private void LearnComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string learn = learnComboBox.SelectedItem.ToString();
            Console.WriteLine(learn);
        }

        private void TeachComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string teach = teachComboBox.SelectedItem.ToString();
            Console.WriteLine(teach);
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if(hasTakenSurvey())
            {
                MessageBox.Show("Your response is already recorded");
                return;
            }
            Random random = new Random();
            int rand = random.Next();
            string query = $"INSERT INTO responses VALUES ('{rand}','{usr}','{gradeComboBox.Text}','{years.Value}','{teachComboBox.Text.Equals("Yes") }','{learnComboBox.Text.Equals("Yes")}','{languageComboBox.Text}')";
            Console.WriteLine(query);
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.CommandText = query;
            command.Connection = connection;

            int a = command.ExecuteNonQuery();
            //command.ExecuteReader();
            if (a != 1) MessageBox.Show("Insertion error. " + a);
            //Console.WriteLine(a);
            connection.Close();
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

        protected override void OnClosed(EventArgs e)
        {
            parent.Show();
        }
    }
}
