using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class MyStack<T>
    {
        private int stackValue;

        public int StackValue
        {
            get { return stackValue; }
            set { stackValue = value; }
        }

        private int max,top; // max : the maxnimum element of stack, top : the first position.
        private T[] stack;

        public MyStack(int n=0)
        {
            max = n;
            stack = new T[max];
            stackValue = top = 0;
        }

        public void Push(T elem)
        {
            stack[top] = elem;
            if (stackValue < max)
                stackValue++;
            top = (top + 1) % max;
        }

        public T Pop()
        {
            if (stackValue == 0)
                throw new NullReferenceException("Empty ");
            if (top == 0)
                top = max - 1;
            else
                --top;
            var elem = stack[top];
            stackValue--;
            return elem;
        }

        public T Get(int position)
        {
            if (stackValue == 0)
                throw new NullReferenceException("Empty");
            var elem = stack[position];
            return elem;
        }
    }
}
