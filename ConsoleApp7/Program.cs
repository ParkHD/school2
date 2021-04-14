using System;
using System.Collections.Generic;

namespace ConsoleApp7
{
    class Node<T>
    {
        //Node preNode;
        Node<T> nextNode;
        public T value;
        public Node<T> NextNode
        {
            get
            { return nextNode; }
            set
            {
                nextNode = value;
            }
        }
        public Node()
        {
        }
        public Node(T value)
        {
            this.value = value;
            nextNode = null;
        }
        public void LinkedNextNode(Node<T> nextNode)
        {
            this.nextNode = nextNode;
        }
    }
    class CLinkedList<T>
    {
        Node<T> header;
        int count;
        Node<T> lastNode;
        public int Count
        {
            get { return count; }
        }
        public CLinkedList()
        {
            header = new Node<T>();
            lastNode = header;
            count = 0;
        }
        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            lastNode.LinkedNextNode(newNode);
            lastNode = newNode;
            count++;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index > count)
                return;
            Node<T> node = header;
            for (int i = 0; i < index; i++)
            {
                node = node.NextNode;
            }
            node.NextNode = (node.NextNode).NextNode;
            count--;
        }
        public void Remove(T value)
        {
            Node<T> node = header;
            for (int i = 0; i < count; i++)
            {
                node = node.NextNode;
                if (node.value.Equals(value))
                {
                    RemoveAt(i);
                    break;
                }
            }
        }
        public T this[int index]
        {
            get
            {
                Node<T> node = header;
                index++;
                for(int i =0;i<index;i++)
                {
                    node = node.NextNode;
                }
                return node.value;
            }
            set
            {
                Node<T> node = header;
                index++;
                for (int i = 0; i < index; i++)
                {
                    node = node.NextNode;
                }
                node.value = value;
            }
        }
    }
    class Item
    {
        public int money = 0;
        public Item(int money)
        {
            this.money = money;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CLinkedList<string> linkedList = new CLinkedList<string>();
            linkedList.Add("ABC");
            linkedList.Add("BCD");
            linkedList.Add("CED");
            linkedList.Add("DCD");
            linkedList.Add("CDC");
            linkedList.RemoveAt(1);
            linkedList.Remove("ABC");
            linkedList.Remove("C");

            for (int i = 0;i<linkedList.Count;i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            CLinkedList<int> linkedList1 = new CLinkedList<int>();
            linkedList1.Add(1);
            linkedList1.Add(2);
            linkedList1.Add(3);
            linkedList1.Add(4);
            linkedList1.Add(3);
            linkedList1.RemoveAt(-1);
            linkedList1.Remove(3);
            linkedList1.Remove(4);

            for (int i = 0; i < linkedList1.Count; i++)
            {
                Console.WriteLine(linkedList1[i]);
            }
            Item x = new Item(100);
            CLinkedList<Item> list = new CLinkedList<Item>();
            list.Add(x);
            Console.WriteLine(list[0].money);
        }
    }
}
