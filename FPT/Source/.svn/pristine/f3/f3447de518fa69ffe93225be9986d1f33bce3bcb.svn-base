using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeeAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Bee> list = new List<Bee>(0);
            CreateNewBees(list);
            bool exit = false;
            Console.Write("Press 1 to Create List bee - 2 to get Damage: ");
            while (!exit)
            {
                

                string resp = Console.ReadLine();
                switch (resp)
                {
                    case "1":
                        Console.WriteLine("No.:\tBeeType\t\tHealthLimit\tCurrentHealth\tStatus");
                        CreateNewBees(list);
                        for (int i = 0; i < list.Count; i++)
                        {
                            PrintBee(i + 1, list[i]);
                        }
                        break;
                    case "2":
                        var random = new Random();
                        Console.WriteLine();
                        if (!CannotAttack(list))
                        {
                            Console.WriteLine("After Attacking");
                            Console.WriteLine("No.:\tBeeType\t\tHealthLimit\tCurrentHealth\tStatus");
                            for (int i = 0; i < list.Count; i++)
                            {
                                var damage = random.Next(0, 80);
                                list[i].Damage(damage);
                                PrintBee(i + 1, list[i]);
                            }
                        }
                        else 
                            Console.WriteLine("All bees've been Dead!");
                        break;
                    default:
                        break;
                }
            }
        }
       
        private static void PrintBee(int number, Bee bee)
        {
            string Alive = "";
            if (bee.Alive)
            {
                Alive = "Alive";
            }
            else Alive = "Dead";
            
            Console.WriteLine("{0}:\t{1}\t\t{2}\t\t{4}\t\t{3}", number, bee.Type, bee.HealthLimit, Alive, bee.Health);
        }

        private static void CreateNewBees(List<Bee> list)
        {
            list.Clear();
            for (int i = 0; i < 5; i++)
            {
                list.Add(new Worker());
                
            }
            for (int i = 0; i < 5; i++)
            {
                
                list.Add(new Queen());
            }
            for (int i = 0; i < 5; i++)
            {
                list.Add(new Drone());
               
            }
        }

        private static bool CannotAttack(List<Bee> list)
        {
            int x = 0;
            bool allDead = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].Alive)
                    x++;
            }
            if (x == list.Count)
            {
                allDead = true;
            }
            return allDead;
        }
        
    }
}
