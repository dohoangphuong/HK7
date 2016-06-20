using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_1
{
    public class MyStack
    {
        private int top;
        private List<object> data;

        public MyStack()
        {
            this.top = 0;
            data = new List<object>();
        }

        public void Push(object value)
        {
            data.Add(value);
            top++;
        }

        public Boolean Empty()
        {
            return (data.Count() > 0) ? false : true;
        }

        public void Pop()
        {
            if (!Empty())
            {
                data.RemoveAt(--top);
            }
            else
            {
                System.Console.WriteLine("Stack is empty. Can't pop.");
            }
        }

        public object Get(int index)
        {
            if (index >= top)
                return null;
            return data[index];
        }

        public int Count()
        {
            return top;
        }
    }
}
