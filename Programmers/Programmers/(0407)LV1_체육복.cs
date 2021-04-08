using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
    public int solution(int n, int[] lost, int[] reserve)
    {
        // 모든 학생 1(가지고있다)로 초기화
        int[] student = new int[n];
        for(int i=0;i<n;i++)
        {
            student[i] = 1;
        }

        //도난당한 학생 체육복 개수-1
        for(int i=0;i<lost.Length;i++)
        {
            student[lost[i]-1] -= 1;
        }
        
        //두개가져온 사람 체육복 개수+1
        for(int i =0;i<reserve.Length;i++)
        {
            student[reserve[i]-1] += 1;
        }

        for(int i =0; i<student.Length;i++)
        {
            if(student[i] == 0)
            {
                if(i-1 >=0 && student[i-1] == 2)
                {
                    student[i - 1]--;
                    student[i]++;
                    continue;
                }
                if(i+1 < student.Length && student[i+1] == 2)
                {
                    student[i + 1]--;
                    student[i]++;
                }
            }
        }

        int answer = 0;
        for (int i =0;i<student.Length;i++)
        {
            if(student[i] >= 1)
            {
                answer++;
            }
        }
        
        return answer;
    }
}
