using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack stack = new MyStack();
            stack.push(5);
            stack.push(6);
            stack.push(7);
            stack.push(8);
            stack.push(9);
            stack.push(10);
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.get(1));
            Console.ReadKey();
        }
    }

    class MyStack
    {
        Stack<int> stackValues;

        public MyStack()
        {
            stackValues = new Stack<int>();
        }

        public void push(int value)
        {
            stackValues.Push(value);
        }

        public int pop()
        {
            return stackValues.Pop();
        }

        public int get(int index)
        {
            return stackValues.ElementAt(index);
        }
    }
}
