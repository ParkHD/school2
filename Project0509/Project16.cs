using System;
using System.Collections.Generic;
using System.Text;

namespace Project16
{
    class MyDictionary
    {
        // 방대한 사전 자료를 저장하는 자료구조.
        Dictionary<string, string> data;
        int count;

        public MyDictionary()
        {
            data = new Dictionary<string, string>();

            // 11,881,376.
            for (char word = 'a'; word <= 'z'; word++)
            {
                string text = string.Empty;
                text = string.Concat(text, word);
                Console.WriteLine(text);
                data.Add(text, text);
            }

            
        }

        public void AddWord(string key, string value)
        {
            if (!data.ContainsKey(key))
            {
                data.Add(key, value);
                count++;
            }
            else
                Console.WriteLine("{0}는 이미 있습니다.", key);
        }
        string SearchWord(string key)
        {
            if (!data.ContainsKey(key))
                return "Not Found!";

            return data[key];
        }
        public void Search()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("[검색 기능] : {0}word", count);
                Console.Write("검색할 단어 : ");
                string key = Console.ReadLine();

                if (key.Equals("exit"))
                    return;

                Console.WriteLine("------------------------------");
                if(data.ContainsKey(key))
                    Console.WriteLine(key);
                Console.WriteLine(" - {0}", SearchWord(key));
                Console.WriteLine("------------------------------");
                Console.WriteLine();
                Console.WriteLine("아무 값이나 입력해 주세요...");
                Console.ReadLine();
            }
        }
    }

    class Project16
    {
        #region 트리 설명
        // Array, LinkedList, Stack, Queue : 노드가 1:1인 선형자료구조.
        // 트리(Tree)자료구조
        //   노드가 1:n의 구조를 가진다.

        // 이진트리(Binary Tree)
        // 자식을 최대 2개까지만 가지는 트리구조를 말한다.

        // 이진 검색 트리 (Binary Serach Tree)
        /*  = 부모를 기준으로 작은 노드는 왼쪽, 큰 노드는 오른쪽.
         *            8
         *         /     \
         *        5      15
         *       / \    /
         *      3   6  14
         */

        // 완전 이진 트리 (Complete Binary Tree)
        /*
         * 노드가 왼쪽에서 부터 차있는 상태. (위와 동일)
         */

        public class Node
        {
            public int value;
            public Node left;
            public Node right;

            public Node(int value, Node left, Node right)
            {
                this.value = value;
                this.left = left;
                this.right = right;
            }
        }
        class BinaryTree
        {
            Node root;
            int count;

            public BinaryTree()
            {
                root = null;
                count = 0;
            }

            public Node MakeNode(int value, Node left, Node right)
            {
                count++;
                return new Node(value, left, right);
            }
            public void SetRoot(Node root)
            {
                this.root = root;
            }
            public Node GetRoot()
            {
                return root;
            }

            public void InOrder(Node node)
            {
                if (node == null)
                    return;

                InOrder(node.left);
                Console.Write("{0} ", node.value);
                InOrder(node.right);
            }
            public void PreOrder(Node node)
            {
                if (node == null)
                    return;

                Console.Write("{0} ", node.value);
                PreOrder(node.left);
                PreOrder(node.right);
            }
            public void PostOrder(Node node)
            {
                if (node == null)
                    return;

                PostOrder(node.left);
                PostOrder(node.right);
                Console.Write("{0} ", node.value);
            }
        }

        /*
         *           1
         *         /   \
         *        2     3
         *       / \   
         *      4   5  
         */

        // 트리의 순환 방법.
        // 1. InOrder(중위 순회)   : Left > Root > Right. (4, 2, 5, 1, 3)
        // 2. PreOrder(전위 순회)  : Root > Left > Right. (1, 2, 4, 5, 3)
        // 3. PostOrder(후위 순회) : Left > Right > Root. (4, 5, 2, 3, 1)
        #endregion

        // 트라이(tries)
        //  = 트리의 형태를 가진 자료구조.
        //  = 문자열에서 검색을 빠르게 하고 싶을 때.
        

        static void Main(string[] args)
        {
            if (false)
            {
                BinaryTree tree = new BinaryTree();
                Node n4 = tree.MakeNode(4, null, null);
                Node n5 = tree.MakeNode(5, null, null);
                Node n2 = tree.MakeNode(2, n4, n5);
                Node n3 = tree.MakeNode(3, null, null);
                Node root = tree.MakeNode(1, n2, n3);

                tree.SetRoot(root);
                tree.InOrder(tree.GetRoot()); Console.WriteLine();
                tree.PreOrder(tree.GetRoot()); Console.WriteLine();
                tree.PostOrder(tree.GetRoot()); Console.WriteLine();
            }

            
            // 전자사전을 만든다.
            // 1. 사용자가 값을 추가할 수 있다.
            // 2. 사용자가 값을 검색할 수 있다. (어떠한 단어 : 단어의 뜻....)
            //   ( ex) Dog -> "Dog is cute")
            // 3. 즐겨찾기 한 단어를 따로 보는 기능.

            // 값을 추가하는 함수명 : AddWord(?);
            // 값을 검색하는 함수명 : SearchWord(?);

            MyDictionary dic = new MyDictionary();
            dic.AddWord("Dog", "Dog AAAAA");
            dic.AddWord("Cat", "Cat AAAAA");

            //string text = string.Concat('c', 'c');
            // text >> "cc"

            // 알파벳은 a~z..
            // 1. abcd 검색하면 abcd..
            // 2. aaa 검색하면 aaa..
            // 3. 최대 문자 개수는 5개.

            //dic.Search();
        }

    }

    

}
