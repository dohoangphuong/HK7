using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass02
{
    class CHive
    {
        List<CBee> listBee = new List<CBee>();
        Random rand = new Random();

        protected void createTypeBee(int itypeBee)
        {
            switch (itypeBee)
            {
                case 1:
                    listBee.Add(new CWorker());
                    break;
                case 2:
                     listBee.Add(new CQueen());
                    break;
                case 3:
                     listBee.Add(new CDrone());
                    break;
            }
        }
        public void createListBee()
        {
            if (listBee != null)
            {
                int temp;
                for (int i = 0; i < 10; i++)
                {
                    temp = (rand.Next(1, 4));
                    createTypeBee(temp);
                }
                Console.WriteLine("Create hive a complete!");
            }
        }

        public void clearListBee()
        {
            if(listBee!=null)
            {
                for (int i = 0; i < 10; i++)
                    listBee.RemoveAt(0);
                Console.WriteLine("Clear hive a complete!");
            }
            else
            {
                Console.WriteLine(" Hive is null");
            }
        }

        public void attackBees(int iIndex)
        {
            int temp;
            temp = (rand.Next(0, 81));
            listBee[iIndex].Damage(temp);
        }

        public void showBees()
        {
            if (listBee.Count == 0)
            {
                Console.WriteLine("\n\t\t\t\tHive is null");
            }
            else
            {
                Console.WriteLine();
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("\t\t\t{0}: ", i + 1);
                    listBee[i].showHealth();
                }
            }
        }
    }
}
