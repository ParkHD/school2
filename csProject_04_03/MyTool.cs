using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Tool
{
    // 확장형 메소드를 정의하려면
    // 클래스가 static이어야 한다.
    static class MyTool
    {
        public static int frame = 1000 / 60;
        public static object lockThis = new object();

        public static ConsoleKey OnGetKey(Action OnCancel = null)
        {
            lock (lockThis)
            {
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKey key = Console.ReadKey().Key;

                        if (key == ConsoleKey.Escape)
                            OnCancel?.Invoke();

                        return key;
                    }

                    Thread.Sleep(frame);
                }
            }
        }
        public static int OnGetNum(int addNum = 0)
        {
            int index = -1;

            try
            {
                index = int.Parse(Console.ReadLine());
                index += addNum;
            }
            catch
            {
                // 정수로 변환할 수 없음.
            }

            return index;
        }

        // 일반화, 확장 메소드.
        public static bool IsValid<T>(this List<T> list, int index)
        {
            // index가 0 이상이고
            // index가 카운트 미만.
            bool isResult = (0 <= index) && (index < list.Count);

            return isResult;
        }
        public static bool IsValid<T>(this T[] array, int index)
        {
            // index가 0 이상이고
            // index가 카운트 미만.
            bool isResult = (0 <= index) && (index < array.Length);

            return isResult;
        }
    }
}
