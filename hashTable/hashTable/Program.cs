using System;
using System.Collections.Generic;

namespace hashTable
{
    class Node
    {
        string key;
        string value;

        public Node(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
        public string Key
        {
            get { return key; }
        }
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
    class CHashTable
    {
        List<Node>[] tableArray;

        public CHashTable(int size)
        {
            tableArray = new List<Node>[size];
        }
        int GetHashCode(string key)
        {
            int hashCode = 0;
            foreach(char c in key)
            {
                hashCode += c;
            }
            return hashCode;
        }
        int ConvertToIndex(int hashCode)
        {
            return hashCode % tableArray.Length ;

        }
        int keyToIndex(string key)
        {
            int hashCode = GetHashCode(key);
            int index = ConvertToIndex(hashCode);

            return index;
        }
        Node SearchNode(List<Node> list, string key)
        {
            if (list == null)
                return null;
            foreach(Node node in list)
            {
                if (node.Key.Equals(key))
                    return node;
            }
            return null;
        }
       
        public bool Contains(string key)
        {
            int index = keyToIndex(key);
            List<Node> list = tableArray[index];

            if (list == null)
                return false;
            foreach(Node node in list)
            {
                if (node.Key.Equals(key))
                    return true;
            }
            return false;
        }
        public void Add(string key, string value)
        {
            int index = keyToIndex(key);
            List<Node> list = tableArray[index];
            if(list == null)
            {
                tableArray[index] = new List<Node>();
                list = tableArray[index];
            }
            Node node = SearchNode(list, key);
            if (node == null)
                list.Add(new Node(key, value));
            else
                node.Value = value;
        }
        public string Get(string key)
        {
            int hasgCode = GetHashCode(key);
            int index = ConvertToIndex(hasgCode);

            List<Node> list = tableArray[index];
            Node node = SearchNode(list, key);

            return (node == null) ? "Not Value" : node.Value;
        }
    }
    class CListTable
    {
        List<Node> list;
        public CListTable()
        {
            list = new List<Node>();
        }
        Node SearchNode(string key)
        {
            foreach(Node node in list)
            {
                if (node.Key.Equals(key))
                    return node;
            }
            return null;
        }
        public void Add(string key, string value)
        {
            Node node = SearchNode(key);
            if (node == null)
                list.Add(new Node(key, value));
            else
                node.Value = value;
        }
        public string Get(string key)
        {
            Node node = SearchNode(key);
            return node == null ? "Not value" : node.Value;
        }
    }
    class CArrayTable
    {
        Node[] array;
        int count = 0;
        public CArrayTable(int size)
        {
            array = new Node[size];
        }
        Node SearchNode(string key)
        {
            for(int i = 0;i<count;i++)
            {
                if (array[i] == null)
                    return null;
                if (array[i].Key.Equals(key))
                    return array[i];
            }
            return null;
        }
        public void Add(string key, string value)
        {
            Node node = SearchNode(key);
            if (node == null)
            {
                array[count++] = new Node(key,value);
            }
            else
                node.Value = value;
        }
        public string Get(string key)
        {
            Node node = SearchNode(key);
            return node == null ? "Not value" : node.Value;
        }
    }
    class Dictionary<T, V>
    {

    }
   
    class Program
    {
        static void Main(string[] args)
        {
            //CHashTable table = new CHashTable(10);

            //table.Add("kim", "name : kim, age : 20, gender : male");
            //table.Add("lee", "name : lee, age : 23, gender : male");
            //table.Add("lee", "name : lee, age : 21, gender : female");
            //table.Add("park", "name : park, age : 20, gender : male");

            //Console.WriteLine(table.Get("lee"));

            CArrayTable Atable = new CArrayTable(10);
            Atable.Add("kim", "HD");
           
            Console.WriteLine(Atable.Get("kim"));
        }
    }
}
