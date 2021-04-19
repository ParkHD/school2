using System;
using System.Collections.Generic;
using System.Text;

namespace csProject04
{
    class Web
    {
        List<string> urlStack;
        int index;
        public string URL
        {
            get 
            {
                if (IsValidIndex(index))
                    return urlStack[index];
                else
                    return string.Empty;
                
            }
        }
        public bool IsBack
        {
            get 
            {
                return IsValidIndex(index -1);
            }
        }
        public bool IsFront
        {
            get
            {
                return IsValidIndex(index + 1);
            }
        }
        private bool IsValidIndex(int index)
        {
            return 0 <= index && index < urlStack.Count;
        }
        public void InputURL(string url)
        {
            int removeCount = urlStack.Count - index - 1;
            urlStack.RemoveRange(index + 1, removeCount);
            urlStack.Add(url);
            index++;
        }
        public void BackURL()
        {
            if(IsBack)
            {
                index--;
            }
        }
        public void FrontURL()
        {
            if(IsFront)
            {
                index++;
            }
        }
        public Web()
        {
            urlStack = new List<string>();
            index = -1;
        }
    }
    class WebBrowser
    {
        DoubleList<Web> webList;
        Web nowWeb;
        public WebBrowser()
        {
            webList = new DoubleList<Web>();
            webList.Add(new Web());
            nowWeb = webList[0];
        }
        public void ShowWeb()
        {
            Console.Clear();
            for (int i =0;i< webList.Count;i++)
            {
                string title = (webList[i].URL == string.Empty) ? "새 탭" : webList[i].URL;
                string me = (webList[i] == nowWeb ? "o" : " ");
                
                Console.WriteLine("[{0}][{1}] ", title, me);
            }
            string back = nowWeb.IsBack ? "o" : "x";
            string front = nowWeb.IsFront? "o" : "x";
            string url = string.IsNullOrEmpty(nowWeb.URL)? "URL을 입력해 주세오 : " : nowWeb.URL;
            Console.WriteLine("뒤로[{0}] 앞으로[{1}]", back, front);
            Console.WriteLine("페이지 : {0}", url);
            Console.WriteLine("--------------------------------------------------------------------------");
        }
        public void Input()
        {
            Console.Write("값 입력 : ");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                return;

            input = input.ToLower();
            if (input.Contains("back"))
            {
                nowWeb.BackURL();
            }
            else if(input.Contains("front"))
            {

            }
            else if(input.Contains("new"))
            {
                Web newWeb = new Web();
                webList.Add(newWeb);
                nowWeb = newWeb;
            }
            else if (input.Contains("tab"))
            {
                string[] split = input.Split(" ");
                try
                {
                    int index = int.Parse(split[1]);
                    index--;
                    nowWeb = webList[index];
                }
                catch { }
            }
            else
            {
                nowWeb.InputURL(input);
            }
           
        }

        void Main(string[] args)
        {
            if (false)
            {
                DoubleList<int> list = new DoubleList<int>();

                list.Add(10);
                list.Add(20);
                list.Add(30);

                list.RemoveAt(0);

                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine("{0}번째 값은 : {1}", i, list[i]);
                }
            }

            // 대,소문자 구분하기 싫다.
            string ss = "Tab 1";

            Console.WriteLine(ss.ToLower()); // 문자열을 전부 소문자로 바꿔서 리턴.
            Console.WriteLine(ss.ToUpper()); // 문자열을 전부 대문자로 바꿔서 리턴.

            // 입력받은 문자를 숫자로 바꾸는 방법.
            /*
            string myInput = Console.ReadLine();
            int number = int.Parse(myInput);
            Console.WriteLine(number);
            */

            Stack<string> webStack = new Stack<string>();

            while (true)
            {
                string input = Console.ReadLine(); // 입력값 받아오기.

                // <실습>
                /*
                 *  [페이지][o] [페이지][ ] [페이지][ ] // 개수만큼 추가 된다.
                 *  뒤로가기[o] , 페이지 : ##########
                    --------------------------------------------
                    값 입력 : ######s#

                    1. 값을 입력하면
                       -> 페이지가 해당 값이 된다.
                    2. Back을 입력하면
                       -> 페이지가 이전 페이지로 변경된다.
                    3. 뒤로가기가 불가능 할 경우
                       -> 뒤로가기[x]

                    4. New를 입력하면 새로운 Tap이 열리고 그곳으로 간다.
                    5. Tab_n : Tab 공백 번호 누르면 해당 번호로 간다. (시작은 1)
                 */
            }
        }
    }
}
