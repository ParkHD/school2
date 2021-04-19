using System;

namespace csProject04
{
    

    class Program
    {
        static int GetTabNumber(string command)
        {
            // 만약에 입력된 값이 Tap 1이라면...?
            int tabNumber = 0;

            bool isContains = command.Contains("tab"); // 해당 문자열이 포함되어 있는가?
            if (isContains)
            {
                //int indexOf = command.IndexOf("tab");
                //Console.WriteLine(indexOf);
                string[] split = command.Split(' '); // char형 인자를 기준으로 문자를 나눈다.

                try
                {
                    // try를 쓰는 이유는 잘못 입력했을 경우도 있다.
                    tabNumber = int.Parse(split[1]); // tab_이후의 문자형태 숫자를 -> 숫자.
                }
                catch
                {
                    tabNumber = 0;
                }
            }

            return tabNumber;
        }

        static void Main(string[] args)
        {
            WebBrowser browser = new WebBrowser();
            while(true)
            {
                browser.ShowWeb();
                browser.Input();

            }
        }
    }
}
