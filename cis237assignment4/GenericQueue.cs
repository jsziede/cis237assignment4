//Joshua Sziede

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //class used to store generics in a queue
    class GenericQueue<T>
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
        public GenericQueue()
        {
            Head = null;
            Tail = null;
            Current = null;
        }

        //method to add droids to the queue
        public void Enqueue(T content)
        {
            //node instanciation
            GenericNode<T> Node = new GenericNode<T>();

            //the data of the node is set to the data of droid that was passed in
            Node.Data = content;

            //if there is no head, then we set head to the passed in droid
            if (Head == null)
            {
                Head = Node;
            }

            //if tail is not null, then we set the tail's pointer to the droid
            if (Tail != null)
            {
                Tail.Next = Node;
            }

            //the tail is now the droid that was passed in
            Tail = Node;
        }

        //method to remove a droid from the queue
        public T Dequeue()
        {
            //if head is null, we return the default value of type T
            if (Head == null)
            {
                return default(T);
            }

            //Current is set to the data of the head node
            T Current = Head.Data;

            //the head is now set to the second node in the queue
            Head = Head.Next;

            //if head is null, then tail is also null
            if (Head == null)
            {
                Tail = null;
            }

            //the data from the current node is returned from the dequeue
            return Current;
        }
    }
}
