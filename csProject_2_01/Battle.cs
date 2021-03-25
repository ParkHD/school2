using System;
using System.Collections.Generic;
using System.Text;

namespace csProject_2_01
{
    class Battle
    {
        BaseUnit[]  allUnits;
        bool        isMine;
        bool        isMyTurn;

        public bool IsMine
        {
            get
            {
                return isMine;
            }
        }
        public bool IsMyTurn
        {
            get
            {
                return isMyTurn;
            }
        }
        public Battle(BaseUnit[] allUnits, bool isMine= false)
        {
            this.allUnits = allUnits;
            this.isMine = isMine;
        }
        public string GetAllUnitName()
        {
            string result = isMine? "아군" : "적군";

            for (int i = 0; i < allUnits.Length; i++)
            {
                BaseUnit unit = allUnits[i];

                // unit이 실제 값이 없거나. 유닛이 살아있지 않을 경우.
                if (unit == null || !unit.IsAlive)
                {
                    result += string.Format("{0}.{1}(Dead) ", i + 1, unit.Name);
                    continue;
                    //break;
                }

                // string.Format은 (" ")안의 포맷 형식 대로 문자를 반환한다.
                result += string.Format("{0}.{1}({2}/{3})[{4}] ",
                    i + 1, allUnits[i].Name, allUnits[i].Hp, allUnits[i].MAX_HP, allUnits[i].IsAction ? "O" : "X");
            }

            return result;
        }
        public void GetMyInput(ref int attackerIndex, ref int targetIndex, Battle target = null)
        {
            if (isMine)
            {
                Console.Write("공격할 유닛 선택 : ");
                string inputAttacker = Console.ReadLine();

                Console.Write("공격 받는 유닛 선택 : ");
                string inputTarget = Console.ReadLine();

                attackerIndex = int.Parse(inputAttacker) - 1; // 공격자의 인덱스.
                targetIndex = int.Parse(inputTarget) - 1;     // 피격자의 인덱스.
            }
            else
            {
                GetAiInput(ref attackerIndex, ref targetIndex, target);
            }
        }
        public bool IsEndTurn()
        {

            foreach (BaseUnit unit in allUnits)
            {
                if (unit == null)
                    continue;

                // 하나라도 isAction이 ture라면
                if (unit.IsAction)
                {
                    isMyTurn = true;
                    return false;
                }
            }
            isMyTurn = false;
            return true;
        }
        public void SetAllUnitAction()
        {
            for (int i = 0; i < allUnits.Length; i++)
            {
                BaseUnit unit = allUnits[i];

                if (unit == null)
                    continue;

                unit.SetAction();
            }
            isMyTurn = true;
        }
        public BaseUnit GetUnit(int value)
        {
            return allUnits[value];
        }
        public void GetAiInput(ref int attackerIndex, ref int targetIndex, Battle target)
        {
            Console.WriteLine("컴퓨터가 공격대상을 정하는 중...");

            Random random = new Random();

            int wait = random.Next(1, 5);
            System.Threading.Thread.Sleep(wait*1000);
            while (true)
            {
                int index = random.Next(0, allUnits.Length);
                BaseUnit unit = allUnits[index];
                if(unit.IsAction)
                {
                    attackerIndex = index;
                    break;
                }
            }
            while(true)
            {
                int index = random.Next(0, target.allUnits.Length);
                BaseUnit unit = target.allUnits[index];

                if(unit.IsAlive)
                {
                    targetIndex = index;
                    break;
                }
            }
        }
    }
}
