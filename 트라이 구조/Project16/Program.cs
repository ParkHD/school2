using System;
using System.Collections;
using System.Collections.Generic; // 리스트 관련..
using System.Diagnostics;

class CHashTable
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
            get
            {
                return key;
            }
        }
        public string Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    List<Node>[] tableArray;
    public CHashTable(int size)
    {
        tableArray = new List<Node>[size];
    }
    int GetHashCode(string key)
    {
        int hashCode = 0;
        foreach (char c in key)
            hashCode += c;
        return hashCode;
    }
    int ConvertToIndex(int hashCode)
    {
        // 0 ~ (tableArray의 크기 - 1)
        return hashCode % tableArray.Length;
    }
    Node SearchNode(List<Node> list, string key)
    {
        // 리스트가 없다.
        if (list == null)
            return null;

        foreach (Node node in list)
        {
            // 해당 리스트에 내가 찾는 키 값을 가진 Node가 있다.
            if (node.Key.Equals(key))
                return node;
        }

        // 해당 리스트에 내가 찾는 키 값을 가진 node가 없다.
        return null;
    }

    int KeyToIndex(string key)
    {
        int hashCode = GetHashCode(key);
        int index = ConvertToIndex(hashCode);

        return index;
    }

    public bool Contains(string key)
    {
        int index = KeyToIndex(key);
        List<Node> list = tableArray[index];

        // 해당 index번째의 리스트 자체가 없다.
        if (list == null)
            return false;

        foreach (Node node in list)
        {
            if (node.Key.Equals(key))
                return true;
        }

        return false;
    }
    public void Add(string key, string value)
    {
        int index = KeyToIndex(key);
        List<Node> list = tableArray[index];

        // 리스트 자체가 생성되지 않았다.
        if (list == null)
        {
            tableArray[index] = new List<Node>();
            list = tableArray[index];
        }

        // 노드 검색.
        Node node = SearchNode(list, key);

        // 동일한 노드가 없다면 새로 Node를 생성.
        if (node == null)
            list.Add(new Node(key, value));
        // 동일한 노드가 있다면 Value값만 갱신.
        else
            node.Value = value;
    }
    public string Get(string key)
    {
        int index = KeyToIndex(key);
        List<Node> list = tableArray[index];
        Node node = SearchNode(list, key);

        // Node가 있을 수도 없을 수도 있다.
        return (node == null) ? "Not Value" : node.Value;
    }
}

//watch?v=KgRG4JVYnns?t=60

// class Dictionary;
// 원리 : HashTable이랑 동일.
// 키는 string, 값은 Player.
// 키는 string, 값은 int.
// 키는 Player, 값은 string.

// 일반화(Generic) : T


