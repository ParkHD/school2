using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Project16
{
    class MyDictionary
    {
        // 방대한 사전 자료를 저장하는 자료구조.
        CHashTable data;
        int count;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public MyDictionary()
        {
            data = new CHashTable(26);
        }

        public void AddWord(string key, string value)
        {
            data.Add(key, value);
            count++;
        }
        public string SearchWord(string key)
        {
            return data.Get(key);
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

        // 트라이(trie)
        //  = 트리의 형태를 가진 자료구조.
        //  = 문자열에서 검색을 빠르게 하고 싶을 때.
        class Trie
        {
            class Node
            {
                public char key;
                public CDictionary<char, Node> child;
                public string value;

                public Node()
                {
                    key = '0';
                    child = new CDictionary<char, Node>('z' - 'a' + 1);
                    value = string.Empty;
                }
            }

            Node root;
            int count;

            public int Count
            {
                get
                {
                    return count;
                }
            }

            public Trie()
            {
                root = new Node();
                count = 0;
            }

            void AddWord(Node node, string key, int index, string value)
            {
                // node가 마지막 node라면..
                if(index >= key.Length)
                {
                    node.value = value;
                    count++;
                    return;
                }

                char k = key[index];
                Node nextNode = node.child.Get(k);
                if(nextNode == null)
                {
                    Node newNode = new Node();
                    node.child.Add(k, newNode);
                    nextNode = newNode;
                }
                AddWord(nextNode, key, index + 1, value);
            }
            public void AddWord(string key, string value)
            {
                AddWord(root, key, 0, value);
            }

            Node SearchNode(Node node, string key, int index)
            {
                if(index >= key.Length)
                    return node;

                char k = key[index];
                Node nextNode = node.child.Get(k);
                if (nextNode == null)
                    return null;

                return SearchNode(nextNode, key, index + 1);
            }
            public string GetWord(string key)
            {
                Node node = SearchNode(root, key, 0);
                return node == null ? "Not Found" : node.value;
            }
        }

        static MyDictionary dic;
        static Trie trie;

        static void Init()
        {
            dic = new MyDictionary();
            trie = new Trie();

            int width = 3;
            char start = 'a';
            char end = 'z';

            int maxCount = 26 * ((int)Math.Pow(26, width) - 1) / 25;
            Console.WriteLine("최대 개수 : {0}", maxCount);

            char[] word = new char[width];
            for (int i = 0; i < word.Length; i++)
                word[i] = '`';

            while (true)
            {
                word[width - 1]++;      // 마지막 자리를 +1한다.
                for (int i = width - 1; i > 0; i--)
                {
                    if (word[i] > end)
                    {
                        word[i] = start;
                        word[i - 1]++;
                    }
                }

                if (word[0] > end)
                    break;

                string text = string.Empty;

                for (int i = 0; i < width; i++)
                {
                    if (word[i] >= start)
                        text = string.Concat(text, word[i]);
                }

                dic.AddWord(text, text);
                trie.AddWord(text, text);
            }
        }

        static void Main(string[] args)
        {
            Init();

            Stopwatch watch = new Stopwatch();

            while(true)
            {
                Console.Clear();
                Console.WriteLine("총 개수 : {0}", trie.Count);
                Console.Write("검색할 단어를 입력하세요 : ");
                string key = Console.ReadLine();

                // 딕셔너리...
                watch.Start();
                string search = dic.SearchWord(key);
                watch.Stop();
                Console.WriteLine("Dic 검색된 단어 : {0} [{1}ns]", search, watch.ElapsedTicks);

                // 트라이...
                watch.Start();
                search = trie.GetWord(key);
                watch.Stop();

                Console.WriteLine("Trie 검색된 단어 : {0} [{1}ns]", search, watch.ElapsedTicks);
                Console.ReadKey();
            }
        }

    }

    

}
