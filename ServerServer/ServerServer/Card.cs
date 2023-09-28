using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ServerServer
{
    internal class Card
    {
        private int value;
        private byte[] image;


        public Card(int v, byte[] i)
        {
            value = v;
            image = i;

        }

      
    }
}
