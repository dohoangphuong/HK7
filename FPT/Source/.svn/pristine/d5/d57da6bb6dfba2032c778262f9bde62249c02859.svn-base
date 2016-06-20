using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCard
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.printDeck();
            Console.ReadKey();
        }
    }

    class Card
    {
        int rank, suit;

        public Card()
        {
            this.rank = 0;
            this.suit = 0;
        }

        public Card(int rank , int suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        public void printCard()
        {
            String[] ranks = { "temp", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            String[] suits = { "Spades", "Clubs", "Diamonds", "Hearts" };
            Console.WriteLine(ranks[this.rank] + " of " + suits[this.suit]);
        }
    }

    class Deck
    {
        Card[] cards;

        public Deck()
        {
            cards = new Card[52];

            int index = 0;
            for (int suit = 0; suit <= 3; suit++)
            {
                for (int rank = 1; rank <= 13; rank++)
                {
                    cards[index] = new Card(rank, suit);
                    index++;
                }
            }
        }

        public void printDeck()
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].printCard();
            }
        }
    }
}
