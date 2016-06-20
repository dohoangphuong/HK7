using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1_opt1
{
    class MyStack
    {
        private Node _headNode; // head-node
        internal Node HeadNode
        {
            get { return _headNode; }
            set { _headNode = value; }
        }

        private static int _sumNode; // sum node in stack
        public int SumNode
        {
            get { return _sumNode; }
            set { _sumNode = value; }
        }

        private Node _tailNode; // tail-node
        internal Node TailNode
        {
            get { return _tailNode; }
            set { _tailNode = value; }
        }

        public MyStack()
        {
            _headNode = null;
            _tailNode = null;
            _sumNode = 0;
        }

        /* Push a value to stack: add a value-node to tail stack
         * Input: object - node value
         * Output: 
         */
        public void push(Object value)
        {
            try
            {
                // create a new stack-node
                Node newNode = new Node();

                // add value, object, to node
                newNode.StackValue = value;

                // add node to stack
                if (_headNode == null || _sumNode == 0) // check stack is null
                {
                    newNode.PreviousNode = null;
                    newNode.NextNode = null;
                    _headNode = newNode;
                    _tailNode = newNode;
                    _sumNode++;
                }
                else if (_sumNode == 1) // check stack have a node -> head-node = tail-node
                {
                    newNode.PreviousNode = _headNode;
                    newNode.NextNode = null;
                    _tailNode = newNode;
                    _sumNode++;
                }
                else // check stack have least 2 node
                {
                    newNode.PreviousNode = _tailNode;
                    newNode.NextNode = null;
                    _tailNode = newNode;
                    _sumNode++;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* Pop a value to stack: get a value-node from tail stack then remove it from stack
         * Input: 
         * Output: object - tail-node value
         */
        public Object pop()
        {
            try
            {
                // define result object
                Object result = null;

                // get value for result
                if(_sumNode < 1) // check stack is null
                {
                    throw new Exception("Stack is null!");
                }
                else // check stack is not null
                {
                    // assign value to result
                    result = _tailNode.StackValue;

                    // remove node from stack and update tail-node
                    if (_tailNode.PreviousNode != null) // check stack have least 2 node
                    {
                        _tailNode = _tailNode.PreviousNode;
                        _tailNode.NextNode = null;
                    }
                    else // check stack have 1 node only
                    {
                        _tailNode = _headNode = null;
                    }

                    // update sum-node
                    _sumNode--;
                    return result;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* Get a value to stack: get a value-node from head (top) stack without remove it from stack
         * Input: 
         * Output: object - head-node (top-node) value
         */
        public Object get()
        {
            try
            {
                // define result object
                Object result = null;

                // get value for result
                if (_headNode != null) // check stack is not null
                {
                    result = _headNode.StackValue;
                    return result;
                }
                else // check stack is null
                {
                    throw new Exception("Stack is null!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
