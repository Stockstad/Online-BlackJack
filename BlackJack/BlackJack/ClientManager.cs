using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BlackJack
{
    internal static class ClientManager
    {
        public static List<Card> cards = new List<Card>();
        

        public static void CreateCards(string[] images)
        {
                foreach (var image in images)
                {
                    char[] filename = Path.GetFileNameWithoutExtension(image).ToCharArray();
                    cards.Add(new Card(filename[0], Image.FromFile(image)));
                }
            
        }

        public static string UpdateValueLabel()
        {
            DataConnection.SendData("get_value");
            return DataConnection.GetData().ToString();
        }

        public static string RequestDeal()
        {
            DataConnection.SendData("game_start");
            return DataConnection.GetData().ToString();

        }

        public static string RequestDealerValue()
        {
            DataConnection.SendData("dealer_value");
            return DataConnection.GetData().ToString();
        }

        public static void CallFolder()
        {
            DataConnection.SendData("player_folded");
        }
    }
}
