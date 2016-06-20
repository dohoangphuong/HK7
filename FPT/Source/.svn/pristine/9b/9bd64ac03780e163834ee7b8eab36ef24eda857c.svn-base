using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ass01_Opt1_Ass1
{
    public class MyStack
    {
        private List<object> stackValues;

        public MyStack()
        {
            stackValues = new List<object>();
        }

        public void Push(object obj)
        {
            if (obj != null)
            {
                stackValues.Add(obj);
            }
        }

        public object Pop()
        {
            if (stackValues.Count != 0)
            {
                object objTemp = stackValues[stackValues.Count - 1];
                if (stackValues.Remove(objTemp))
                {
                    return objTemp;
                }
            }

            return null;
        }

        public object Get()
        {
            if (stackValues.Count != 0)
            {
                return stackValues[stackValues.Count - 1];
            }
            return null;
        }

    }
}
