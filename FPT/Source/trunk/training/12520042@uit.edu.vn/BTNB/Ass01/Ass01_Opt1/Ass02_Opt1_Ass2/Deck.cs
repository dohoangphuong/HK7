using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ass02_Opt1_Ass2
{
    // LỚp thể hiện 52 quân bài
    public class Deck
    {
        // Số quân bài
        private const int NUMBER_OF_CARD = 52;

        // Tập hợp chưa 52 quân bài
        private Card[] cards;

        public Deck()
        {
            cards = new Card[NUMBER_OF_CARD];

            for (int i = 0; i < NUMBER_OF_CARD; i++)
            {
                cards[i] = new Card();
                switch (i % 4)
                {
                    case 0:
                        // Quân cơ
                        cards[i].Suit = SuitOfCard.Hearts;
                        break;
                    case 1:
                        // Quân rô
                        cards[i].Suit = SuitOfCard.Diamonds;
                        break;
                    case 2:
                        // Quân chuồn
                        cards[i].Suit = SuitOfCard.Clubs;
                        break;
                    case 3:
                        // Quân bích
                        cards[i].Suit = SuitOfCard.Spades;
                        break;
                }

                // Hạng của bài
                cards[i].Rank = i / 4 + 1;
            }

        }

        public override string ToString()
        {
            string strTemp = "";

            for (int i = 0; i < NUMBER_OF_CARD; i++)
            {
                strTemp += i + 1 + ". " + cards[i].ToString() + "\n";
            }

            return strTemp;
        }
    }
}
