using System;
using System.Collections.Generic;
using System.Text;

namespace Programmers
{



    public class Solution
    {
        public int ReverseTernary(int n)
        {
            int answer = 0;
            List<int> list = Ternary(n);
            for(int i =0;i<list.Count;i++)
            {
                answer += list[i] * (int)Math.Pow(3, list.Count-i-1);
            }
            return answer;
        }


        public List<int> Ternary(int number)
        {
            List<int> ternary = new List<int>();
 
            while(number > 0)
            {
                ternary.Add(number % 3);
                number = number / 3;
            }

            return ternary;
        }
    }

}
