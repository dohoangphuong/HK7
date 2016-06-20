using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class Node
    {
        private int intValue;
        public int Value
        {
            get { return intValue; }
            set { intValue = value; }
        }

        private Node NodeNext;
        internal Node Next
        {
            get { return NodeNext; }
            set { NodeNext = value; }
        }

        /// <summary>
        /// The class constructor.
        /// </summary>
        public Node()
        {
            NodeNext = null;
            intValue = 0;
        }

        /// <summary>
        /// The class constructor with one parameter.
        /// </summary>
        /// <param name="value">Value of Node</param>
        public Node(int value)
        {
            NodeNext = null;
            intValue = value;
        }

        /// <summary>
        /// Print node
        /// </summary>
        public void PrintNode()
        {
            Console.Write("{0} ", intValue);
        }
    }
}
