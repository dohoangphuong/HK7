using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass02_Opt1_Ass01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Bee> bees = new List<Bee>();

            do
            {
                Console.WriteLine("1. Create Bee List");
                Console.WriteLine("2. Attacks Bees");
                Console.WriteLine("Chon 1 hoac 2");

                int intTemp = 0;

                if (int.TryParse(Console.ReadLine(), out intTemp))
                {
                    switch (intTemp)
                    {
                        case 1:
                            bees.Clear();
                            CreateList(ref bees);
                            break;
                        case 2:
                            AttackBees(ref bees);
                            break;
                        default:
                            break;
                    }
                }

                Console.WriteLine("An enter de tiep tuc, phim bat ky de thoat");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }

        private static void AttackBees(ref List<Bee> bees)
        {
            Random random = new Random();
            foreach (var bee in bees)
            {
                bee.Damge(random.Next(0, 80));
            }
        }

        private static void CreateList(ref List<Bee> bees)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                switch (random.Next(1, 4))
                {
                    case 1:
                        bees.Add(new Worker()
                        {
                            Health = 100
                        });
                        break;
                    case 2:
                        bees.Add(new Queen()
                        {
                            Health = 100
                        });
                        break;
                    case 3:
                        bees.Add(new Drone()
                        {
                            Health = 100
                        });
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
