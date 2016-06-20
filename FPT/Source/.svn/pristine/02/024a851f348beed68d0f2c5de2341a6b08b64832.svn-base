using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2
{
    public class Desk
    {
        private string[] arrayRank = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private string[] arraySuite = { "♥", "♦", "♣", "♠" };
        private List<Card> DeskOfCard;

        public Desk()
        {
            DeskOfCard = new List<Card>();
            for (int i = 0; i < arraySuite.Length; i++)
            {
                for (int j = 0; j < arrayRank.Length; j++)
                {
                    Card card = new Card(arrayRank[j], arraySuite[i]);
                    DeskOfCard.Add(card);
                }
            }
        }

        public void PrintDesk()
        {
            int t = 1;
            for (int i = 1; i <= DeskOfCard.Count; i++)
            {
                System.Console.Write(DeskOfCard[i - 1].CardName() + " ");
                if (i == 13 * t)
                {
                    System.Console.WriteLine("\n");
                    t++;
                }
            }
        }
    }
}
