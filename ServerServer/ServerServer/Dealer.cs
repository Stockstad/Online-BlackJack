using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerServer
{
    internal class Dealer : User
    {
        public Dealer(string i, int hcv) : base(i, hcv)
        {

        }


        public static string CreateStartingHand()
        {
            var rnd = new Random();
            int random1 = rnd.Next(0, 12);
            int random2 = rnd.Next(0, 12);
            char value1 = GameManager.charList[random1];
            char value2 = GameManager.charList[random2];
            if (random1 > 9) { random1 = 9; }
            if (random2 > 9) { random2 = 9; }

            GameManager.playerList[GameManager.currentPlayer].HandCardValue = (random1 + random2 + 2);


            return value1.ToString() + value2.ToString();
        }

        public static string Hit()
        {
            var rnd = new Random();
            int random1 = rnd.Next(0, 12);
            char value1 = GameManager.charList[random1];
            if (random1 > 9) { random1 = 9; }
            GameManager.playerList[GameManager.currentPlayer].HandCardValue += random1 + 1;

            return value1.ToString();
        }

    }
    
}
