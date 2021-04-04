using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Terran[] Tunits = new Terran[4];
            //Marine marine;
            Bunker bunker = new Bunker();
            Barrack barrack = new Barrack();
            Factory factory = new Factory();

            int input;
            begin: while (true)
            {
                Console.Write("1.건물 선택 2.유닛 선택 : ");
                input = int.Parse(Console.ReadLine());
                switch(input)
                {
                    case 1:
                        Console.Write("1.배럭 2.팩토리 3.벙커\n건물은 선택하세요 : ");
                        input = int.Parse(Console.ReadLine());
                        switch(input)
                        {
                            case 1:
                                barrack.Produce(ref Tunits);
                                break;
                            case 2:
                                factory.Produce(ref Tunits);
                                break;
                            case 3:
                                Console.Write("1.벙커유닛보기 2.벙커유닛내보내기 : ");
                                input = int.Parse(Console.ReadLine());
                                Console.Clear();

                                switch (input)
                                {
                                    case 1:
                                        bunker.ShowUnits();
                                        break;
                                    case 2:
                                        bunker.OutUnit();
                                        break;
                                }
                                break;
                            case 0:
                                continue;
                        }
                        break;
                    case 2:
                        int unitCount = 0;
                        for(int i =0;i <Tunits.Length;i++)
                        {
                            if(Tunits[i] != null)
                            {
                                Console.Write("{0}.{1} ",i+1,Tunits[i].Name);
                                unitCount++;
                            }
                        }
                        if (unitCount == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("생성된 유닛이 없습니다");
                            goto begin;
                        }
                        Console.Write("\n선택하세요 : ");
                        int unitNum = int.Parse(Console.ReadLine())-1;

                        Console.Write("1.정찰 2.벙커들어가기 : ");
                        input = int.Parse(Console.ReadLine());
                        Console.Clear();

                        switch (input)
                        {
                            case 1:
                                if (Tunits[unitNum] != null)
                                {
                                    Tunits[unitNum].Scouting();
                                }
                                break;
                            case 2:
                                if (Tunits[unitNum] != null)
                                {
                                    Tunits[unitNum].GetInBunker(bunker);
                                }
                                break;
                        }
                        break;
                 
                    case 0:
                        continue;
                    default:
                        continue;
                }

            }

        }
    }
}
