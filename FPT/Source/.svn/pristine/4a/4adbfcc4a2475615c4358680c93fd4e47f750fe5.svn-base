using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Deck
    {
        private Card[] deck;
        private int currentCard;
        private const int NUMBER_OF_CARDS = 52;
        private Random ranNum;

        public Deck()
        {
            String[] ranks = {"Ace","Two","Three","Four","Five","Six","Seven",
                                 "Eight","Nine","Ten","Jack","Queen","King"};
            String[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };

            deck = new Card[NUMBER_OF_CARDS];
            currentCard = 0;
            ranNum = new Random();
            for (int count = 0; count < deck.Length; count++)
            {
                deck[count] = new Card(ranks[count % 13], suits[count / 13]);
            }
        }

        public String DealCard()
        {
            if (currentCard < deck.Length)
                return deck[currentCard++].Read();
            else 
                return null;
        }
    }
}
