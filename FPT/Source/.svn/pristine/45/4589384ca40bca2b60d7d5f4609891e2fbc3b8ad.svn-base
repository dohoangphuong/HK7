using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1_opt1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack stack = new MyStack();
            for (int i = 0; i < 100; i++)
            {
                stack.push(i+1);
            }
            try
            {
                Console.WriteLine("Pop a value from stack: " + stack.pop().ToString() + ", current sum Node in stack = " + stack.SumNode);
                Console.WriteLine("Pop a value from stack: " + stack.pop().ToString() + ", current sum Node in stack = " + stack.SumNode);
                Console.WriteLine("Pop a value from stack: " + stack.pop().ToString() + ", current sum Node in stack = " + stack.SumNode);
                Console.WriteLine("Pop a value from stack: " + stack.pop().ToString() + ", current sum Node in stack = " + stack.SumNode);
                Console.WriteLine("Pop a value from stack: " + stack.pop().ToString() + ", current sum Node in stack = " + stack.SumNode);
                Console.WriteLine("Get a value from stack: " + stack.get().ToString() + ", current sum Node in stack = " + stack.SumNode);
                Console.WriteLine("Get a value from stack: " + stack.get().ToString() + ", current sum Node in stack = " + stack.SumNode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
