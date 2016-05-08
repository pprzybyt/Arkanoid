﻿using System;
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
using System.Windows.Media.Animation;
using System.Drawing;


namespace Arkanoid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitParticles();          
        }
        
        private Thickness _padStartPosition = new Thickness(150,440,0,0);
        Thickness _padCurrentPosition;
        Thickness _ballStartPosition;
        Thickness _ballCurrentPosition;
        Thickness _ballNextPosition;
        ThicknessAnimation _moveThePad;
        ThicknessAnimation _moveTheBall;
        Storyboard _playBall;
        Storyboard _playPad;
        int _score;
        Part part;
        int _step;
        double _duration;
        Rect _ballRect;
        Rect _blockRect;

        public void InitParticles()
        {
            part = new Part(Convert.ToInt16(grid.Width), Convert.ToInt16(pad.Margin.Top), 50);
            block.DataContext = part;          
        }

        public void Start()
        {
            _ballStartPosition = new Thickness(150, 100, 0, 0);
            _padCurrentPosition = _padStartPosition;
            _ballCurrentPosition = _ballStartPosition;
            _ballNextPosition = new Thickness(grid.Width/2, grid.Height, 0, 0);
            _score = 0;
            scoreBox.Text = _score.ToString();
            AnimateBall(_ballCurrentPosition,_ballNextPosition);
        }


        public void Stop()
        {
            startButton.Content = "AGAIN";
            startButton.Visibility = Visibility.Visible;
            block.Visibility = Visibility.Hidden;
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            startButton.Visibility = Visibility.Hidden;
            ball.Visibility = pad.Visibility = block.Visibility = Visibility.Visible;
            scoreBox.Visibility = scoreLabel.Visibility = Visibility.Visible;
            DefaultSettings();
            Start();
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
      
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            int step = _step;
            if (e.Key == Key.Left)
            {
                if (pad.Margin.Left - step > 0)
                    step = -step;
                else
                    step = Convert.ToInt16(-pad.Margin.Left);
                AnimatePad(step);
             
            }

            else if(e.Key == Key.Right)
            {
                if (pad.Margin.Left + pad.Width >= grid.Width - step)
                    step = Convert.ToInt16(grid.Width - pad.Margin.Left - pad.Width);
                AnimatePad(step);
            }

          
        }

        private void AnimatePad(int step)
        {
            _moveThePad = new ThicknessAnimation();
            _moveThePad.From = _padCurrentPosition;
            _moveThePad.To = new Thickness(pad.Margin.Left + step, pad.Margin.Top, 0, 0);
            _moveThePad.Duration = new Duration(TimeSpan.FromSeconds(0));

            Storyboard.SetTargetName(_moveThePad, "pad");
            Storyboard.SetTargetProperty(_moveThePad, new PropertyPath(Rectangle.MarginProperty));

            _playPad = new Storyboard();
            _playPad.Children.Add(_moveThePad);
            _playPad.Begin(this, true);
        }

        private void AnimateBall(Thickness current, Thickness next)
        {

            double timeRatio = Math.Abs(_ballCurrentPosition.Top - _ballNextPosition.Top);

            _moveTheBall = new ThicknessAnimation();
            _moveTheBall.From = current;
            _moveTheBall.To = next;
            _moveTheBall.Duration = new Duration(TimeSpan.FromSeconds(timeRatio*_duration/470.0));

            Storyboard.SetTargetName(_moveTheBall, "ball");
            Storyboard.SetTargetProperty(_moveTheBall, new PropertyPath(Rectangle.MarginProperty));

            _playBall = new Storyboard();
            if (_playBall.Children.Count > 0)
                _playBall.Children.RemoveAt(0);

            _playBall.Children.Add(_moveTheBall);
            _playBall.Begin(this, true);
        }

        private void window_LayoutUpdated(object sender, EventArgs e)
        {
            

        }
          private void ball_LayoutUpdated(object sender, EventArgs e)
        {
             _ballCurrentPosition = ball.Margin;
                      
             _ballRect = new Rect(new Point(ball.Margin.Left,ball.Margin.Top),new Size(ball.Width,ball.Height));
             _blockRect = new Rect(new Point(block.Margin.Left, block.Margin.Top), new Size(block.Width, block.Height));


            if (ball.Margin.Top > pad.Margin.Top)
                Stop();
            else if (pad.Margin.Top <= ball.Margin.Top + ball.Height && pad.Margin.Left <= ball.Margin.Left + ball.Width / 2 && pad.Margin.Left + pad.Width >= ball.Margin.Left - ball.Width / 2) 
            {
                _ballNextPosition.Top = 0;

                double padAngle = 2000 * ((_ballCurrentPosition.Left + ball.Width / 2) - (pad.Margin.Left + pad.Width / 2)) / pad.Width / 2;

                     _ballNextPosition.Left = _ballCurrentPosition.Left + padAngle;
               
                _ballStartPosition = ball.Margin;
                _score++;
                scoreBox.Text = _score.ToString();
                AnimateBall(_ballCurrentPosition, _ballNextPosition);
            }


            if (ball.Margin.Top <= 0)
            {
                _ballNextPosition.Top = grid.Height;

                double horizontalMove = (_ballCurrentPosition.Left - _ballStartPosition.Left) * (pad.Margin.Top - ball.Height) / Math.Abs(_ballCurrentPosition.Top - _ballStartPosition.Top);
                _ballNextPosition.Left = _ballCurrentPosition.Left + horizontalMove ;
       
                AnimateBall(_ballCurrentPosition, _ballNextPosition);
            }

            if (ball.Margin.Left + ball.Width >= grid.Width) 
            {
                _ballNextPosition.Left = 2*_ballCurrentPosition.Left - _ballNextPosition.Left;

                _ballStartPosition = ball.Margin;
                
                AnimateBall(_ballCurrentPosition, _ballNextPosition);
            }

            if (ball.Margin.Left <= 0)
            {
                _ballNextPosition.Left = -(_ballNextPosition.Left);

                _ballStartPosition = ball.Margin;

                AnimateBall(_ballCurrentPosition, _ballNextPosition);
            }


            if (!Rect.Intersect(_ballRect,_blockRect).IsEmpty)
                BlockPassed();
           

        }

        public void BlockPassed()
          {
              _duration = part.Duration;
              pad.Width = part.PadWidth;
              _step = part.Step;
              ball.Width = ball.Height = part.BallSize;
              _score += 500;
              scoreBox.Text = _score.ToString();
              part = new Part(Convert.ToInt16(grid.Width), Convert.ToInt16(pad.Margin.Top), 50);
              block.Margin = part.Margin;
              block.Stroke = part.Brush;
          }

        private void DefaultSettings()
        {
            _step = 20;
            _duration = 2.5;
            pad.Width = 100;
            ball.Height = ball.Width = 25;
        }
    }
}
