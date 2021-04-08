using System;
using System.Collections.Generic;
using System.Text;

public class Word
{
    public string solution(string s)
    {
        string answer = "";
        int size = s.Length % 2;
        int index = s.Length / 2;
        if (size == 0)
        {
            answer = s[index-1].ToString() + s[index].ToString();
        }
        else 
        {
            answer = s[index].ToString();
        }
        return answer;
    }
    public string solution1(string s)
    {
        string answer = "";
        int size = s.Length % 2;
        int index = s.Length / 2;
        answer = s.Substring(s.Length / 2 - 1 + s.Length % 2, size % 2 == 0 ? 2 : 1);
        return answer;
    }   
    public string solution2(string s)
    {
        string answer = "";

        int startIndex = s.Length/2 - (s.Length % 2 == 0 ? 1 : 0);
        int endIndex = s.Length%2 ==0? 2 : 1;

        answer = s.Substring(startIndex, endIndex);
        return answer;
    }
}
