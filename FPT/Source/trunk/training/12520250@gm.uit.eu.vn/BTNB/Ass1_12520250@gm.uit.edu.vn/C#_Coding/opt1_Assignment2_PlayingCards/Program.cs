using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1_opt1
{
    class Program
    {
        static void Main(string[] args)
        {
            DeckCard deck = new DeckCard();
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\tMAIN MENU");
                Console.WriteLine("1. Create new full deck card.");
                Console.WriteLine("2. Select random a Card in current deck card.");
                Console.WriteLine("3. Show all card in current deck card.");
                Console.WriteLine("0. Exit.");
                Console.Write("Select: ");
                int select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        Console.Clear();
                        try
                        {
                            deck = DeckCard.CreateNewDeckCard();
                            Console.WriteLine("Current deck card is created new.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Current deck card didn't created new. " + ex.Message);
                        }
                        Console.Write("Go to Main Menu press 1, to exit press any key different 1: ");
                        if (int.Parse(Console.ReadLine()) != 1)
                            exit = true;
                        break;
                    case 2:
                        Console.Clear();
                        try
                        {
                            Card cardGet = deck.GetCardRandom();
                            Console.WriteLine("Card got: " + cardGet.GetCard());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Can't get any card. " + ex.Message);
                        }
                        Console.Write("Go to Main Menu press 1, to exit press any key different 1: ");
                        if (int.Parse(Console.ReadLine()) != 1)
                            exit = true;
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine(deck.GetShowAllCard());
                        Console.Write("Go to Main Menu press 1, to exit press any key different 1: ");
                        if (int.Parse(Console.ReadLine()) != 1)
                            exit = true;
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Wrong selected! Press any key to reselect.");
                        Console.ReadKey();
                        break;
                }

            }
            while (!exit);
            Console.WriteLine("Press any key to continue exit...");
            Console.ReadKey();
        }
    }
}
