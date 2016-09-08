using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class About : Window
    {
        private List<Uri> _instruction;
        private int _counter = 0;


        public About()
        {
            InitializeComponent();
            _instruction = new List<Uri>();
            LoadInstruction();
            FillImage();
        }

        private void LoadInstruction()
        {
            _instruction.Add(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory,"img.png")));
            _instruction.Add(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory,"img1.png")));
            _instruction.Add(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory,"img2.png")));
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {

            if (_counter == _instruction.Count)
                this.Close();

            if(_counter<_instruction.Count)
                FillImage();

            if (_counter == _instruction.Count)
                nextButton.Content = "FINISH";
        }

        private void FillImage()
        {

            try
            {
                BitmapImage bitmapImage = new BitmapImage(_instruction[_counter]);
                image.Source = bitmapImage;
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("INSTRUCTION LOADING ERROR");
                _counter = _instruction.Count - 1;
            }
       
            _counter++;
        }
    }
}
