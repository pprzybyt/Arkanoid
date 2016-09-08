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
using System.Windows.Media.Animation;

namespace Arkanoid
{
    public class MyPart
    {
        private Random rand = new Random();
        public int WindowX { get; set; }
        public int WindowY { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Thickness Margin { get; set; }
        public SolidColorBrush Brush { get; private set; }

        public double Duration { get; private set; }
        public int Step { get; private set; }
        public int PadWidth { get; private set; }
        public int BallSize { get; private set; }

        private const int _defaultStep = 20;
        private const int _defaultBallSize = 25;
        private const int _defaultPadWidth = 100;
        private const double _defaultDuration = 2.5;

  
        public MyPart(int x, int y, int size)
        {
            DefaultFeatures();
            CreatePart(x, y, size);
        }

        public MyPart (int x, int y, int size, MyPart m)
        {
            LoadFeatures(m);
            CreatePart(x, y, size);
        }

        private void CreatePart(int x, int y, int size)    
          {
            this.WindowX = x;
            this.WindowY = y;
            this.Height = this.Width = size;
            this.Margin = new Thickness(rand.Next(WindowX - size - 8), rand.Next(WindowY - size), 0, 0);

            int a = rand.Next(8);
            if (a % 2 == 0)
                this.Brush = Brushes.Red;
            else
                this.Brush = Brushes.Black;
            ChooseFeature(a);

   
        }


        private void LoadFeatures(MyPart m)
        {
            this.Step = m.Step;
            this.Duration = m.Duration;
            this.PadWidth = m.PadWidth;
            this.BallSize = m.BallSize;
        }

        private void DefaultFeatures()
        {
            this.Step = _defaultStep;
            this.Duration = _defaultDuration;
            this.PadWidth = _defaultPadWidth;
            this.BallSize = _defaultBallSize;
        }

        private void ChooseFeature(int a)
        {
            switch (a)
            {
                case 0:
                    if (this.Step <= _defaultStep)
                        this.Step = 4;
                    else
                        this.Step = _defaultStep;
                    break;
                case 1:
                    if (this.Step >= _defaultStep)
                        this.Step = 25;
                    else
                        this.Step = _defaultStep;
                    break;
                case 2:
                    if (this.Duration <= _defaultDuration)
                        this.Duration = 1.5;
                    else
                        this.Duration = _defaultDuration;
                    break;
                case 3:
                    if (this.Duration >= _defaultDuration)
                        this.Duration = 3.5;
                    else
                        this.Duration = _defaultDuration;
                    break;
                case 4:
                    if (this.PadWidth <= _defaultPadWidth)
                        this.PadWidth = 50;
                    else
                        this.PadWidth = _defaultPadWidth;
                    break;
                case 5:
                    if (this.PadWidth >= _defaultPadWidth)
                        this.PadWidth = 150;
                    else
                        this.PadWidth = _defaultPadWidth;
                    break;
                case 6:
                    if (this.BallSize <= _defaultBallSize)
                        this.BallSize = 15;
                    else
                        this.BallSize = _defaultBallSize;
                    break;
                case 7:
                    if (this.BallSize >= _defaultBallSize)
                        this.BallSize = 40;
                    else
                        this.BallSize = _defaultBallSize;
                    break;
            }
        }

    }
}
