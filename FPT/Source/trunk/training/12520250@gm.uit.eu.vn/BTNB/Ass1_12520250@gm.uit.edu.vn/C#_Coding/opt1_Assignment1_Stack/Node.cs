using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1_opt1
{
    class Node
    {
        private Object _nodeValue;
        private Object _stackValue;

        public Object StackValue
        {
            get { return _stackValue; }
            set { _stackValue = value; }
        }
        private Node _previousNode; // Previous Node 

        internal Node PreviousNode
        {
            get { return _previousNode; }
            set { _previousNode = value; }
        }
        private Node _nextNode; // Next Node

        internal Node NextNode
        {
            get { return _nextNode; }
            set { _nextNode = value; }
        }

        public Node()
        {
            _nodeValue = null;
            _previousNode = null;
            _nextNode = null;
        }

    }
}
