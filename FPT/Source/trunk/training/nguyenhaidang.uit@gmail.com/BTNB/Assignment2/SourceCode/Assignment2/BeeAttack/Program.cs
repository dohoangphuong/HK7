using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            BeeArray beeArr = new BeeArray();
            beeArr.CreateBees();
            int select = 0;
            bool isValid = false;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Create/Recreate bee list");
                Console.WriteLine("2. Attack bees");
                Console.WriteLine("0. Exit");                

                isValid = false;
                while (!isValid)
                {
                    Console.Write("Your selection: ");
                    if (Int32.TryParse(Console.ReadLine(), out select))
                    {
                        if (select == 0 || select == 1 || select == 2)
                            isValid = true;
                    }
                }

                switch (select)
                { 
                    case 1:
                        beeArr.CreateBees();
                        Console.WriteLine("\nCreate success");
                        beeArr.ShowStatus();
                        break;
                    case 2:
                        Console.WriteLine("\nThe status of bees after damaged");
                        beeArr.Damage();
                        break;
                    default:
                        break;
                }
                Console.ReadLine();
            }while(select != 0);
        }
    }
}
