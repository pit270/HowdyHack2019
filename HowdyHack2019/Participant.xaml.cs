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
using System.Windows.Controls.Primitives;

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
            if (!surveyTaken)
            {
                surveyBtn.IsEnabled = true;
                calculateBtn.IsEnabled = false;
            }
            else
            {
                surveyBtn.IsEnabled = false;
                calculateBtn.IsEnabled = true;
            }
            //calculateBtn.IsEnabled = true;
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
            if (!surveyTaken)
            {
                surveyBtn.IsEnabled = true;
                calculateBtn.IsEnabled = false;
            }
            else
            {
                surveyBtn.IsEnabled = false;
                calculateBtn.IsEnabled = true;
            }
            //calculateBtn.IsEnabled = true;
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
            _shown = false;
        }

        protected override void OnClosed(EventArgs e)
        {
            parent.Show();
        }

        bool _shown;
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            if (_shown)
                return;

            _shown = true;

            surveyTaken = hasTakenSurvey();
            if (!surveyTaken)
            {
                surveyBtn.IsEnabled = true;
                calculateBtn.IsEnabled = false;
            }
            else
            {
                surveyBtn.IsEnabled = false;
                calculateBtn.IsEnabled = true;
            }
            //calculateBtn.IsEnabled = true;
        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            string query = "SELECT * FROM responses";
            List<ParticipantData> participantDatas = new List<ParticipantData>();
            OleDbCommand command = new OleDbCommand();
            command.CommandText = query;
            command.Connection = connection;
            ParticipantData self = new ParticipantData();
            OleDbDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                ParticipantData participantData = new ParticipantData();
                participantData.username = reader.GetString(1);
                
                participantData.programmingExperience = reader.GetInt32(3);
                participantData.wantsToTeach = (reader.GetString(4).Equals("True")) ? true : false;
                participantData.wantsToLearn = (reader.GetString(5).Equals("True")) ? true : false;
                participantData.preferredLang = reader.GetString(6);
                string grade = reader.GetString(2);
                if (grade.Equals("Freshman")) participantData.grade = 1;
                else if (grade.Equals("Sophmore")) participantData.grade = 2;
                else if (grade.Equals("Junior")) participantData.grade = 3;
                else if (grade.Equals("Senior")) participantData.grade = 4;
                if (participantData.username.Equals(usr))
                {
                    self = participantData;
                    continue;
                }
                participantDatas.Add(participantData);
                Console.WriteLine();
            }

            reader.Close();
            connection.Close();

            foreach(ParticipantData p in participantDatas)
            {
                p.score = p.match(self);
            }

         
            participantDatas.Sort();
            data.Children.Clear();
            foreach (ParticipantData p in participantDatas)
            {
                UniformGrid uniformGrid = new UniformGrid();
                uniformGrid.Rows = 1;
                Label label1 = new Label(); label1.Content = p.username; label1.FontWeight = FontWeights.Bold;
                Label label2 = new Label(); label2.Content = p.score;
                Label label3 = new Label(); label3.Content = p.grade;
                Label label4 = new Label(); label4.Content = p.programmingExperience;
                Label label5 = new Label(); label5.Content = p.wantsToLearn;
                Label label6 = new Label(); label6.Content = p.wantsToTeach;
                Label label7 = new Label(); label7.Content = p.preferredLang;
                uniformGrid.Dispatcher.Invoke(() =>
                {
                    uniformGrid.Children.Add(label1);
                    uniformGrid.Children.Add(label2);
                    uniformGrid.Children.Add(label3);
                    uniformGrid.Children.Add(label4);
                    uniformGrid.Children.Add(label5);
                    uniformGrid.Children.Add(label6);
                    uniformGrid.Children.Add(label7);
                });
                data.Dispatcher.Invoke(() =>
                {
                    
                    data.Children.Add(uniformGrid);
                });
            }

            
        }
        public void updateBtns()
        {
            surveyTaken = hasTakenSurvey();
            Console.WriteLine(surveyTaken);
            if (!surveyTaken)
            {
                surveyBtn.IsEnabled = true;
                calculateBtn.IsEnabled = false;
            }
            else
            {
                surveyBtn.IsEnabled = false;
                calculateBtn.IsEnabled = true;
            }
        }
    }
}
