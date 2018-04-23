using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Queue
    {
        public class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
            
            public Node()
            {
                Value = 0;
                Next = null;
            }
            public Node(int item)
            {
                Value = item;
                Next = null;
            }
            public Node(int item, Node next)
            {
                Value = item;
                Next = next;
            }
        }

        public Node head;
        private Node tail;

        public Queue()
        {
            head = null;
            tail = head;
        }

        public bool Enqueue(int item)
        {
            try
            {
                if(head == null)
                {
                    Node insert = new Node(item);
                    head = insert;
                    tail = head;
                    return true;
                }
                else
                {
                    Node insert = new Node(item);
                    tail.Next = insert;
                    tail = insert;
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public Node Dequeue()
        {
            try
            {
                if (head == null)
                {
                    return null;
                }
                else
                {
                    int temp = head.Value;
                    Node delete = head;
                    head = head.Next;
                    return delete;
                }
            }
            catch
            {
                return null;
            }
            
        }
    }
}
