using System;
using System.Collections.Generic;
using System.Text;

public class InsideSum
{
    public long solution(int a, int b)
    {
        long answer = 0;
        if(a>b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        for(int i =a;i<b+1;i++)
        {
            answer += i;
        }

        return answer;
    }
    public long solution1(int a, int b)
    {
        long answer = 0;

        (int minValue, int maxValue) = a > b ? (b, a) : (a, b);
        for (int i = minValue; i < maxValue + 1; i++)
        {
            answer += i;
        }

        return answer;
    }
}
