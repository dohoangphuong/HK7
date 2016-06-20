using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Ass2_opt1
{
    class Program
    {
        /* Create main menu
         * Input: 
         * Output: 
         */
        private static void Menu()
        {
            Random random = new Random();
            List<Bee> listBee = new List<Bee>();
            bool exit = false;
            int sumBees = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\tMAIN MENU");
                Console.WriteLine("1. Create Bee list.");
                Console.WriteLine("2. Attack bees.");
                Console.WriteLine("3. Show all bees.");
                Console.WriteLine("0. Exit.");
                Console.Write("Select: ");
                int select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1: // clear current bee list and create new it
                        Console.Clear();
                        try
                        {
                            listBee.Clear();
                            sumBees = random.Next(10, 15);
                            int worker = 0;
                            int queen = 0;
                            int drone = 0;
                            for (int i = 0; i < sumBees; i++)
                            {
                                Bee tmpBee;
                                int rndTypeBee = random.Next(0, 3); // 0-woker bee, 1-Queen bee, 2-Drone bee
                                if (rndTypeBee == 0)
                                {
                                    tmpBee = new WokerBee();
                                    worker++;
                                }
                                else if (rndTypeBee == 1)
                                {
                                    tmpBee = new QueenBee();
                                    queen++;
                                }
                                else
                                {
                                    tmpBee = new DroneBee();
                                    drone++;
                                }
                                listBee.Add(tmpBee);
                            }
                            Console.WriteLine("Created " + (worker + queen + drone) + " bees, include: " + worker
                                + "-worker bee, " + queen + "-queen bee, " + drone + "-drone bee.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2: // Damage all bee in bee list with percentage of health as random 0 - 80
                        Console.Clear();
                        try
                        {
                            int percentage = random.Next(0, 81);
                            for (int i = 0; i < listBee.Count; i++)
                            {
                                listBee[i].Damage(percentage);
                            }
                            Console.WriteLine("Damage to " + listBee.Count + " bees with percentage = " + percentage+".");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3: // show information of all bee in bee list
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("The list have: " + listBee.Count + " bees.");
                            Console.WriteLine("\t{0,-3}\t{1,-10}\t{2,-10}\t{3,-9}", "Num", "Type Bee", "Alive/Dead",
                                   "Health(%)");
                            for (int i = 0; i < listBee.Count; i++)
                            {
                                string typeBee = listBee[i].GetType().Name;
                                string aliveOrDead = "alive";
                                if (listBee[i].IsDead())
                                    aliveOrDead = "dead";
                                else
                                    aliveOrDead = "alive";
                                Console.WriteLine("\t{0,-3}\t{1,-10}\t{2,-10}\t{3,-9}", (i + 1), typeBee, aliveOrDead, 
                                    listBee[i].GetHealth().ToString("0.00"));
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 0: // exit
                        Console.Clear();
                        return;
                        break;
                    default: // press key error
                        Console.WriteLine("Wrong selected! Press any key to reselect.");
                        Console.ReadKey();
                        break;
                }
                // question exit app
                Console.Write("\r\nGo to Main Menu press 1, to exit press any key different 1: ");
                if (int.Parse(Console.ReadLine()) != 1)
                    exit = true;
            }
            while (!exit);
            
        }

        static void Main(string[] args)
        {
            Menu();
            Console.Clear();
            Console.WriteLine("Press any key to continue exit...");
            Console.ReadKey();
        }
    }
}
