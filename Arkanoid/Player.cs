using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
   public class Player : IComparable
    {
        public String Name { get; set; }
        public int Score { get; set; }
        public int ID { get; private set; }
        public static int playerCount;

        public Player (String name , int score)
        {
            this.Name = name;
            this.Score = score;
            playerCount++;
            this.ID = playerCount;
        }

        public override string ToString()
        {
            int nLenght, sLenght;
            nLenght = 35 -this.Name.Length;
            sLenght = 8 - this.Score.ToString().Length;
            string player =string.Format("{0," + -nLenght +"}{1,"+ sLenght+"}" ,this.Name,this.Score);
            return player;
        }

        public int CompareTo(object obj)
        {
            Player play = (Player)obj;
            if (this.Score < play.Score)
                return 1;
            if (this.Score > play.Score)
                return -1;
            else
                return 0;
        }
    }
}
