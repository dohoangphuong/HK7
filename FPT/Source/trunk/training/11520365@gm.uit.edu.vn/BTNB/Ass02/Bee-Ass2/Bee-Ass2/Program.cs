using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bee_Ass2
{
    class Program
    {
        #region Global variable
        static List<WorkerBee> listWorkerBee = new List<WorkerBee>();
        static List<DroneBee> listDroneBee = new List<DroneBee>();
        static List<QueenBee> listQueenBee = new List<QueenBee>();
        static Random rd = new Random();    //Use for random
        #endregion

        #region Function
        /// <summary> 
        /// Print menu for user choose a funtion
        /// </summary>
        public static void PrintMenu()
        {
            Console.Clear();
            bool isFirstAttempt = true; //To check if user 1st attemp
            int choice = 0;             //To save user choice

            Console.Clear();
            Console.WriteLine("Funcion list:");
            Console.WriteLine("1) Create new bee list");
            Console.WriteLine("2) Attack bees");
            Console.WriteLine("3) Thoat");
            //Validate user input
            do
            {
                if (isFirstAttempt)
                {
                    isFirstAttempt = false;
                    Console.Write("\nPlease choose a function in list: ");
                }
                else
                {
                    Console.Write("You can only choose number in funtion list: ");
                }
                int.TryParse(Console.ReadLine(), out choice);
            }
            while (choice <= 0 || choice > 3);

            //Handle user choice
            switch (choice)
            {
                case 1:
                    GenerateBees();
                    ShowBeeList();
                    break;
                case 2:
                    AttackBees();
                    ShowBeeList();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    PrintMenu();
                    break;
            }
        }

        /// <summary> 
        /// Clear current bee list and create new random bee list
        /// </summary>
        public static void GenerateBees()
        {
            listDroneBee.Clear();
            listWorkerBee.Clear();
            listQueenBee.Clear();

            for (int i = 0; i < 10; i++)
            {
                listWorkerBee.Add(new WorkerBee());
                listDroneBee.Add(new DroneBee());
                listQueenBee.Add(new QueenBee());
            }
        }

        /// <summary> 
        /// Attack current bee list with random value between 0 and 80 for each bee
        /// </summary>
        public static void AttackBees()
        {
            try
            {
                foreach (WorkerBee workerBee in listWorkerBee)
                {
                    workerBee.Damage(rd.Next(80));
                }

                foreach (DroneBee droneBee in listDroneBee)
                {
                    droneBee.Damage(rd.Next(80));
                }

                foreach (QueenBee queenBee in listQueenBee)
                {
                    queenBee.Damage(rd.Next(80));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary> 
        /// Display the current bee list in the console windows
        /// </summary>
        public static void ShowBeeList()
        {
            Console.WriteLine("Worker bee list: ");
            int i = 0;
            foreach (WorkerBee workerBee in listWorkerBee)
            {
                Console.Write("{0}) ", i + 1);
                workerBee.ShowInfomation();
                i++;
            }

            i = 0;
            Console.WriteLine("\nDrone bee list: ");
            foreach (DroneBee droneBee in listDroneBee)
            {
                Console.Write("{0}) ", i + 1);
                droneBee.ShowInfomation();
                i++;
            }

            i = 0;
            Console.WriteLine("\nQueen bee list: ");
            foreach (QueenBee queenBee in listQueenBee)
            {
                Console.Write("{0}) ", i + 1);
                queenBee.ShowInfomation();
                i++;
            }

            Console.WriteLine("Press Enter to go back to main menu");
            Console.ReadLine();
            PrintMenu();
        }
        #endregion

        static void Main(string[] args)
        {
            GenerateBees();
            PrintMenu();
        }
    }
}
