using System;
using System.Collections.Generic;
using System.Linq;


class LV1
{
    public int[] solution(int[] array, int[,] commands)
    {
        List<int> list = new List<int>();
        List<int> answer = new List<int>();
        for(int j=0;j<commands.GetLength(0);j++)
        {
            for (int i = commands[j, 0] - 1; i < commands[j, 1]; i++)
            {
                list.Add(array[i]);

            }
            list.Sort();
            answer.Add(list[commands[j, 2] - 1]);
            list.Clear();
        }
        return answer.ToArray();
    }
    public int[] solution1(int[] array, int[,] commands)
    {
        int[] answer = new int[commands.GetLength(0)];
        List<int> lst = new List<int>(array);
        for (int i = 0; i < commands.GetLength(0); i++)
        {
            int nStart = commands[i, 0]-1;
            int nEnd = commands[i, 1];
            int nIndex = commands[i, 2]-1;
            List<int> lstSub = lst.Where((x, idx) => idx >= nStart && idx < nEnd).OrderBy(x => x).ToList();
            answer[i] = lstSub[nIndex];
        }
        return answer;
    }
}
