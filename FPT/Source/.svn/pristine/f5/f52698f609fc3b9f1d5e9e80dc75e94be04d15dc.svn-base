using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass02
{
    class Program
    {
        static public int menuManager()
        {
            Console.Write("\n\t\t_________________________________________");
            Console.Write("\n\t\t|                                       |");
            Console.Write("\n\t\t|------------------Menu-----------------|");
            Console.Write("\n\t\t|_______________________________________|");
            Console.Write("\n\t\t|                                       |");
            Console.Write("\n\t\t|                0: Exit                |");
            Console.Write("\n\t\t|                1: Bees                |");
            Console.Write("\n\t\t|                2: Attack              |");
            Console.Write("\n\t\t|                3: ClearScreen         |");
            Console.WriteLine("\n\t\t|_______________________________________|");

            int index;
            do
            {
                Console.Write("Please input a(0-3): ");
                index = int.Parse(Console.ReadLine());
            } while (index < 0 || index > 3);
            return index;
        }

        static public void menuBee()
        {
            Console.Write("\n\t\t_________________________________________");
            Console.Write("\n\t\t|                                       |");
            Console.Write("\n\t\t|----------------Menu-Bees--------------|");
            Console.Write("\n\t\t|_______________________________________|");
            Console.Write("\n\t\t|                                       |");
            Console.Write("\n\t\t|               0: Exit                 |");
            Console.Write("\n\t\t|               1: Create               |");
            Console.Write("\n\t\t|               2: Clear                |");
            Console.Write("\n\t\t|               3: ClearScreen          |");
            Console.WriteLine("\n\t\t|_______________________________________|");
        }
        static public void menuBees(CHive hiveBee)
        {
            menuBee();
            int index;
            do
            {
                Console.Write("Please input a(0-3): ");
                index = int.Parse(Console.ReadLine());
                if (index >= 0 && index <= 3)
                {
                    switch (index)
                    {
                        case 0:
                            return;
                        case 1:
                            hiveBee.createListBee();
                            break;
                        case 2:
                            hiveBee.clearListBee();
                            break;
                        case 3:
                            Console.Write(" \nPress any key to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            menuBee();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Error value");
                }
            } while (true);
        }

        static public void menuA(CHive hiveBee)
        {
            Console.Write("\n\t\t_________________________________________");
            Console.Write("\n\t\t|                                       |");
            Console.Write("\n\t\t|---------------Menu-Attack-------------|");
            Console.Write("\n\t\t|_______________________________________|");
            Console.Write("\n\t\t|               0: Exit                 |");
            hiveBee.showBees();
            Console.WriteLine("\n\t\t|_______________________________________|");
        }
        static public void menuAttack(CHive hiveBee)
        {
            
            int index;
            do
            {
                menuA(hiveBee);
                Console.Write("Please input a(0-10): ");
                index = int.Parse(Console.ReadLine());
                if(index >= 0 && index <= 10)
                {
                    // starting the command
                    switch (index)
                    {
                        case 0:
                            return;
                        default:
                            hiveBee.attackBees(index - 1);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Error value");
                }
            } while (true);
        }
        static void Main(string[] args)
        {
            CHive hiveBee = new CHive();
            do
            {
                switch (menuManager())
                {
                    case 0:
                        return;
                    case 1:
                        Console.Clear();
                        menuBees(hiveBee);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        menuAttack(hiveBee);
                        Console.Clear();
                        break;
                    case 3:
                        Console.Write(" \nPress any key to continue...");
                        Console.ReadLine();
			            Console.Clear();
                        break;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
