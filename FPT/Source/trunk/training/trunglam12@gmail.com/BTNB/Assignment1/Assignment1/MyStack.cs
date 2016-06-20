using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class MyStack
    {
      private object stackValues;
      private List<object> containValue;

     public MyStack()
      {
          containValue = new List<object>();
          stackValues = 0;
      }

     public void Push(object values)
      {
          containValue.Add(values);
      
      }

     public void Pop()
     {
         containValue.RemoveAt(containValue.Count-1);
     }

     public object get()
     {
         return containValue[containValue.Count-1];
     }
    
    }
}
