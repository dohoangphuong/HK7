using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    class Deck
    {
        /// <summary>
        /// constant defines the number of cards in a deck
        /// </summary>
        public const int NUMBER_OF_CARDS = 52;

        /// <summary>
        /// a deck of cards
        /// </summary>
        private Card[] PlayingCards;
        internal Card[] Cards
        {
            get { return PlayingCards; }
        }

        /// <summary>
        /// the constructor of class
        /// </summary>
        public Deck()
        {
            PlayingCards = new Card[NUMBER_OF_CARDS];
            for (byte b = 0; b < NUMBER_OF_CARDS/4; b++)
            {
                PlayingCards[b * 4] = new Card(b, 0);
                PlayingCards[b * 4 + 1] = new Card(b, 1);
                PlayingCards[b * 4 + 2] = new Card(b, 2);
                PlayingCards[b * 4 + 3] = new Card(b, 3);
            }
        }

        /// <summary>
        /// Get a card from deck depend on card's rank and card's suit
        /// </summary>
        /// <param name="rank">rank of card</param>
        /// <param name="suit">suit of card</param>
        /// <returns></returns>
        public Card GetCard(byte number)
        {
            if (PlayingCards == null || number < 0 || number >= NUMBER_OF_CARDS)
                return null;
            else
                return PlayingCards[number];
        }
    }
}
