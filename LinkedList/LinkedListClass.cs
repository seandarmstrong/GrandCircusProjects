using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListExample
{
    //Non-Generic LinkedList
    public class LinkedListClass
    {
        public LinkedListClass()
        {
            Head = new Node();
            Current = Head;
        }

        public Node Head;
        public Node Current;
        public int Count = 0;

        public void AddAtStart(object value)
        {
            var newNode = new Node()
            {
                Value = value
            };
            newNode.Next = Head.Next;
            Head.Next = newNode;
            ++Count;
        }

        public void RemoveFromStart()
        {
            if (Count <= 0)
            {
                throw new Exception("There are no elements to remove");
            }

            Head.Next = Head.Next.Next;
            --Count;
        }

        public void PrintAllNodes()
        {
            Console.Write("Head -> ");
            Node curr = Head;
            while (curr.Next != null)
            {
                curr = curr.Next;
                Console.Write(curr.Value); //If using a reference type (any class/interface), you will need to override ToString for this to work.
                Console.Write(" -> ");
            }
            Console.Write("NULL");
            Console.WriteLine();
        }

        //new method for lab 18 1.a
        public bool RemoveAt(int index)
        {
            if (index == 0)
            {
                Head.Next = Head.Next.Next;
                Count--;
                return true;
            }

            if (index > 0 && index <= Count)
            {
                Node curr = Head;
                for (int i = 0; i < index; i++)
                {
                    curr = curr.Next;
                    if (i == (index - 1) || index == 0)
                    {
                        curr.Next = curr.Next.Next;
                        --Count;
                        return true;
                    }
                }
            }

            return false;
        }

        //new method for lab 18 1.b
        public void PrintReverse()
        {
            Node curr = Head;
            while (curr != null && curr.Next != null)
            {
                Node tmp = curr.Next.Next;
                curr.Next.Next = Head;
                Head = curr.Next;
                curr.Next = tmp;
            }
            PrintAllNodes();
        }

        //another method algorithm i tried after research that opperates the same way as the one above
        /*public void PrintReverse()
        {
            Node prev = null;
            Node curr = null;
            Node next = Head;
            while (next != null)
            {
                curr = next;
                next = curr.Next;
                curr.setNext(prev);
                prev = curr;
            }
            Head = curr;
            Console.Write("Head -> ");
            while (curr.Next != null)
            {
                curr = curr.Next;
                Console.Write(curr.Value); //If using a reference type (any class/interface), you will need to override ToString for this to work.
                Console.Write(" -> ");
            }
            Console.Write("NULL");
            Console.WriteLine();
        }*/

        //new method for lab 18 1.c
        public bool InsertAt(int index, string name)
        {
            if (index == 0)
            {
                var newNode = new Node()
                {
                    Value = name
                };
                newNode.Next = Head.Next;
                Head.Next = newNode;
                Count++;
                return true;
            }

            if (index > 0 && index <= Count)
            {
                Node curr = Head;
                for (int i = 0; i < index; i++)
                {
                    curr = curr.Next;
                    if (i == (index - 1) || index == 0)
                    {
                        Node temp = new Node()
                        {
                            Value = name
                        };
                        temp.Next = curr.Next;
                        curr.Next = temp;
                        Count++;
                        return true;
                    }
                }
            }

            return false;
        }

    }

    //Linked List using Generics
    class LinkedList<T> where T : class
    {
        public LinkedList()
        {
            Head = new Node<T>();
            Current = Head;
        }
        public Node<T> Head;
        public Node<T> Current;
        public int Count = 0;

        public void AddAtStart(T value)
        {
            var newNode = new Node<T>()
            {
                Value = value
            };
            newNode.Next = Head.Next;
            Head.Next = newNode;
            ++Count;
        }

        public void RemoveFromStart()
        {
            if (Count <= 0)
            {
                throw new Exception("There are no elements to remove");
            }

            Head.Next = Head.Next.Next;
            --Count;
        }

        public void PrintAllNodes()
        {
            Console.Write("Head -> ");
            Node<T> curr = Head;
            while (curr.Next != null)
            {
                curr = curr.Next;
                Console.Write(curr.Value);
                Console.Write(" -> ");
            }
            Console.Write("NULL");
            Console.WriteLine();
        }
    }
}
