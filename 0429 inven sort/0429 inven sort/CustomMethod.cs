using System;
using System.Collections.Generic;
using System.Text;

public interface IName
{
    string GetName();
}
public interface ISort
{
    int GetSort();
}

public static class Method
{
    public static string ToStringArray<T>(this T[] target)
    {
        // string 관리 클래스.
        // = 문자의 합이 많을 경우에 사용.
        StringBuilder builder = new StringBuilder();

        string text = string.Empty;
        for (int i = 0; i < target.Length; i++)
        {
            // Append(문자 결합)
            // AppendLine(문자 결합 후 한줄 띔)
            builder.Append(target[i].ToString());
            builder.Append(" ");

            // 일반 문자열 겹합 시 임시 변수가 생긴다.
            // 이후 임시 변수는 참조할 수 없게 되어서 '가비지 컬렉터'가 가져간다.
            // text = text + target.ToString();
        }

        return builder.ToString();
    }
    public static string ToStringList<T>(this List<T> target) where T : IName
    {
        // where T : IName
        // = 템플릿 T는 IName을 상속받고 있어야지 호출 됨.

        // string 관리 클래스.
        // = 문자의 합이 많을 경우에 사용.
        StringBuilder builder = new StringBuilder();

        string text = string.Empty;
        for (int i = 0; i < target.Count; i++)
        {
            // Append(문자 결합)
            // AppendLine(문자 결합 후 한줄 띔)
            builder.Append(target[i].GetName());
            builder.Append(" ");

            // 일반 문자열 겹합 시 임시 변수가 생긴다.
            // 이후 임시 변수는 참조할 수 없게 되어서 '가비지 컬렉터'가 가져간다.
            // text = text + target.ToString();
        }

        return builder.ToString();
    }

    /// <summary>
    /// 버블 정렬
    /// </summary>
    /// <param name="array">정렬할 배열</param>
    /// <param name="isAscending">true:오름차순, false:내림차순</param>
    public static void BubbleSort<T>(this T[] array, bool isAscending = true)
        where T : IName, ISort
    {
        // Console.WriteLine("버블 정렬 [{0}] : {1}", isAscending ? "오름차순" : "내림차순", array.ToStringArray());

        int totalCycle = array.Length - 1;

        // 예외처리.
        if (totalCycle <= 0)
        {
            Console.WriteLine("array 배열의 크기가 2이상이어야 합니다.");
            return;
        }

        // 오름차순.
        for (int cycle = 0; cycle < totalCycle; cycle++)
        {

            for (int i = 0; i < totalCycle - cycle; i++)
            {
                int left = array[i].GetSort();
                int right = array[i + 1].GetSort();

                if (isAscending ? (left > right) : (left < right))
                {
                    T temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                }
            }

            Console.WriteLine("버블 정렬 {0}회 : {1}", cycle, array.ToStringArray());
        }
    }
    public static void BubbleSort<T>(this List<T> array, bool isAscending = true)
        where T : IName, ISort
    {
        int totalCycle = array.Count - 1;

        // 예외처리.
        if (totalCycle <= 0)
        {
            Console.WriteLine("array 배열의 크기가 2이상이어야 합니다.");
            return;
        }

        // 오름차순.
        for (int cycle = 0; cycle < totalCycle; cycle++)
        {
            for (int i = 0; i < totalCycle - cycle; i++)
            {
                T left = array[i];
                T right = array[i + 1];

                if (isAscending ?
                    (left.GetSort() > right.GetSort()) :
                    (left.GetSort() < right.GetSort()))
                {
                    T temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                }
            }

            //Console.WriteLine("버블 정렬 {0}회 : {1}", cycle, array.ToStringList());
        }
    }

    public static void SelectionSort<T>(this T[] array,bool isAscending = true) where T : IName, ISort
    {
        int minIndex = 0;       // 가장 작은 값이 들어갈 좌표
        
        for (int i = 0; i < array.Length; i++) 
        {
            minIndex = i;
            for (int j = i+1; j < array.Length; j++) 
            {
                if (array[j] == null)
                    break;
                bool ascending = isAscending ? array[minIndex].GetSort() > array[j].GetSort() : array[minIndex].GetSort() < array[j].GetSort();
                if (ascending)
                {
                    minIndex = j;
                }
            }
            T temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }
    }

    public static void InsertionSort<T>(this T[] array, bool isAscending = true) where T :ISort
    {
        for(int i = 1;i<array.Length ;i++)
        {
            for(int j = i - 1;j>0;j--)
            {
                if (array[j] == null)
                    break;
                int target = array[j - 1].GetSort();
                int current = array[j].GetSort();

                if (target > current)
                {
                    Swap(ref array[j - 1], ref array[j]);
                }
                else
                    break;
            }
        }
    }
    public static void Shuffle<T>(this List<T> list, int count = 100)
    {
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            int leftNum = random.Next(list.Count);
            int rightNum = random.Next(list.Count);

            T left = list[leftNum];
            T right = list[rightNum];

            T temp = left;
            left = right;
            right = temp;
        }
    }
    public static void Swap<T>(ref T targetA, ref T targetB)
    {
        T temp = targetA;
        targetA = targetB;
        targetB = temp;
    }
}