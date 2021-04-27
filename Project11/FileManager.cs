using System;
using System.Collections.Generic;
using System.Text;
using System.IO; // input output

public static class FileManager
{
    private static string GetPath(string fileName)
    {
        return string.Format("{0}\\{1}.txt", Environment.CurrentDirectory, fileName);
    }

    public static Equipment[] GetEqeuipmentData(string fileName)
    {
        string path = GetPath(fileName); // 경로...

        try
        {
            List<Equipment> list = new List<Equipment>();

            StreamReader sr = new StreamReader(path);
            string line = sr.ReadLine();

            // 마지막 줄까지 읽는다.
            while((line = sr.ReadLine()) != null)
            {
                // string.Split(char) : 문자 기준으로 자른다.
                string[] data = line.Split('\t');

                Equipment equipment = new Equipment(
                    data[1],
                    int.Parse(data[0]),
                    (JOB)Enum.Parse(typeof(JOB), data[2]),
                    (EQUIPMENT)Enum.Parse(typeof(EQUIPMENT), data[3]),
                    (GRADE)Enum.Parse(typeof(GRADE), data[4]),
                    int.Parse(data[5]),
                    int.Parse(data[6]),
                    int.Parse(data[7])
                    );

                //equipment.ShowInfo();
                list.Add(equipment);
            }

            return list.ToArray();
        }
        catch(Exception e)
        {
            Console.WriteLine("파일을 열 수 없습니다. {0}", e.Message);            
        }

        return null;
    }
}