/*
Summary: BTNB - ASS01_Opt1 - Assignment 01 - Create MyStack class following feature: Push, Pop, Get
Account: quanlm.271@gmail.com
Class : 052_HCM_UIT_04_NET
Date Modified: 27/07/2015
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS01
{
    class MyStack
    {
        private List<int> Elements; //List Elements of stack, type int
        private int top; //the last element has been pushed into array

        //Contructor to create a new stack
        public MyStack() {
            Elements = new List<int>();
            top = -1;
        }

        //Put new value to top of stack list
        public void push(int value) {
            Elements.Add(value);
            top++;

        }

        //Remove the last element has been pushed and return value
        public int pop() {
            if (top < 0)    //stack empty
                Console.WriteLine("Stack Empty!");
            int oldTop = Elements[top];
            Elements.RemoveAt(top--); //Remove element at top
            return oldTop; // return and count down top              

        }

        //Get one value from stack by index
        public int get(int index) {
            return index > top ? 0: Elements[index];        
        }

        public int size()
        {
            return top + 1;
        }
    }
}
