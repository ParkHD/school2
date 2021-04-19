using System;
using System.Collections.Generic;
using System.Text;

namespace csProject04
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
        public DNode<T> prevNode;  // 이전 노드.
        public DNode<T> nextNode;  // 다음 노드.
        public T value;

        public DNode(T value)
        {
            this.value = value;
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

    class DoubleList<T>
    {
        // 이중 연결 리스트.
        DNode<T> header;
        int count;

        public int Count
        {
            get
            {
                return count;
            }
        }

        private DNode<T> GetNode(int index)
        {
            DNode<T> result = header;

            // 무언가 갱신이 일어나고...
            if (0 <= index && index < count)
            {
                for (int i = 0; i < index; i++)
                    result = result.nextNode;
            }

            // 리턴.
            return result;
        }

        public DoubleList()
        {
            header = null;
            count = 0;
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

        public void Add(T value)
        {
            DNode<T> newNode = new DNode<T>(value);

            // 아무것도 없을 때.
            if (header == null)
            {
                // 헤더를 새로운 노드로 지정.
                header = newNode;
            }
            else
            {
                // 마지막 노드 갱신.
                DNode<T> lastNode = header;

                for (int i = 0; i < count - 1; i++)
                    lastNode = lastNode.nextNode;

                // 마지막 노드의 다음을 새로운 노드로 지정.
                // 새로운 노드의 이전을 마지막 노드로 지정.
                lastNode.nextNode = newNode;
                newNode.prevNode = lastNode;
            }

            count++;    // 개수 1 증가.
        }
        public void RemoveAt(int index)
        {
            // 유효성 체크.
            if (index < 0 || count <= index)
                return;

            // index값이 유효하다.
            DNode<T> indexNode = GetNode(index);
            DNode<T> prevNode = indexNode.prevNode;
            DNode<T> nextNode = indexNode.nextNode;

            // 이전노드 갱신.
            if (prevNode != null)
            {
                prevNode.nextNode = indexNode.nextNode;
            }
            // 이후노드 갱신.
            if (nextNode != null)
            {
                nextNode.prevNode = indexNode.prevNode;
            }

            count--; // 개수 1 감소.
        }
    }

    // 스택(Stack) : 후입선출의 자료구조. (LIFO : Last-in-First-out);
    // => 웹페이지 뒤로가기.
    // => Undo(되돌리기) : Ctrl + z

    class Stack<T>
    {
        SNode<T> top;
        int count;

        public int Count
        {
            get
            {
                return count;
            }
        }

        // Push : 추가.
        // Pop  : 리턴 후 삭제.
        // Peek : 리턴

        public Stack()
        {
            top = null;
            count = 0;
        }

        public void Push(T value)
        {
            // 새로운 노드 생성.
            SNode<T> newNode = new SNode<T>(value);

            // top이 없을때.
            if (top == null)
            {
                // top에 새로운 노드 대입.
                top = newNode;
            }
            else
            {
                // [순서에 주의하자]
                // 아래 두 줄의 순서가 바뀌면.. 큰일난다.
                newNode.prevNode = top; // 새로운 노드의 이전에 탑 대입.
                top = newNode;          // 새로운 탑 갱신.
            }

            count++;
        }
        public T Pop()
        {
            SNode<T> beforeTop = top;   // 이전 top을 저장.
            top = top.prevNode;         // 새로운 top 갱신.
            count--;                    // 개수 감소.

            return beforeTop.value;     // 이전 top의 값 리턴.
        }
        public T Peek()
        {
            return top.value;
        }
    }
}
