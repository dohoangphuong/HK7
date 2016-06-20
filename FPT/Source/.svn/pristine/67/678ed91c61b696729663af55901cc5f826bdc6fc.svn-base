using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    class Card
    {
        /// <summary>
        /// constant defines max of rank
        /// </summary>
        public const byte MAX_OF_RANK = 13;
        /// <summary>
        /// list of ranks
        /// </summary>
        public static string[] RANKS = { "Ace", "two", "three", "four", "five"
                                          , "six", "seven", "eight", "nine", "ten"
                                          , "Jack", "Queen", "King" };

        /// <summary>
        /// constant defines max of suit
        /// </summary>
        public const byte MAX_OF_SUIT = 4;
        /// <summary>
        /// list of suits
        /// </summary>
        public static string[] SUITS = { "Spade ", "Clubs ", "Diamonds", "Hearts" };

        /// <summary>
        /// Rank of card
        /// </summary>
        private byte bytRank;
        public byte Rank
        {
            get { return bytRank; }
            set { bytRank = value; }
        }

        /// <summary>
        /// Suit of card
        /// 0 is Spade, 1 is Clubs, 2 is Diamonds and 3 is Hearts
        /// </summary>
        private byte bytSuit;
        public byte Suit
        {
            get { return bytSuit; }
            set { bytSuit = value; }
        }

        /// <summary>
        /// The constructor of class
        /// </summary>
        /// <param name="rank">rank of card</param>
        /// <param name="suit">suit of card</param>
        public Card(byte rank, byte suit)
        {
            bytRank = rank;
            bytSuit = suit;
        }

        /// <summary>
        /// print name of card
        /// </summary>
        public void PrintCard()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("The ");
            sb.Append(RANKS[bytRank]);
            sb.Append(" of ");
            sb.Append(SUITS[bytSuit]);

            Console.WriteLine(sb);

            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] names = { "Matt", "Joanne", "Robert" };
        }
    }
}
