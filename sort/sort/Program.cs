using System;
using System.Collections.Generic;
using System.Text;

namespace sort
{
    class Program
    {
        /// <summary>
        /// 버블 정렬
        /// </summary>
        /// <param name="isAscending">true : 오름차순, false : 내림차순</param>
        /// <param name="array"></param>
        static void BubbleSort(bool isAscending, params int[]  array)
        {
        int count = 0;
        Console.WriteLine("버블 정렬 [{0}] : {1}", isAscending ? "오름차순" : "내림차순", array.ToStringArray<int>());
            
        for (int j =0;j<array.Length - 1;j++)
        {
            for (int i = 0; i < array.Length - j - 1; i++)
            {

                bool isTrue = isAscending ? array[i] > array[i + 1] : array[i] < array[i + 1];
                if (isTrue)
                {
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                }
                count++;
            }
            Console.WriteLine("버블 정렬 [{0}] {2}회 : {1}", isAscending ? "오름차순" : "내림차순", array.ToStringArray<int>(),j+1);
        }
            
        Console.WriteLine(count); 
            
        }
        static void Main(string[] args)
        {
            //int[] array = new int[] { 7, 3, 10, 50, 20, 40, 1 };
            //Console.WriteLine("정렬 전 : {0}", array.ToStringArray());
            //array.BubbleSort();
            //Console.WriteLine("정렬 후 : {0}", array.ToStringArray());

            #region 인벤 초기화
            List<item> inventory = new List<item>();
            inventory.Add(new item( "대검", ITEMTYPE.Equipment, 0));
            inventory.Add(new item( "활", ITEMTYPE.Equipment, 1));
            inventory.Add(new item( "석궁", ITEMTYPE.Equipment, 2));

            inventory.Add(new item( "목걸이", ITEMTYPE.Acces, 0));
            inventory.Add(new item( "반지", ITEMTYPE.Acces, 1));
            inventory.Add(new item( "귀걸이", ITEMTYPE.Acces, 2));

            inventory.Add(new item( "불의 원석", ITEMTYPE.Stuff, 0));
            inventory.Add(new item( "물의 원석", ITEMTYPE.Stuff, 1));
            inventory.Add(new item( "땅의 원석", ITEMTYPE.Stuff, 2));
            #endregion
            inventory.Shuffle();
            Console.WriteLine(inventory.ToStringList());
        }
    }

}
public static class Method
{
    public static string ToStringArray<T>(this T[] target)
    {
        //string관리 클래스 -> 문자의 합이 많을 경우에 사용한다.(임시 변수 생성 ㄴ)
        StringBuilder builder = new StringBuilder();
        for(int i = 0;i<target.Length;i++)
        {
            //Append(문자 결합)
            //AppendLine(문자 결합 후 한줄 뜀)
            builder.Append(target[i].ToString());
            builder.Append(" ");
            // text = text + target.ToString(); string즉 문자열 합을 사용하면 임시변수 생성해서
            // 메모리낭비가 심하다 
        }
        return builder.ToString();
    }
    public static string ToStringList<T>(this List<T> target) where T : IName // 템플릿 T는 IMame을 상속받아야만 호출댐
    {
        //string관리 클래스 -> 문자의 합이 많을 경우에 사용한다.(임시 변수 생성 ㄴ)
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < target.Count; i++)
        {
            //Append(문자 결합)
            //AppendLine(문자 결합 후 한줄 뜀)
            builder.Append(target[i].GetName());
            builder.Append(" ");
            // text = text + target.ToString(); string즉 문자열 합을 사용하면 임시변수 생성해서
            // 메모리낭비가 심하다 
        }
        return builder.ToString();
    }
    public static void BubbleSort(this int[] array, bool isAscending = true)
    {
        //Console.WriteLine("버블 정렬 [{0}] : {1}", isAscending ? "오름차순" : "내림차순", array.ToStringArray<int>());
        if(array.Length <=1)
        {
            Console.WriteLine("배열의 크기가 2이상이어야 합니다!");
            return;
        }
        for (int j = 0; j < array.Length - 1; j++)
        {
            for (int i = 0; i < array.Length - j - 1; i++)
            {
                bool isTrue = isAscending ? array[i] > array[i + 1] : array[i] < array[i + 1];
                if (isTrue)
                {
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                }
            }
            Console.WriteLine("버블 정렬 [{0}] {2}회 : {1}", isAscending ? "오름차순" : "내림차순", array.ToStringArray<int>(), j + 1);
        }

    }
    public static void BubbleSort<T>(this List<T> array, bool isAscending = true) where T : IName, ISort
    {
        //Console.WriteLine("버블 정렬 [{0}] : {1}", isAscending ? "오름차순" : "내림차순", array.ToStringArray<int>());
        if (array.Count <= 1)
        {
            Console.WriteLine("배열의 크기가 2이상이어야 합니다!");
            return;
        }
        for (int j = 0; j < array.Count - 1; j++)
        {
            for (int i = 0; i < array.Count - j - 1; i++)
            {
                bool isTrue = isAscending ? array[i].GetSort() > array[i + 1].GetSort() : array[i].GetSort() < array[i + 1].GetSort();
                if (isTrue)
                {
                    T temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                }
            }
            Console.WriteLine("버블 정렬 [{0}] {2}회 : {1}", isAscending ? "오름차순" : "내림차순", array.ToStringList(), j + 1);
        }

    }
    public static void Shuffle<T>(this List<T> list, int count = 100)
    {
        Random random = new Random();
        for(int i = 0;i<count;i++)
        {
            int leftNum = random.Next(list.Count);
            int rightNum = random.Next(list.Count);

            T left = list[leftNum];
            T right = list[rightNum];

            T temp = left;
            left = right;
            right = temp;

            list[leftNum] = left;
            list[rightNum] = right;
        }
    }
}
