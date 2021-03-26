using System;
using System.Collections.Generic;
using System.Text;

namespace csProject_2_01
{
    class BattleClass
    {
        BaseUnit[] allUnits;    // 모든 유닛.
        bool isMine;            // 내꺼냐?
        bool isMyTurn;          // 내 차례인가?

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

        // bool isMine = false;라고 하면 외부에서 호출할때.
        // isMine에 값을 넣지 않으면 false가 된다.
        public BattleClass(BaseUnit[] allUnits, bool isMine = false)
        {
            this.allUnits = allUnits;
            this.isMine = isMine;
        }

        // 모든 유닛의 이름을 리턴하는 함수.
        public string GetAllUnitName()
        {
            string result = isMine ? "[아군] " : "[적군] ";

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

        // 입력 값을 받아오는 곳.
        public void GetMyInput(ref int attackerIndex, ref int targetIndex, BattleClass target = null)
        {
            // 공격자가 나던 상대던 해당 함수는 실행할 것이다.
            if (IsMine)
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
        void GetAiInput(ref int attackIndex, ref int targetIndex, BattleClass target)
        {
            // AI가 행동할 내 유닛을 고르는건 가능.
            Random random = new Random();

            Console.WriteLine("컴퓨터가 공격 대상을 정하는 중...");
            // 밀리 세컨드 : 1000 (1초)

            int wait = random.Next(1, 5);

            // n초를 기다림.
            System.Threading.Thread.Sleep(wait * 1000);
                        
            while (true)
            {
                // 0 ~ allUnits의 크기 미만.
                int index = random.Next(0, allUnits.Length);
                BaseUnit unit = allUnits[index];

                // 랜덤으로 뽑아온 유닛이 행동할 수 있다면?
                if(unit.IsAction)
                {
                    attackIndex = index;
                    break;
                }
            }

            // 상대 유닛 중에 하나 골라와야 한다.
            // 그 중에서도 살아있는 유닛.
            while (true)
            {
                int index = random.Next(0, target.allUnits.Length);
                BaseUnit unit = target.allUnits[index];

                if (unit.IsAlive)
                {
                    targetIndex = index;
                    break;
                }
            }
        }

        // 모든 유닛이 행동을 끝냈는가?
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

        // 모든 유닛의 액션을 초기화 하는 함수.
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

        public BaseUnit GetUnit(int index)
        {
            return allUnits[index];
        }
    }
}
