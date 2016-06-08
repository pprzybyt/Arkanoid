using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Arkanoid
{
    public class RankLoader
    {
        private string _rankingFile = "rank.txt";

        public RankLoader()
        {
            FileStream fs = new FileStream(_rankingFile, FileMode.Append);
            fs.Close();
        }

        private List<string> LoadPlayers()
        {
            List<string> list = new List<string>();

            string [] l = File.ReadAllLines(_rankingFile);

            for (int i = 0; i < l.Length; i++ )
            {
                list.Add(l[i]);
            }

                return list;
        }

        public void UpdateRank()
        {
            List<string> temp = this.LoadPlayers();
            try
            {
                for (int i = 0; i < temp.Count; i+=2)
                    MainWindow.list.Add(new Player(temp[i], int.Parse(temp[i + 1])));
            }
            catch(FormatException)
            {
                MessageBox.Show("Rank loading ERROR");
            }
        }

        public void AddPlayer(Player p)
        {
            StreamWriter sw = File.AppendText(_rankingFile);
            
            sw.WriteLine(p.Name);
            sw.WriteLine(p.Score.ToString());

            sw.Close();

        }
    }
}
