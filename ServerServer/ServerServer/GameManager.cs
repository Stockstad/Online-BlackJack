using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace ServerServer
{
    internal static class GameManager
    {
        public static int PlayerCount = 1;
        private static int checkCount = 0;
        public static List<User> playerList = new List<User>();
        public static char[] charList = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm' };
        public static int currentPlayer; //The dealer is always player 0. Default for players are then 1 and 2 respectively. 
      
        public static string SendServerCheck()
        {
            Dealer dealer = new("dealer", 0);
            playerList.Add(dealer);
            checkCount++;
            return $"Server is working properly! Sent {checkCount} times.";
        }

        public static void UpdatePlayer()
        {
            if (currentPlayer == PlayerCount) { currentPlayer = 0; }
            else { currentPlayer++; }
            
        }

      

      


    }
}
