using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    public interface IBunker
    {
        void InBunker();
        void OutBunker();
    }
    public class Unit
    {
        protected string name;
        public string Name
        {
            get 
            {
                return name;
            }
        }
    }
    public class Terran : Unit 
    {
    }
    public class Marine : Terran, IBunker
    {
        public Marine(string name)
        {
            this.name = name;
        }
        void IBunker.InBunker()
        {
            Console.WriteLine("{0}이 벙커에 들어갔습니다.", Name);
        }
        void IBunker.OutBunker()
        {
            Console.WriteLine("{0}이 벙커에 나갔습니다.", Name);
        }
    }
    public class Medic : Terran, IBunker
    {
        public Medic(string name)
        {
            this.name = name;
        }
        void IBunker.InBunker()
        {
            Console.WriteLine("{0}이 벙커에 들어갔습니다.", Name);
        }
        void IBunker.OutBunker()
        {
            Console.WriteLine("{0}이 벙커에 나갔습니다.", Name);
        }
    }
    public class Tank : Terran
    {
        public Tank(string name)
        {
            this.name = name;
        }
    }
    public class Zerg : Unit
    {

    }
    public class Zeglling : Zerg
    {
        public Zeglling(string name)
        {
            this.name = name;
        }
    }

    public class Bunker
    {
        Terran[] unitList;
        public Bunker()
        {
            unitList = new Terran[4];
        }
        public void InBunker<T>(T unit) where T : Terran,IBunker
        {
            for(int i = 0; i<unitList.Length; i++)
            {
                if(unitList[i] == null)
                {
                    unitList[i] = unit;
                    unit.InBunker();
                    break;
                }
            }
        }
    }
    public class GiftBox<T, A, myType> where A : struct
    {
        string content;
        int count;
        float floatValue;

        string[] contentArray;
        int[] countArray;
        float[] floatArray;

        T what1;
        A what2;
        myType what3;
        public void ShowT()
        {
            Console.WriteLine(typeof(T));

            Console.WriteLine(typeof(A));
            Console.WriteLine(typeof(myType));
            string a = what1.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //GiftBox<string, int, float> box1 = new GiftBox<string, int, float>();
            //box1.ShowT();
            List<int> list = new List<int>();
            for(int i =0; i<40; i++)
            {
                list.Add(i);
            }

            list.ShowList();
            list.Shuffle(100);
            list.ShowList();

            //List<string> stringList = new List<string>();
            //for (int i = 0; i < 40; i++)
            //{
            //    stringList.Add(i.ToString());
            //}
            //CustomMethod.ShowList(stringList);
            //CustomMethod.Shuffle(stringList, 10);
            //CustomMethod.ShowList(stringList);

            Marine marine = new Marine("마린1");
            Medic medic = new Medic("매딕1");

            Bunker bunker = new Bunker();
            //marine.InBunker();
            bunker.InBunker(medic);
            bunker.InBunker(marine);
            Tank tank = new Tank("탱크1");

            List<Terran> terran = new List<Terran>();
            terran.Add(marine);
            terran.Add(medic);
            terran.ShowUnitName();
        }
    }
    public static class CustomMethod
    {
        public static void Shuffle<T>(this List<T> list, int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                int r1 = random.Next(0, list.Count);
                int r2 = random.Next(0, list.Count);

                T temp = list[r1];
                list[r1] = list[r2];
                list[r2] = temp;
            }
        }
        public static void ShowList<T>(this List<T> list)
        {
            for(int i=0;i<list.Count; i++)
            {
                if (i>0 && i % 10 == 0)
                    Console.WriteLine("");
                Console.Write("{0:00}, ",list[i]);
            }
            Console.WriteLine();
        }
        public static void ShowUnitName<T>(this List<T> list) where T : Unit
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0 && i % 10 == 0)
                    Console.WriteLine("");
                Console.Write("{0:00}, ", list[i].Name);
            }
            Console.WriteLine();
        }
        public static void InBunker<T>(this T unit) where T : Terran, IBunker
        {
            unit.InBunker();
        }
    }
    
}
