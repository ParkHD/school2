using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Tool
{
    class MyTool
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
                Console.WriteLine("잘 못 입력되었습니다.");
                // 정수로 변환할 수 없음.
            }

            return index;
        }
    }
}
