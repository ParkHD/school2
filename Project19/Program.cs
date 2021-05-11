using System;

namespace Project19
{
    class HeapTree
    {
        class Node
        {
            public int value;       // 값.
            public Node parent;     // 부모 노드.
            public Node left;       // 왼쪽 자식 노드.
            public Node right;      // 오른쪽 자식 노드.

            public Node(Node parent, int value)
            {
                this.value = value;
                this.parent = parent;

                left = null;
                right = null;
            }
        }

        Node root;
        int level;
        int count = 0;

        public HeapTree()
        {
            root = null;
            level = 0;
            count = 0;
        }

        bool IsLeft(int index, int height)
        {
            return ((index >> height) & 1) == 0;
        }

        void CompareParent(Node node)
        {
            Node parent = node.parent;

            // 부모가 없거나.. 부모의 값이 나보다 작을 경우.
            if (parent == null || parent.value < node.value)
                return;

            // 부모 노드의 값이 나보다 큰 경우.
            int temp = parent.value;
            parent.value = node.value;
            node.value = temp;

            CompareParent(parent);
        }
        void CompareChild(Node node)
        {
            bool isLeft = node.left.value < node.right.value;

            // 왼쪽 노드가 나보다 작을 때
            if (isLeft && node.left.value < node.value)
            {
                // Swap...
                CompareChild(node.left);
            }
            // 오른쪽 노드가 나보다 작을 때.
            else if(!isLeft && node.right.value < node.value)
            {
                // Swap....
                CompareChild(node.right);
            }
        }

        Node SearchParent(int index)
        {
            Node parent = root;
            for (int height = level - 1; height > 0; height--)
                parent = IsLeft(index, height) ? parent.left : parent.right;

            return parent;
        }
        public void Add2(int value)
        {
            if(root == null)
            {
                root = new Node(null, value);
                level = 0;
                count = 1;
                return;
            }

            // 1. root가 없으면 root에 추가.
            // 2. 완전 이진트리이기 때문에 가장 마지막 노드에 추가.
            // 3. 자신의 부모 노드와 비교해서 노드 교환s
            int index = count + 1;
            level = (int)Math.Log2(index);

            Node parent = SearchParent(index);
            Node newNode = new Node(parent, value);

            if (IsLeft(index, 0))
                parent.left = newNode;
            else
                parent.right = newNode;

            count += 1;
            CompareParent(newNode);
        }

        public int Get()
        {
            int value = (root == null) ? -1 : root.value;
            Node left = root.left;
            Node right = root.right;
            root = null;

            int index = count - 1;
            bool isLeft = IsLeft(index, 0);
            Node lastNode = isLeft ? SearchParent(index).left : SearchParent(index).right;

            // 내가 루트가 아니면.
            if(lastNode.parent != null)
            {
                if (isLeft)
                    lastNode.parent.left = null;
                else
                    lastNode.parent.right = null;

                root = lastNode;
                root.left = left;
                root.right = right;
            }

            CompareChild(root);
            return value;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            // 이진트리 - 힙(Heap)구조.

            // 우선순위 큐(Priority Queue)
            //  = 우선 순위가 가장 높은 데이터를 먼저 삭제.
            //  = 예시로 가장 가치가 높은 물건부터 처리하고 싶을 때.
            HeapTree heap = new HeapTree();

            for(int i = 1; i<10; i++)
                heap.Add2(i);

        }
    }
}
