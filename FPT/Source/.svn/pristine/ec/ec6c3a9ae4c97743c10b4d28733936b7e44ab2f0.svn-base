using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1_opt1
{
    public enum RANK
    {
        Two, // 2
        Three, // 3
        Four, // 4
        Five, // 5
        Six, // 6
        Seven, // 7
        Eight, // 8
        Nine, // 9
        Ten, // 10
        Jack, // J
        Queen, // Q
        King, // K
        Ace // A
    };

    public enum SUIT
    {
        Spades, // ♠
        Hearts, // ♥
        Diamonds, // ♦
        Clubs, // ♣
    };

    class Card
    {
        private RANK _rank;
        public RANK Rank
        {
            get { return _rank; }
            private set { _rank = value; } // blocked set directly rank card value from outside
        }

        private SUIT _suit;
        public SUIT Suit
        {
            get { return _suit; }
            private set { _suit = value; } // blocked set directly suit card value from outside
        }

        public Card(RANK rank, SUIT suit)
        {
            _rank = rank;
            _suit = suit;
        }

        /* Get card's information
         * Input: 
         * Output: string - card's information with format: 'Rank'+' '+'Suit' 
         */
        public string GetCard()
        {
            string result = "";

            // get Rank with abbreviation
            switch (_rank)
            { 
                case RANK.Two:
                    result = "2";
                    break;
                case RANK.Three:
                    result = "3";
                    break;
                case RANK.Four:
                    result = "4";
                    break;
                case RANK.Five:
                    result = "5";
                    break;
                case RANK.Six:
                    result = "6";
                    break;
                case RANK.Seven:
                    result = "7";
                    break;
                case RANK.Eight:
                    result = "8";
                    break;
                case RANK.Nine:
                    result = "9";
                    break;
                case RANK.Ten:
                    result = "10";
                    break;
                case RANK.Jack:
                    result = "J";
                    break;
                case RANK.Queen:
                    result = "Q";
                    break;
                case RANK.King:
                    result = "K";
                    break;
                case RANK.Ace:
                    result = "A";
                    break;
            }
            // get Suit with abbreviation
            switch (_suit)
            {
                case SUIT.Spades:
                    result += " " + "♠";
                    break;
                case SUIT.Hearts:
                    result += " " + "♥";
                    break;
                case SUIT.Diamonds:
                    result += " " + "♦";
                    break;
                case SUIT.Clubs:
                    result += " " + "♣";
                    break;
            }
            return result;
        }
    }
}
