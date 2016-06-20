using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class MyStack
    {
        private Node Head;
        private Node Tail;

        /// <summary>
        /// The class constructor.
        /// </summary>
        public MyStack()
        {
            Head = null;
            Tail = null;
        }

        /// <summary>
        /// Check if stack is empty or not.
        /// </summary>
        /// <returns>Return true if stack is empty else return false</returns>
        public bool IsEmpty()
        {
            return (Head == null) ? true : false;
        }

        /// <summary>
        /// Push a node to the stack
        /// </summary>
        /// <param name="node">The node which is pushed to the stack</param>
        public void Push(Node node)
        {
            if (Head == null)
                Head = Tail = node;
            else
            {
                node.Next = Head;
                Head = node;
            }
        }

        /// <summary>
        /// Pop a node from the stack.
        /// </summary>
        /// <returns>Return the top node if stack isn't empty else return null</returns>
        public Node Pop()
        {
            if (Head == null)
                return null;
            else
            {
                if (Head == Tail)
                {
                    Node temp = Head;
                    Head = null;
                    Tail = null;
                    return temp;
                }
                else
                {
                    Node temp = Head;
                    Head = Head.Next;
                    return temp;
                }
            }
        }

        /// <summary>
        /// Get a node from top of the stack
        /// </summary>
        /// <returns>Return node if stack isn't empty else return null</returns>
        public Node Get()
        {
            return Head;
        }

        /// <summary>
        /// print stack
        /// </summary>
        public void PrintStack()
        {
            Node node = Head;
            while (node != null)
            {
                node.PrintNode();
                node = node.Next;
            }
        }
    }
}
