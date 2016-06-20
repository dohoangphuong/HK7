using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Card
    {
        private string rank;
        private string suit;

        public Card()
        {

        }
        public Card(string newrank, string newsuit)
        {
            rank = newrank;
            suit = newsuit;
        }

        public string Read()
        {
            return rank + " of " + suit;
        }
    }
}
