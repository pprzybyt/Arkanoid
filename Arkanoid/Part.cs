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
    public class Part
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


        public Part(int x, int y, int size)
        {
            this.WindowX = x;
            this.WindowY = y;
            this.Height = this.Width = size;
            this.Margin = new Thickness(rand.Next(WindowX - size), rand.Next(WindowY - size), 0, 0);

            int a = rand.Next(8);
            if(a%2==0)
                this.Brush = Brushes.Red;
            else
                this.Brush = Brushes.Black;

            this.Step = 20;
            this.Duration = 3;
            this.PadWidth = 100;
            this.BallSize = 25;

            switch (a)
            {
                case 0:
                    this.Step = 4;
                    break;
                case 1:
                    this.Step = 25;
                    break;
                case 2:
                    this.Duration = 1.5;
                    break;
                case 3:
                    this.Duration = 3.5;
                    break;
                case 4:
                    this.PadWidth = 50;
                    break;
                case 5:
                    this.PadWidth = 150;
                    break;
                case 6:
                    this.BallSize = 15;
                    break;
                case 7:
                    this.BallSize = 40;
                    break;
            }

        }

    }
}
