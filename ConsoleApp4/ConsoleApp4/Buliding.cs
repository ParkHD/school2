using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    class Building
    {
    }
    class TerranBuilding : Building
    {

    }
    class Barrack : TerranBuilding
    {
        public void Produce(ref Terran[] unit)
        {
            Console.Write("1.마린 2.메딕, 3.파이어벳, 4.고스트\n생산 유닛을 선택하세요 : ");
            int input = int.Parse(Console.ReadLine());

            Console.Clear();
            for (int i = 0; i < unit.Length; i++)
            {
                if (unit[i] == null)
                {
                    switch (input)
                    {
                        case 1:
                            unit[i] = new Marine("마린");
                            break;
                        case 2:
                            unit[i] = new Medic("메딕");
                            break;
                        case 3:
                            unit[i] = new FireBat("파이어벳");
                            break;
                        case 4:
                            unit[i] = new Ghost("고스트");
                            break;
                    }
                    break;
                }
            }
        }
    }
    class Factory : TerranBuilding
    {
        public void Produce(ref Terran[] unit)
        {
            Console.Write("1.벌쳐 2.탱크, 3.골리앗\n생산 유닛을 선택하세요 : ");
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < unit.Length; i++)
            {
                if (unit[i] == null)
                {
                    switch (input)
                    {
                        case 1:
                            unit[i] = new Vulture("벌쳐");
                            break;
                        case 2:
                            unit[i] = new Tank("탱크");
                            break;
                        case 3:
                            unit[i] = new Goliat("골리앗");
                            break;
                    }
                    break;
                }
            }
        }
    }
    class Bunker : TerranBuilding
    {
        Terran[] units;
        public Bunker()
        {
            units = new Terran[4];
        }
        public void InUnit(Terran unit)
        {
            for(int i=0;i<4;i++)
            {
                if(units[i] == null)
                {
                    units[i] = unit;
                    Console.WriteLine("{0}이 벙커 {1}자리에 들어갔다..", unit.Name, i + 1);
                    break;
                }
            }
        }
        public void ShowUnits()
        {
            int unitCount = 0;
            for (int i = 0; i < 4; i++)
            {
                if (units[i] != null)
                {
                    unitCount++;
                    Console.WriteLine("{0}이 벙커 {1}자리에 있다.", units[i].Name, i + 1);
                }
            }
            if(unitCount == 0)
                Console.WriteLine("벙커가 비었습니다.");
        }
        public void OutUnit()
        {
            for (int i = 0; i < 4; i++)
            {
                if (units[i] != null)
                {
                    units[i] = null;
                }
            }
            Console.WriteLine("벙커가 비었습니다.");
        }
    }
}
