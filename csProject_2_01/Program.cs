using System;

namespace csProject_2_01
{
    class Box
    {
        public int a;
        public int b;

        public static int c;

        public void show()
        {
            Console.WriteLine("a : {0}", a);
            Console.WriteLine("b : {0}", b);
            Console.WriteLine("c : {0}", c);
        }
    }
    class Program
    {
        // 저번주에 배열을 만들어서 미리 생성을 한다.
        // GetUnit이라는 함수를 통해서 받아옴.
        // 그리고 Unit의 생성자에 넘겨준 뒤에 값을 복사.
        public static string actionText;


        static void Main(string[] args)
        {

            // 1. 마린은 ShowInfo를 하면 이름과 체력을 출력.
            // 2. 메딕은 ShowInfo를 하면 이름과 체력,마나를 출력한다.
            Marine marine1 = new Marine();
            Medic medic1 = new Medic();
            Ghost ghost = new Ghost();

            // 내 유닛이 allUnits.
            BaseUnit[] allUnits = new BaseUnit[3];
            allUnits[0] = new Marine();
            allUnits[1] = new Medic();
            allUnits[2] = new Ghost();

            BaseUnit[] allEnemys = new BaseUnit[3];
            allEnemys[0] = new Marine();
            allEnemys[1] = new Medic();
            allEnemys[2] = new Ghost();

            // 최초에 공격자는 나. 피격자는 상대.
            BattleClass attacker = new BattleClass(allUnits, true);
            BattleClass target   = new BattleClass(allEnemys);

            // 최초에 공격자의 액션을 모두 초기화.
            attacker.SetAllUnitAction();
            actionText = "게임시작";
            #region
            // 반복 시킴.
            //while (true)
            //{
            //    Console.WriteLine(attacker.GetAllUnitName());
            //    Console.WriteLine(target.GetAllUnitName());
            //    Console.WriteLine("");

            //    // 조건식 ? (참일 경우 : 거짓일 경우).
            //    Console.WriteLine("현재 턴 : {0}", attacker.IsMine ? "내 차례" : "적 차례");

            //    // 몇 번째 유닛이 몇 번째 유닛을 공격할지.
            //    int attackerIndex = 0;
            //    int targetIndex   = 0;

            //    // ============= 여기서 입력을 받고 있다. ==========================

            //    // 내 턴일 때 실제로 내 입력을 받아서 index를 결정.
            //    attacker.GetMyInput(ref attackerIndex, ref targetIndex, target);

            //    // 단.. random으로 index를 결정할때...
            //    // 뭘 체크한다? 공격자가 행동력이 소모 되었는지?

            //    // ====================== 인덱스에 의거해서 공격 ====================

            //    // 콘솔 창의 모든 문자를 제거하는 함수.
            //    Console.Clear();

            //    // 공격자 유닛 배열의 Index번째가 피격자 배열의 Index번째를 공격.
            //    attacker.GetUnit(attackerIndex).AttackedTo(target.GetUnit(targetIndex));
            //    Console.WriteLine("");

            //    // 나 혹은 적의 턴이 끝났는가?
            //    if(attacker.IsEndTurn())
            //    {
            //        // 턴 바꾸기. 
            //        // 턴에 따라 공격자와 피격자 설정.
            //        BattleClass temp = attacker;
            //        attacker = target;
            //        target = temp;

            //        // 기존에 attcker가 나였으면 상대.
            //        // 기존에 target이  상디였으면 나.

            //        // 다음 턴 모든 유닛의 액션 초기화.
            //        attacker.SetAllUnitAction();
            //    }   
            //}
            #endregion
            while (true)
            {
                Console.WriteLine("=========================================================================");
                Console.WriteLine(actionText);
                Console.WriteLine("=========================================================================");
                Console.WriteLine(attacker.IsMine ? "[나의 턴]" : "[상대 턴]");
                Console.WriteLine("공격자 : {0}",attacker.GetAllUnitName());
                Console.WriteLine("피격자 : {0}", target.GetAllUnitName());
                Console.WriteLine("=========================================================================");

                if (attacker.IsMine)
                {
                    Console.Write("행동할 유닛을 선택하세요 : ");
                    int attackerIndex = InputIndex();

                    BaseUnit attackUnit = attacker.GetUnit(attackerIndex);
                    if (attacker.GetUnit(attackerIndex).IsAction == false)
                {
                    Console.Clear();
                    actionText = string.Format("{0}는 행동력이 없습니다.", attackUnit.Name);
                    continue;
                }
            
                    Console.WriteLine("=========================================================================");
                    attackUnit.ShowAction();
                    Console.WriteLine("=========================================================================");
                    Console.Write("행동을 선택해주세요 : ");
                    int actionIndex = InputIndex();
                    attackUnit.DoAction(actionIndex, attacker, target);
                }
                else
                {
                    Random random = new Random();
                    int attackerIndex = random.Next(0, 3);
                    BaseUnit attackUnit = attacker.GetUnit(attackerIndex);
                    if (attackUnit.IsAction == false)
                    {
                        Console.Clear();
                        continue;
                    }
                    attackUnit.DoAction(attacker, target);
                }
                Console.Clear();

                if(attacker.IsEndTurn())
                {
                    BattleClass temp = attacker;
                    attacker = target;
                    target = temp;

                    attacker.SetAllUnitAction();
                }
            }
        }

        public static int InputIndex()
        {
            int result = 0;
            string text = Console.ReadLine();
            result = int.Parse(text);
            result -= 1;
            return result;
        }
    }
}
