using System;
using System.Diagnostics;
using System.Threading;

namespace Project11
{
    class Program
    {
        enum SortType
        {
            //                      빠르기     난이도
            Bubble, // 버블 정렬.       6       1
            Select, // 선택 정렬.       5       2
            Insert, // 삽입 정렬.       4       3
            Shell,  // 셸 정렬.         3       4
            Merge,  // 병합 정렬        2       5
            Quick,  // 퀵 정렬.         1       6

            Count,
        }

        static Equipment[] equip;   // 장비 아이템 데이터.
        static Equipment[] GetRandom(int count)
        {
            Equipment[] result = new Equipment[count];
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                // random.Next(value) : value 이하의 랜덤 값 리턴.
                result[i] = equip[random.Next(equip.Length)];
            }

            return result;
        }

        static void ShowSort(SortType type, int count, bool isShow = false)
        {
            Random random = new Random();
            Stopwatch stopWatch = new Stopwatch();

            Equipment[] temp = new Equipment[count];

            // 랜덤한 아이템 값으로 대입.
            for(int i = 0; i<count; i++)
                temp[i] = equip[random.Next(equip.Length)];

            stopWatch.Start();

            switch(type)
            {
                case SortType.Bubble:
                    temp.BubbleSort();
                    break;
                case SortType.Select:
                    temp.SelectionSort();
                    break;
                case SortType.Insert:
                    temp.InsertionSort();
                    break;
                case SortType.Shell:
                    temp.SelectionSort();
                    break;
                case SortType.Quick:
                    temp.QuickSort();
                    break;
            }

            stopWatch.Stop();

            Console.WriteLine("{0} 정렬 : {1}mil", type.ToString(), stopWatch.ElapsedMilliseconds);

            if (isShow)
                Console.WriteLine(temp.ToStringArray());
        }

        static void Main(string[] args)
        {
            equip = FileManager.GetEqeuipmentData("WeaponData");

            ShowSort(SortType.Bubble, 10000);
            ShowSort(SortType.Select, 10000);
            ShowSort(SortType.Insert, 10000);
            ShowSort(SortType.Shell, 10000);
            ShowSort(SortType.Quick, 10000);

            for(int i = 0;i<(int)SortType.Count;i++)
            {
                ShowSort((SortType)i, 10000);
            }


            int[] array = new int[]{ 8,7,5,6,10};
            QuickSort(array, 0,4);
            for(int i = 0;i<array.Length;i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        static int Partition(int[] array, int start, int end)
        {
            int pivot = array[(start + end) / 2]; // 중간값
            while(true)
            {
                if (end < start)
                    break;
                if(array[start] < pivot)
                {
                    start++;
                    continue;
                }
                if(array[end] > pivot)
                {
                    end--;
                    continue;
                }

                int temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                start++;
                end--;
                
            }
            return start;
        }
        static void QuickSort(int[] array, int start, int end)
        {
            int pivot = Partition(array, start, end);
            if(start < pivot - 1)                           // 왼쪽값이 하나남을 때까지
            {
                QuickSort(array, start, pivot - 1);
            }
            if(pivot < end)                                 // 오른쪽값이 하나 남을때 까지
            {
                QuickSort(array, pivot, end);
            }
        }
    }
    
}
