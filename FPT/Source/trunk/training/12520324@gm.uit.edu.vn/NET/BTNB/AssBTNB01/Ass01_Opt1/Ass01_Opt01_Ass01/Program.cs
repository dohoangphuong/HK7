using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass01_Opt01_Ass01
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack st = new MyStack();
            System.Console.Write("Input stack:  ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} ", i);
                st.Push(i);
            }
            System.Console.WriteLine();
            System.Console.Write("Output stack: " );
            while ((int)st.Top() != 0)
            {
                System.Console.Write("{0} ", st.Top());
                st.Pop();
            }
        }
    }
}
