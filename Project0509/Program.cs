using System;
using System.Collections;
using System.Collections.Generic; // 리스트 관련..
using System.Diagnostics;

namespace ConsoleApp1
{
    class Player
    {
        public string name;
        public int level;

        public Player(string name, int level)
        {
            this.name = name;
            this.level = level;
        }
        public void Show()
        {
            Console.WriteLine("name:{0}, level:{1}", name, level);
        }
    }
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
    class CListTable
    {
        List<Node> list;
        public CListTable()
        {
            list = new List<Node>();
        }

        Node SearchNode(string key)
        {
            foreach (Node node in list)
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
            return node == null ? "Not Value!" : node.Value;
        }
    }
    class CArrayTable
    {
        Node[] array;
        int count;

        public CArrayTable()
        {
            array = new Node[10000];
            count = 0;
        }

        Node SearchNode(string key)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i].Key.Equals(key))
                    return array[i];
            }

            return null;
        }
        public void Add(string key, string value)
        {
            // 최대 크기 넘어서 접근 하면....
            // OutOfRange Error이 괴롭힌다.
            if (count >= array.Length)
                return;

            Node node = SearchNode(key);

            if (node != null)
                node.Value = value;
            else
            {
                // array[count++] >> count:1;
                // 이후에 count:2;
                array[count++] = new Node(key, value);
            }
        }
        public string Get(string key)
        {
            Node node = SearchNode(key);
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


    class Program
    {
        static Stopwatch watch;

        static void StartWatch()
        {
            watch.Restart();
        }
        static void StopWatch(string text)
        {
            watch.Stop();
            Console.WriteLine("{0}:{1}mili", text, watch.ElapsedMilliseconds);
        }

        static void Main2(string[] args)
        {
            if (false)
            {
                CHashTable table = new CHashTable(10);

                table.Add("kim", "name:kim, age:20, gender:male");
                table.Add("lee", "name:lee, age:24, gender:female");
                table.Add("park", "name:part, age:25, gender:male");
                table.Add("seo", "name:seo, age:15, gender:male");

                // 갱신...
                table.Add("kim", "change value...");

                Console.WriteLine(table.Get("kim"));
                Console.WriteLine(table.Get("lee"));
                Console.WriteLine(table.Get("park"));
                Console.WriteLine(table.Get("seo"));

                Console.WriteLine(table.Get("Choi"));
                Console.WriteLine(table.Get("Chon"));

                Console.WriteLine();
                Console.WriteLine("CListTable");
                CListTable list = new CListTable();

                list.Add("kim", "kim is angry!!");
                list.Add("lee", "lee is sleepy..");

                list.Add("lee", "lee changed value");

                Console.WriteLine(list.Get("kim"));
                Console.WriteLine(list.Get("lee"));
                Console.WriteLine(list.Get("park"));

                Console.WriteLine();
                Console.WriteLine("CArrayTable");
                CArrayTable array = new CArrayTable();

                array.Add("AAA", "AAAAAAAAAAAAAAAAAAA");
                array.Add("BBB", "BBBBBBBBBBBBBBBBBBB");
                array.Add("CCC", "CCCCCCCCCCCCCCCCCCC");

                array.Add("CCC", "DDDDDDDDDDDDDDDD");

                Console.WriteLine(array.Get("AAA"));
                Console.WriteLine(array.Get("BBB"));
                Console.WriteLine(array.Get("CCC"));
                Console.WriteLine(array.Get("DDD"));
            }
            if (false)
            {
                watch = new Stopwatch();

                CHashTable hashTable = new CHashTable(10000);
                CArrayTable arrayTable = new CArrayTable();
                CListTable listTable = new CListTable();

                Random random = new Random();

                Console.WriteLine("10000개 생성 시간");

                const int maxCount = 100000;

                StartWatch();
                for (int i = 0; i < maxCount; i++)
                {
                    string key = string.Format("Player{0}", i);
                    listTable.Add(key, string.Empty);
                }
                StopWatch("List");

                StartWatch();
                for (int i = 0; i < maxCount; i++)
                {
                    string key = string.Format("Player{0}", i);
                    arrayTable.Add(key, string.Empty);
                }
                StopWatch("Array");

                StartWatch();
                for (int i = 0; i < maxCount; i++)
                {
                    string key = string.Format("Player{0}", i);
                    hashTable.Add(key, string.Empty);
                }
                StopWatch("Hash");

                Console.WriteLine();
                Console.WriteLine("임의의 키 값 10000만번 접근");

                StartWatch();
                for (int i = 0; i < maxCount; i++)
                {
                    string key = string.Format("Player{0}", random.Next(maxCount));
                    string value = listTable.Get(key);
                }
                StopWatch("List");

                StartWatch();
                for (int i = 0; i < maxCount; i++)
                {
                    string key = string.Format("Player{0}", random.Next(maxCount));
                    string value = arrayTable.Get(key);
                }
                StopWatch("Array");

                StartWatch();
                for (int i = 0; i < maxCount; i++)
                {
                    string key = string.Format("Player{0}", random.Next(maxCount));
                    string value = hashTable.Get(key);
                }
                StopWatch("Hash");
            }
            if (false)
            {
                SaveManager sm = new SaveManager();

                int money = sm.LoadData(SAVEDATA.Money);

                Console.WriteLine("Money : {0}", money);
                money += 1000;
                money -= 200;
                money += 2500;
                sm.SaveData(SAVEDATA.Money, money);

                Console.WriteLine("Money : {0}", sm.LoadData(SAVEDATA.Money));
            }
            if (false)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("Kim", "Kim is Angray!!");
                dic.Add("LEE", "Lee is Hungry..");

                if (dic.ContainsKey("LEE"))
                    dic["LEE"] = "Lee is Happy!!";
                else
                    dic.Add("LEE", "Lee is Happy");

                Console.WriteLine(dic["Kim"]);
                Console.WriteLine(dic["LEE"]);

                if (dic.ContainsKey("Seo"))
                    Console.WriteLine(dic["Seo"]);

                Hashtable hash = new Hashtable();

                hash.Add(10, "AAAAA");
                hash.Add("Kim", "Kim is......?");
                hash.Add("Lee", new Player("Lee", 10));

                if (hash.Contains(10))
                {
                    string value = (string)hash[10];
                    Console.WriteLine(value);
                }
                if (hash.Contains("Lee"))
                {
                    Player player = (Player)hash["Lee"];
                    player.Show();
                }
            }

            /*
             * [Dictionary]
             * 장점
             *  - 박싱, 언박싱이 일어나지 않는다.
             *  - 형변환이 필요가 없다.
             *  - Generic.
             * 단점
             *  - Generic타입이라서 여러가지 자료형은 못 넣는다.
             * 
             * [Hashtable]
             * 잠점
             *  - 여러가지 자료형을 저장할 수 있다.
             *  - Non-Generic.
             * 단점
             *  - 박싱, 언박싱이 일어난다.
             *  - 형변환이 실패할 수도 있다. (Error)
             *  
             *  박싱
             *   > 자료형을 object로 감싸는 행위.
             *  언박싱
             *   > 감싼 자료형을 다시 가져오는 행위.(이때 가비지가 생성된다.)
             */
        }
    }
}

