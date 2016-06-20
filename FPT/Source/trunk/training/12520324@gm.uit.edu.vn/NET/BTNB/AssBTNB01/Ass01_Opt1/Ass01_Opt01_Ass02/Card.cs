using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass01_Opt01_Ass02
{
    class Card
    {
        public enum Ranks
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,

        }
        public enum Suits
        {
            Hearts = 1,
            Diamonds = 2,
            Clubs = 3,
            Spades = 4,
        }
        private Ranks rank;

        internal Ranks Rank
        {
            get { return rank; }
            set { rank = value; }
        }
        private Suits suit;

        internal Suits Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        public String getRanks(int index)
        {
            if (index < 1 || index > 13)
            {
                Console.WriteLine("Rands is null");
                return null;
            }
            else
            {
                rank=(Ranks)index;
                return rank.ToString();
            }
        }

        public String getSuits(int index)
        {
            if (index < 1 || index > 4)
            {
                Console.WriteLine("Suits is null");
                return null;
            }
            else
            {
                suit = (Suits)index;
                return suit.ToString();
            }
        }
    }
}
