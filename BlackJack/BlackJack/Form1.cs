using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        public static string[] images = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\cards\", "*.png");
        List<PictureBox> yourHand = new List<PictureBox>();
        List<PictureBox> oppHand = new List<PictureBox>();
        List<PictureBox> dealerHand = new List<PictureBox>();
        int cardsInDeck = 0;
        int dealerCardsInDeck = 0;
        int opponentCardsInDeck = 0;
        char[] hand;
        public Form1()
        {
            InitializeComponent();
        }

        private void HitButton_ClickAsync(object sender, EventArgs e)
        {
            
                if (cardsInDeck == 0)
                {
                    DataConnection.SendData("create_starting_hand");
                    string output = DataConnection.GetData();
                    hand = output.ToCharArray();
                }
                else
                {
                    DataConnection.SendData("hit me");
                    string output = DataConnection.GetData();
                    hand = output.ToCharArray();

                }

               

                

                var neededCard1 = ClientManager.cards.First(a => a.value == hand[0]);

                yourHand[cardsInDeck].Image = neededCard1.image;
                cardsInDeck++;

                var ValueCheck = ClientManager.UpdateValueLabel();
                HandValueLabel.Text = ValueCheck;
                if (Convert.ToInt32(ValueCheck) > 21)
                {
                    Fold();
                }

            if (cardsInDeck == 1)
                {
                    var neededCard2 = ClientManager.cards.First(a => a.value == hand[1]);
                    yourHand[cardsInDeck].Image = neededCard2.image;
                    cardsInDeck++;
                }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            ClientManager.CreateCards(images);

            DataConnection.ConnectToServer();
            DataConnection.SendData("server_open");
            string output = DataConnection.GetData();
            MessageBox.Show($"{output}");

            foreach (var pb in YouPlayerPanel.Controls)
            {
                if (pb is PictureBox)
                {
                    yourHand.Add((PictureBox)pb);
                }
            }

            foreach (var pb in DealerPlayerPanel.Controls)
            {
                if (pb is PictureBox)
                {
                    dealerHand.Add((PictureBox)pb);
                }
            }

              DealerHit();

        }
        
        private void DealerHit()
        {
            hand = ClientManager.RequestDeal().ToCharArray();
            var neededCard1 = ClientManager.cards.First(a => a.value == hand[0]);
            DealerValueLabel.Text = ClientManager.RequestDealerValue();
            dealerHand[dealerCardsInDeck].Image = neededCard1.image;
            dealerCardsInDeck++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DealerHit();
            DealerValueLabel.Text = ClientManager.RequestDealerValue();
            if (Convert.ToInt32(ClientManager.RequestDealerValue()) > 16)
            {
                timer1.Stop();
            }
        }

        private void Fold()
        {
            ClientManager.CallFolder();
            var result = ClientManager.RequestDealerValue();
            var resultAsInt = Convert.ToInt32(result);

            if (resultAsInt < 21)
            {
                timer1.Start();
            }
            
        }

        private void foldButton_Click(object sender, EventArgs e)
        {
            Fold();
        }
    }
}