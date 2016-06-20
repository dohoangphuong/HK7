using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            HashSet<Card> myCards = new HashSet<Card>();
            Random rand = new Random();

            Console.WriteLine("\nCHOOSE 13 RANDOM CARDS FROM THE DECK");
            byte b = 0;
            while (b < 13)
            {
                Card card = deck.GetCard((byte)(rand.Next(Deck.NUMBER_OF_CARDS)));
                if (card != null && myCards.Add(card))
                    b++;
            }

            foreach (var card in myCards)
                card.PrintCard();

            Console.Read();
        }
    }
}
