using System;
using System.Collections.Generic;
using System.Linq;

public class Sort
{
    public string[] solution(string[] strings, int n)
    {
        string[] answer = new string[] { };
        for(int i =0;i<strings.Length;i++)
        {
            strings[i] =  (strings[i])[n] + strings[i];
        }
        List<string> list = new List<string>();
        for(int i = 0;i<strings.Length;i++)
        {
            list.Add(strings[i]);
        }
        list.Sort();
        answer = list.ToArray();
        for(int i =0;i<answer.Length;i++)
        {
            answer[i] = answer[i].Substring(1);
        }

        return answer;
    }
    public string[] solution1(string[] strings, int n)
    {
        string[] answer = strings.OrderBy(c => c[n]).ThenBy(c => c).ToArray();

        return answer;
    }
}
