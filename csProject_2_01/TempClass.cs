using System;
using System.Collections.Generic;
using System.Text;

namespace csProject_2_01
{
    class TempClass
    {
        // 여기서 시작하겟죠?
        public static void TempMain()
        {
            int number1 = 10;
            int number2 = 20;
            Swap(number1, number2);
            Console.WriteLine("실제로 값이 바뀌었는가? a : {0}, b : {1}", number1, number2);

            SwapRef(ref number1, ref number2);
            Console.WriteLine("실제로 값이 바뀌었는가? a : {0}, b : {1}", number1, number2);
        }

        // 교환 함수.
        // a와 b의 값을 교환.
        // int a에는 밖에서 호출할때 인자로 넣은 number1의 값이 '복사'된다.
        static void Swap(int a, int b)
        {
            Console.WriteLine("a : {0}, b : {1}", a, b);
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("a : {0}, b : {1}", a, b);
        }
        // ref형식으로 값 타입을 받아오면 '값'이 아니라 '주소값'을 가져온다.
        static void SwapRef(ref int a, ref int b)
        {
            Console.WriteLine("a : {0}, b : {1}", a, b);
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("a : {0}, b : {1}", a, b);
        }
    }
}
