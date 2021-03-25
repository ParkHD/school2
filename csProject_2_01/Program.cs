using System;

namespace csProject_2_01
{
    using static Class1;
    class Program
    {
        // 저번주에 배열을 만들어서 미리 생성을 한다.
        // GetUnit이라는 함수를 통해서 받아옴.
        // 그리고 Unit의 생성자에 넘겨준 뒤에 값을 복사.
       
        struct Box
        {
            public int number;
        }

        static void Main(string[] args)
        {
           

            Random random = new Random();
            for (int i =0; i<5; i++)
            {
                int ranValue = random.Next(0, 10);

                Console.WriteLine(ranValue);
            }
           

            // #region 이름 : 단순히 접는 거.
            #region 주석 처리.
            // class는 참조 형식. 대입을 하면 주소값을 넘겨준다.
            // struct(구조체)는 값 형식. 대입 하면 실제 값을 복사해서 준다.
            /*Box box1 = new Box();
            Box box2 = box1;
            box2.number = 100;*/

            //BaseUnit unit1 = new BaseUnit("마린", new UnitStatus(100, 0, 0));
            //Console.WriteLine("이름:{0}, 체력:{1}/{2}", unit1.Name, unit1.Hp, unit1.MAX_HP);

            // 클래스 : 상속이 가능,  참조 형식, 인터페이스 사용 가능. (다양한 값들을 관리하고 싶을 때)
            // 구조체 : 상속이 불가능, 값  형식, 인터페이스 사용 가능. (간단한 변수들의 집합체 관리하고 싶을 때)

            // <상속>
            // int a = 30;

            /*Cat cat = new Cat("고양이1", 10.5f, 3);
            Dog dog = new Dog("강아지1", 5.5f, 1);

            Cat[] catArray = new Cat[2];
            catArray[0] = new Cat("고양이1", 10.5f, 3);
            catArray[1] = new Cat("고양이1", 10.5f, 3);

            Dog[] dogArray = new Dog[3];
            dogArray[0] = new Dog("강아지1", 5.5f, 1);
            dogArray[1] = new Dog("강아지1", 5.5f, 1);
            dogArray[2] = new Dog("강아지1", 5.5f, 1);


            foreach(Cat temp in catArray)
            {
                temp.Cry();
            }
            foreach(Dog tempDog in dogArray)
            {
                tempDog.Cry();
            }*/
            #endregion

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


            // <실습>
            // (둘 중에 하나 선택)
            // 1. 나 한번 적 한번씩 공격하기.
            // 2. 내 유닛 전부가 한 번씩 공격하고, 적 유닛이 전부 한번 씩 공격하기.

            // (+할 수 있는 사람만)
            // 3. 유닛이 죽으면 죽었다고 표시하고 목록에 띄우지 않기.

            // 지금 공격자가 나인가 적인가?
            // bool 참:true, 거짓:false.
            

            Battle attacker = new Battle(allUnits, true);
            Battle target   = new Battle(allEnemys);

            // 최초에 공격자의 액션을 모두 초기화.
            attacker.SetAllUnitAction();

            // 반복 시킴.
            while (true)
            {
                Console.WriteLine("[아군] {0}", attacker.GetAllUnitName());
                Console.WriteLine("[적군] {0}", target.GetAllUnitName());
                Console.WriteLine("");

                // 조건식 ? (참일 경우 : 거짓일 경우).
                Console.WriteLine("현재 턴 : {0}",  attacker.IsMine? "내 차례" : "적 차례");
                                

                int attackerIndex = 0;
                int targetIndex = 0;

                // ============= 여기서 입력을 받고 있다. ==========================
                
                attacker.GetMyInput(ref attackerIndex, ref targetIndex, target);
                
      
                // 단.. random으로 index를 결정할때...
                // 뭘 체크한다? 공격자가 행동력이 소모 되었는지?

                // ================================================================


                // ====================== 인덱스에 의거해서 공격 ====================

                // 콘솔 창의 모든 문자를 제거하는 함수.
                Console.Clear();

                // 공격자 유닛 배열의 Index번째가 피격자 배열의 Index번째를 공격.
                attacker.GetUnit(attackerIndex).AttackedTo(target.GetUnit(targetIndex));
                Console.WriteLine("");

                // 나 혹은 적의 턴이 끝났는가?
                if(attacker.IsEndTurn())
                {
                    // 턴 바꾸기. 
                    // !는 true를 false. false를 true로 바꾼다.


                    // 턴에 따라 공격자와 피격자 설정.
                    Battle temp = attacker;
                    attacker = target;
                    target = temp;

                    // 다음 턴 모든 유닛의 액션 초기화.
                    attacker.SetAllUnitAction();

                }   
            }
        }

        // 모든 유닛의 이름을 리턴하는 함수.
        

        // 모든 유닛의 액션을 초기화 하는 함수.
        
        // 모든 유닛이 행동을 끝냈는가?

        // ref는 실제 주소를 가져오는 것.
        

    }
}
