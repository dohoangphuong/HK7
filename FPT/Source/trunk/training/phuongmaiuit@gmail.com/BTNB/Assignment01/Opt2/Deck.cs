using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opt2
{
    class Deck
    {
        public void ShowDeck()
        {
            Cards card = new Cards();

            for (int i = 0; i < 13; i++)
            {
                //Console.WriteLine();
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine(card.toStringRank(i) + " - " + card.toStringSuits(j) + "\t");
                }
               
            }
        }
    }
}
