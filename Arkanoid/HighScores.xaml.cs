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
    public partial class HighScores : Window
    {
        public Player P { get; set; }
        private List<Label> _names;
        private List<Label> _scores;
        private bool _isDisplayed = false;
        private int _lenght;
        private int _currentPlayer;
        public bool IsOnPlatform { get; set; }
        public bool DisplayOnly { get; set; }

        public HighScores()
        {
            InitializeComponent();
            CreateList();
        }


        public HighScores ( bool displayOnly)
        {
            this._isDisplayed = displayOnly;
            InitializeComponent();
            CreateList();
            DrawList();
            titleLabel.Content = "HIGH SCORES";
            namePanel.Visibility = scorePanel.Visibility = Visibility.Visible;
            nameBox.Visibility = Visibility.Hidden;
            conButton.Content = "BACK";
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!_isDisplayed)
            {
                if (nameBox.Text == "")
                    MessageBox.Show("Please type in your name");
                else if(nameBox.Text.Length > 13)
                    MessageBox.Show("Name should be shorter");
                else
                {
                    AddPlayer();
                }
            }
            else
            {
                _isDisplayed = false;
                MainWindow.score = 0;
                this.Close();
            }
        }


        private void CreateList()
        {
            _scores = new List<Label>();
            _scores.Add(score_0);
            _scores.Add(score_1);
            _scores.Add(score_2);
            _scores.Add(score_3);

            _names = new List<Label>();
            _names.Add(label_0);
            _names.Add(label_1);
            _names.Add(label_2);
            _names.Add(label_3);
        }

        private void AddPlayer()
        {
            P = new Player(nameBox.Text, MainWindow.score);
            _currentPlayer = Player.playerCount;
            MainWindow.list.Add(P);
            MainWindow.loader.AddPlayer(P);
            MainWindow.list.Sort();
            titleLabel.Content = "HIGH SCORES:";
            nameBox.Visibility = Visibility.Hidden;
            scorePanel.Visibility = namePanel.Visibility = Visibility.Visible;

            IsOnPlatform = false;

            DrawList();

            for (int i = 0; i < _lenght; i++)
                if(MainWindow.list[i].ID == _currentPlayer)
                {
                    _names[i].Background = Brushes.Black;
                    IsOnPlatform = true;
                }

            
            if(!IsOnPlatform)
            {
                for (int j = 0; j < MainWindow.list.Count; j++)
                    if (MainWindow.list[j].ID == _currentPlayer)
                    {
                        int place = j+1;
                        _names[3].Content = place + ". " + MainWindow.list[j].Name;
                        _scores[3].Content = MainWindow.list[j].Score;
                        _names[3].Background = Brushes.Black;
                    }
            }
            _isDisplayed = true;
        }

        private void DrawList()
        {

            MainWindow.list.Sort();
            if (MainWindow.list.Count >= 3)
                this._lenght = 3;
            else
                this._lenght = MainWindow.list.Count;

            for (int i = 0; i < _lenght; i++)
            {
                _names[i].Content += MainWindow.list[i].Name;
                _scores[i].Content = MainWindow.list[i].Score;
            }
        }

        
    }
}