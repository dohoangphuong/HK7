using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass02_Opt1_Ass2
{
    // Danh sách kiểu quân bài
    public enum SuitOfCard
    {
        // Lá bài cơ
        Hearts = 0,

        // Lá bài rô
        Diamonds = 1,

        // Là bài chuồn
        Clubs = 2,

        // Lá bài bích
        Spades = 3
    }


    // Lớp thể hiện quân bài
    public class Card
    {
        // Kiểu quân bài
        private SuitOfCard suit;


        public SuitOfCard Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        // Hạng của quân bài
        private int rank;

        public int Rank
        {
            get { return rank; }
            set
            {
                if (value >= 1 && value <= 13)
                {
                    rank = value;
                }
                else
                {
                    value = 1;
                }
            }
        }

        public override string ToString()
        {
            switch (rank)
            {
                case 1:
                    return "Ace" + " - " + suit.ToString();
                case 2:
                    return "Two" + " - " + suit.ToString();
                case 3:
                    return "Three" + " - " + suit.ToString();
                case 4:
                    return "Fourth" + " - " + suit.ToString();
                case 5:
                    return "Five" + " - " + suit.ToString();
                case 6:
                    return "Six" + " - " + suit.ToString();
                case 7:
                    return "Seven" + " - " + suit.ToString();
                case 8:
                    return "Eight" + " - " + suit.ToString();
                case 9:
                    return "Nine" + " - " + suit.ToString();
                case 10:
                    return "Ten" + " - " + Suit.ToString();
                case 11:
                    // J
                    return "Jack" + " - " + suit.ToString();
                case 12:
                    // Q
                    return "Queen" + " - " + suit.ToString();
                case 13:
                    // K
                    return "King" + " - " + suit.ToString();
            }

            // Khai báo cho đúng cú pháp, đã bao đóng giá trị! Trường hợp trả về "" không xảy ra!
            return "";
        }
    }
}
