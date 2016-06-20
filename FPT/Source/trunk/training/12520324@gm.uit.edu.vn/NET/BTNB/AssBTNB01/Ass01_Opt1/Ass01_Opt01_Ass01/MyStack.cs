using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass01_Opt01_Ass01
{
    class MyStack
    {
        private List<object> stackValues;
        private int Stacktop;

        public List<object> StackValues
        {
            get { return stackValues; }
            set { stackValues = value; }
        }

        public MyStack()
        {
            stackValues = new List<object>();
            Stacktop = -1;
        }
        public MyStack(List<object> istackValues)
        {
            StackValues = istackValues;
        }

        public void Push(object ivalue)
        {
            if (stackValues == null)
            {
                stackValues.Add(ivalue);
                Stacktop = 0;
            }
            else
            {
                Stacktop++;
                stackValues.Insert(Stacktop, ivalue);
            }
        }

        public void Pop()
        {
            if (stackValues == null)
            {
                Console.WriteLine("Stack is null");
            }
            else
            {
                stackValues.RemoveAt(Stacktop);
                Stacktop--;
            }
        }

        public object Top()
        {
            return stackValues[Stacktop];
        }

        public object Get(int index)
        {
            if (stackValues.Count() > 0)
                return stackValues[index];
            return null;
        }
    }
}
