using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> st = new MyStack<int>(100); // create a stack save integer number.

            //create a random array have 100 element
            Random random = new Random();

            for (int i = 0; i <100; i++)
            {
                i = random.Next(0, 100);
                st.Push(i);
            }
            Console.WriteLine("\nvalue is " + st.Get(5));
            while (true)
            {
                Console.WriteLine(st.Pop());
                Console.Write("   ");
                if (st.StackValue == 0) break;
            }
            Console.ReadLine();
        }
    }
}
