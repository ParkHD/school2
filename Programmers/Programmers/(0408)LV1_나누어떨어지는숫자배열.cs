using System;
using System.Collections.Generic;
using System.Text;

public class NumberArray
{
    public int[] solution(int[] arr, int divisor)
    {
        List<int> list = new List<int>();

        for(int i =0;i< arr.Length;i++)
        {
            if (arr[i] % divisor == 0)
                list.Add(arr[i]);
        }
        if(list.Count <=0)
        {
            list.Add(-1);
        }
        list.Sort();

        return list.ToArray();
    }
}
