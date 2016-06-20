using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack stack = new MyStack();
            stack.Push(12112);
            stack.Pop();
            for (int i = 0; i < stack.Count(); i++)
            {
                System.Console.WriteLine(stack.Get(i).ToString());
            }
            System.Console.ReadLine();
        }
    }
}
