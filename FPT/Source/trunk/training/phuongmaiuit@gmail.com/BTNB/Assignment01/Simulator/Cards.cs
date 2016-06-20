using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opt2
{
    class Cards
    {
        public enum Rank
        {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Qeen,
            King,
        }

        public enum Suit
        {
            Heart,
            Diamond,
            Spades,
            Clubs,
        }

        private Suit suit;
        private Rank rank;
        public String toStringSuits(int index)
        {
            if (index < 0 || index > 4)
            {
                Console.WriteLine("Suits is null");
                return null;
            }
            else
            {
                suit = (Suit)index;
                return suit.ToString();
            }
            
        }

        public String toStringRank(int index)
        {
            if (index < 0 || index > 13)
            {
                Console.WriteLine("Rank is null");
                return null;
            }
            else
            {
                rank = (Rank)index;
                return rank.ToString();
            }
        }
    }
}
