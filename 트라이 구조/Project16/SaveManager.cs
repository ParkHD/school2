using System;
using System.Collections.Generic;
using System.Text;

public enum SAVEDATA
{
    PlayerName,
    PlayerLevel,
    Money,
    Cristal,

    Count,
}
class CDictionary<TKey, TValue>
{
    class Node
    {
        TKey key;
        TValue value;

        public Node(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }
        public TKey Key
        {
            get
            {
                return key;
            }
        }
        public TValue Value
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

    List<Node>[] dataArray;
    int count;

    public int Count
    {
        get
        {
            return count;
        }
    }

    public CDictionary(int size)
    {
        dataArray = new List<Node>[size];
        count = 0;
    }

    int GetHashCode(TKey key)
    {
        int hashCode = 0;
        foreach (char c in key.ToString())
            hashCode += c;
        return hashCode;
    }
    int ConvertToIndex(int hashCode)
    {
        return hashCode % dataArray.Length;
    }
    int KeyToIndex(TKey key)
    {
        int hashCode = GetHashCode(key);
        int index = ConvertToIndex(hashCode);

        return index;
    }
    Node SearchNode(List<Node> list, TKey key)
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

    public void Add(TKey key, TValue value)
    {
        int index = KeyToIndex(key);
        List<Node> list = dataArray[index];

        // 리스트 자체가 생성되지 않았다.
        if (list == null)
        {
            dataArray[index] = new List<Node>();
            list = dataArray[index];
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
    public TValue Get(TKey key)
    {
        int index = KeyToIndex(key);
        List<Node> list = dataArray[index];
        Node node = SearchNode(list, key);

        // Node가 있을 수도 없을 수도 있다.
        return (node == null) ? default(TValue) : node.Value;
    }
}
class SaveManager
{
    CDictionary<SAVEDATA, int> data;

    public SaveManager()
    {
        data = new CDictionary<SAVEDATA, int>(20);
        data.Add(SAVEDATA.PlayerLevel, 1);
        data.Add(SAVEDATA.Money, 1000);
        data.Add(SAVEDATA.Cristal, 100);
    }
    public void SaveData(SAVEDATA type, int value)
    {
        data.Add(type, value);
    }
    public int LoadData(SAVEDATA type)
    {
        return data.Get(type);
    }
}