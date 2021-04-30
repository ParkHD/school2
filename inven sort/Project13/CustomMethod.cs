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
        where T : IName
    {
        // string 관리 클래스.
        // = 문자의 합이 많을 경우에 사용.
        StringBuilder builder = new StringBuilder();

        string text = string.Empty;
        for (int i = 0; i < target.Length; i++)
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

    // 기본 정렬 방법 ==================================================================
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

            //Console.WriteLine("버블 정렬 {0}회 : {1}", cycle, array.ToStringArray());
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
    public static void SelectionSort<T>(this T[] array, bool isAscending = true)
        where T : IName, ISort
    {
        //int index = 0;     // 값이 들어갈 좌표.                

        for(int index = 0; index<array.Length - 1; index++)
        {
            // index부분이 null이라면 반복 종료.
            if (array[index] == null)
                break;

            int targetIndex = index;  // 가장 작은 값이 들어있는 좌표.

            // 가장 작은 값 갱신.
            for (int next = index+1; next < array.Length; next++)
            {
                // next의 값이 없을 경우 갱신 종료.
                if (array[next] == null)
                    break;

                int origin = array[targetIndex].GetSort();
                int target = array[next].GetSort();

                if(isAscending ? (origin > target) : (origin < target))
                {
                    targetIndex = next;
                }
            }

            Swap(ref array[index], ref array[targetIndex]);
        }
    }
    public static void InsertionSort<T>(this T[] array, bool isAscending = true)
        where T : ISort
    {
        for (int i = 1; i < array.Length; i++)
        {
            T origin = array[i];

            for (int index = i - 1; index >= 0; index--)
            {
                T target = array[index];

                if (isAscending ? (
                    origin.GetSort() < target.GetSort()) :
                    origin.GetSort() > target.GetSort())
                {
                    array[index + 1] = target;
                }
                else
                {
                    array[index + 1] = origin;
                    break;
                }
            }
        }
    }
    //=================================================================================

    // 고급 정렬 방법 ==================================================================
    public static void ShellSort<T>(this T[] array, bool isAscending = true)
        where T : ISort, IName
    {
        for(int gap = array.Length / 2; gap > 0; gap /= 2)
        {
            // gap이 짝수일 경우 +1해서 홀수로 만들어준다.
            if ((gap % 2) == 0)
                gap += 1;

            for(int i = gap; i < array.Length; i++)
            {
                T origin = array[i];

                for (int currrent = i - gap; currrent >= 0; currrent -= gap)
                {
                    T target = array[currrent];

                    if (isAscending ? 
                        (origin.GetSort() < target.GetSort()):
                        (origin.GetSort() > target.GetSort()))
                    {
                        array[currrent + gap] = target;
                    }
                    else
                    {
                        array[currrent + gap] = origin;
                        break;
                    }
                }
            }
        }
    }
    public static void MergeSort<T>(this T[] array, bool isAsceneding= true)
        where T : ISort
    {
        int midLength = array.Length / 2;

        T[] left = new T[midLength];
        T[] right = new T[array.Length - midLength];

        int index = 0;
        for(int i = 0; i<left.Length; i++)
        {
            left[i] = array[index++];
        }
        for(int i = 0; i<right.Length; i++)
        {
            right[i] = array[index++];
        }

        // 만약 왼쪽 배열의 개수가 1보다 많으면...
        if(left.Length > 1)
            left.MergeSort(isAsceneding);
        if(right.Length > 1)
            right.MergeSort(isAsceneding);

        // 병합.
        int leftIndex = 0;
        int rightIndex = 0;

        for(int i = 0; i<array.Length; i++)
        {
            // 이미 왼쪽은 다 넣었다.
            if(leftIndex >= left.Length)
            {
                array[i] = right[rightIndex];
                rightIndex++;
                continue;
            }
            // 이미 오른쪽을 다 넣었다.
            if(rightIndex >= right.Length)
            {
                array[i] = left[leftIndex];
                leftIndex++;
                continue;
            }

            // 왼쪽 값이 더 작다면...
            if(left[leftIndex].GetSort() < right[rightIndex].GetSort())
            {
                array[i] = left[leftIndex];
                leftIndex++;
            }
            // 오른쪽 값이 더 작다면...
            else
            {
                array[i] = right[rightIndex];
                rightIndex++;
            }
        }

    }

    //=================================================================================



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
    
    // ref 키워드 : reference (참조 형식으로 매게 변수를 받아오겠다.)
    // ref T targetA (=) T& targetA;
    public static void Swap<T>(ref T targetA, ref T targetB)
    {
        T temp = targetA;
        targetA = targetB;
        targetB = temp;
    }
}