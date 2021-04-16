using System;
using System.Collections.Generic;

namespace ConsoleApp10
{
    class Node<T>
    {
        public Node<T> nextNode;
        public T value;
        public Node(T value)
        {
            this.value = value;
        }
    }
    class DNode<T>
    {
        public DNode<T> prevNode;
        public DNode<T> nextNode;
        public T value;
        public DNode(T value)
        {
            this.value = value;
        }
    }
    class DoubleList<T>
    {
        DNode<T> header;
        int count;
        public int Count
        {
            get { return count; }
        }
        public DoubleList()
        {
            header = null;
            count = 0;
        }
        private DNode<T> GetNode(int index)
        {
            DNode<T> result = header;
            if (index < 0 || count <= index)
                return null;
            
            for(int i =0;i<index;i++)
            {
                result = result.nextNode;
            }
            return result;
        }
        public void Add(T value)
        {
            DNode<T> newNode = new DNode<T>(value);
            if (header == null)
            {
                header = newNode;
            }
            else
            {
                DNode<T> lastNode = header;
                for (int i = 0; i < count-1; i++)
                {
                    lastNode = lastNode.nextNode;
                }
                lastNode.nextNode = newNode;
                newNode.prevNode = lastNode;
            }
            count++;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || count <= index)
                return;
            DNode<T> indexNode = header;
            for(int i =0;i<index;i++)
            {
                indexNode = indexNode.nextNode;
            }
            DNode<T> prevNode = indexNode.prevNode;
            DNode<T> nextNode = indexNode.nextNode;
            if(prevNode != null)
            {
                prevNode.nextNode = indexNode.nextNode;
            }
            if(nextNode != null)
            {
                nextNode.prevNode = indexNode.prevNode;
            }
        }
        public T this[int index]
        {
            get
            {
                DNode<T> node = GetNode(index);
                return node.value; 
            }
            set
            {
                DNode<T> node = GetNode(index);
                node.value = value;
            }
        }
        public T getValue()
        {
            return header.value;
        }
    }
    class CircleList<T>
    {
        Node<T> cursor;
        int count;
        public int Count
        {
            get { return count; }
        }
        public CircleList()
        {
            cursor = null;
            count = 0;
        }
        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (cursor == null)
            {
                cursor = newNode;
                newNode.nextNode = newNode;
            }
            else
            {
                newNode.nextNode = cursor.nextNode;
                cursor.nextNode = newNode;
                cursor = newNode;
            }
            count++;
        }
        public void RemoveAt(int index)
        {
            if(count <= 1)
            {
                cursor = null;
                return;
            }
            else
            {
                Node<T> prevNode = cursor;
                for (int i = 0; i < index; i++)
                {
                    prevNode = prevNode.nextNode;
                }
                Node<T> indexNode = prevNode.nextNode;
                Node<T> nextNode = indexNode.nextNode;
                indexNode = null;
                prevNode.nextNode = nextNode;
                count--;
            }
        }
        public T GetValue()
        {
            return cursor.value;
        }
        public T this[int index]
        {
            get
            {
                Node<T> nowNode = cursor;
                for(int i =0;i<= index; i++)
                {
                    nowNode = nowNode.nextNode;
                }
                return nowNode.value;
            }
            set
            {
                Node<T> nowNode = cursor;
                for (int i = 0; i <= index; i++)
                {
                    nowNode = nowNode.nextNode;
                }
               nowNode.value = value;
            }
        }
    }
    class SNode<T>
    {
        public SNode<T> prevNode;
        public T value;
        public SNode(T value)
        {
            this.value = value;
        }
    }
    class Stack<T>
    {
        SNode<T> top;
        int count;
        public int Count
        {
            get { return count; }
        }
        public Stack()
        {
            top = null;
            count = 0;
        }
        public void Push(T value)
        {
            SNode<T> newNode = new SNode<T>(value);

            if (top == null)
                top = newNode;
            else
            {
                newNode.prevNode = top;
                top = newNode;
            }
            count++;
        }
        public T Pop()
        {
            SNode<T> newNode = top;
            top = top.prevNode;
            count--;
            return newNode.value;
        }
        public T Peek()
        {
            return top.value;
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            List<Stack<string>> list = new List<Stack<string>>();
            Console.Write("페이지 입력하세요 : ");
            string s1 = Console.ReadLine();
            stack.Push(s1);
            list.Add(stack);

            int count = 1;

            Stack<string> nowStack = new Stack<string>();
            nowStack = stack;
            while (true)
            {
                if(nowStack.Count == 0)
                {
                    Console.Write("페이지 입력하세요 : ");
                    s1 = Console.ReadLine();
                    nowStack.Push(s1);
                }
                
                Console.WriteLine("뒤로가기[{0}], {2}페이지 : {1}", nowStack.Count <= 1 ? "x" : "o", nowStack.Peek(),count);
                Console.Write("페이지 입력하세요 : ");
                s1 = Console.ReadLine();

                switch(s1)
                {
                    case "Back":
                        nowStack.Pop();
                        break;
                    case "New":
                        count++;
                        Stack<string> stack1 = new Stack<string>();
                        nowStack = stack1;
                        
                        list.Add(stack1);
                        break;
                    case "Tab":
                        break;
                    default:
                        nowStack.Push(s1);
                        break;
                }
                //stack.Push(s1);
            }
        }
    }
}
