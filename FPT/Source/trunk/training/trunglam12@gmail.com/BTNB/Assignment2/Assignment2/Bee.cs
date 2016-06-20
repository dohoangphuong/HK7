using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Bee
    {
        private int health;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        private string status;// status of bee : alive or dead

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        List<Bee> listBee; //list bee

        //constructor
        public Bee()
        {
            health = 100;
            status = "alive";
            listBee = new List<Bee>();
        }

        //Compare health to decide bee alive or dead
         public virtual void IsDead() 
        {
        }

        //Caculate health after damage
        public int Damage()
        {
            Random rand = new Random();
            int x = rand.Next(0, 80);

            health = health - x;
            if (health < 0) health = 0;
            return health;
        }

        //set status bee after damage
        public void SetStatusBee(int position)
        {
            try
            {
                listBee[position - 1].Damage();
                listBee[position - 1].IsDead();
            }
            catch
            {
                Console.WriteLine("List Bee NULL");
            }


        }

        //Show property of one bee
        public void Show()
        {
            System.Console.WriteLine(" Type :" + this.ToString().Substring(12));
            System.Console.WriteLine(" Health =" + health);
            System.Console.WriteLine(" Status =" + status);

        }

        //Show property of list bee
        public void ShowListBee()
        {
            for (int i = 0; i < listBee.Count; i++)
            {
                Console.WriteLine("Number :" + (i+1));
                listBee[i].Show();
            }
        }

        //Create list bee
        public List<Bee> CreateListBee()
        {
            listBee.Clear();

            Random rand = new Random();

            int randNumWokerBee = rand.Next(0, 10);
            int randNumQueenBee = rand.Next(0, 10);

            for (int i = 0; i < randNumWokerBee; i++)
            {
                Bee bee = new BeeWorker();
                listBee.Add(bee);
            }

            if (randNumWokerBee + randNumQueenBee < 10)
            {
                for (int i = 0; i < randNumQueenBee; i++)
                {
                    Bee bee = new BeeQueen();
                    listBee.Add(bee);
                }

                for (int i = 0; i < 10 - (randNumWokerBee + randNumQueenBee); i++)
                {
                    Bee bee = new BeeDrone();
                    listBee.Add(bee);
                }
            }
            else
            {
                for (int i = 0; i < 10 - randNumWokerBee; i++)
                {
                    Bee bee = new BeeQueen();
                    listBee.Add(bee);
                }

            }
            Console.WriteLine("Create bee success");

            return listBee;
        }

    }
}
