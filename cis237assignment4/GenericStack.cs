//Joshua Sziede

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //generic stack class
    class GenericStack<T>
    {
        //node that will point to the current node we are looking at
        public GenericNode<T> Current
        {
            get;
            set;
        }

        //node that will point to the beginning of the linked list
        public GenericNode<T> Head
        {
            get;
            set;
        }

        //node that will point to the last node in the linked list
        public GenericNode<T> Tail
        {
            get;
            set;
        }

        //constructor. just initialize the properties to null
        public GenericStack()
        {
            Head = null;
            Tail = null;
            Current = null;
        }

        public void Push(T content)
        {
            //just make another pointer that points to the first node in the linked list
            GenericNode<T> oldFirst = Head;
            //overwrite head with a new generic node
            Head = new GenericNode<T>();
            //set the data on the node
            Head.Data = content;
            //make head's next point to the old first
            Head.Next = oldFirst;
        }

        public T Pop()
        {
            //make a return node and set it to the head, which is the first node in the linked list
            GenericNode<T> returnNode = Head;
            //move the head to the next node in the linked list
            Head = Head.Next;
            //check to see if head is null, if so, set tail to null as well. list is empty
            if (Head == null)
            {
                Tail = null;
            }
            //return the data
            return returnNode.Data;
        }
    }
}
