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
                    temp.ShellSort();
                    break;
                case SortType.Merge:
                    temp.MergeSort();
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

            ShowSort(SortType.Bubble, 20000);
            ShowSort(SortType.Select, 20000);
            ShowSort(SortType.Insert, 20000);
            ShowSort(SortType.Shell,  20000);
            ShowSort(SortType.Merge,  20000);
        }
    }
}
