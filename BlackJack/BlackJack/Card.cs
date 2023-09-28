using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BlackJack
{
    internal class Card
    {
        public char value;
        public Image image;
        

        public Card(char v, Image i)
        {
            value = v;
            image = i;

        }


    }
}
