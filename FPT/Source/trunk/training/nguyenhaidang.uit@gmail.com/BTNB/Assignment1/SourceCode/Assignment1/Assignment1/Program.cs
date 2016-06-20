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
            Console.WriteLine("INITIALIZE SATCK WITH 10 RANDOM NUMBER");
            MyStack stack = new MyStack();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                Node node = new Node(rand.Next(10));
                stack.Push(node);
            }
            stack.PrintStack();

            Console.WriteLine("\n\nSTACK AFTER CALL METHOD Pop()");
            if (!stack.IsEmpty())
            {
                stack.Pop();
                stack.PrintStack();
            }
            Console.WriteLine("\n\nSTACK AFTER CALL METHOD Pop()");
            if (!stack.IsEmpty())
            {
                stack.Pop();
                stack.PrintStack();
            }

            Console.WriteLine("\n\nGET A VALUE FROM TOP OF THE STACK");
            if (!stack.IsEmpty())
                stack.Get().PrintNode();

            Console.Read();
        }
    }
}
