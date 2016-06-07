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

namespace Arkanoid
{
    /// <summary>
    /// Interaction logic for HighScores.xaml
    /// </summary>
    public partial class HighScores : Window
    {
        public HighScores()
        {
            InitializeComponent();
            CreateList();
        }

        

        public HighScores ( bool displayOnly)
        {
            this.isDisplayed = displayOnly;
            InitializeComponent();
            CreateList();
            DrawList();
            titleLabel.Content = "HIGH SCORES";
            namePanel.Visibility = scorePanel.Visibility = Visibility.Visible;
            nameBox.Visibility = Visibility.Hidden;
            conButton.Content = "BACK";
        }

        public Player P { get; set; }
        public List<Label> names;
        public List<Label> scores;
        public bool isDisplayed = false;
        public int lenght;
        public int currentPlayer;
        public bool IsOnPlatform { get; set; } 
        public bool DisplayOnly { get;set;}


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!isDisplayed)
            {
                if (nameBox.Text == "")
                    MessageBox.Show("Please type in your name");
                else if(nameBox.Text.Length > 20)
                    MessageBox.Show("Name should be shorter");
                else
                {
                    AddPlayer();
                }
            }
            else
            {
                isDisplayed = false;
                MainWindow.score = 0;
                this.Close();
            }
        }


        private void CreateList()
        {
            scores = new List<Label>();
            scores.Add(score_0);
            scores.Add(score_1);
            scores.Add(score_2);
            scores.Add(score_3);

            names = new List<Label>();
            names.Add(label_0);
            names.Add(label_1);
            names.Add(label_2);
            names.Add(label_3);
        }

        private void AddPlayer()
        {
            P = new Player(nameBox.Text, MainWindow.score);
            currentPlayer = Player.playerCount;
            MainWindow.list.Add(P);
            MainWindow.list.Sort();
            titleLabel.Content = "HIGH SCORES:";
            nameBox.Visibility = Visibility.Hidden;
            scorePanel.Visibility = namePanel.Visibility = Visibility.Visible;

            IsOnPlatform = false;

            DrawList();

            for (int i = 0; i < lenght; i++)
                if(MainWindow.list[i].ID == currentPlayer)
                {
                    names[i].Background = Brushes.Black;
                    IsOnPlatform = true;
                }

            
            if(!IsOnPlatform)
            {
                for (int j = 0; j < MainWindow.list.Count; j++)
                    if (MainWindow.list[j].ID == currentPlayer)
                    {
                        int place = j+1;
                        names[3].Content = place + ". " + MainWindow.list[j].Name;
                        scores[3].Content = MainWindow.list[j].Score;
                        names[3].Background = Brushes.Black;
                    }
            }
            isDisplayed = true;
          //  scorePanel.Visibility = namePanel.Visibility = Visibility.Visible;
        }

        private void DrawList()
        {
            if (MainWindow.list.Count >= 3)
                this.lenght = 3;
            else
                this.lenght = MainWindow.list.Count;

            for (int i = 0; i < lenght; i++)
            {
                names[i].Content += MainWindow.list[i].Name;
                scores[i].Content = MainWindow.list[i].Score;
            }
        }

        
    }
}