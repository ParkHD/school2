using System;
using static ConsoleApp7.BaseUnit;
using static ConsoleApp7.Animal;

namespace ConsoleApp7
{

    class Program
    {

        //struct Box                              
        //{
        //    public int number;
        //}
        //class Box1
        //{
        //    public int number;
        //}

        static void Main(string[] args)
        {
            #region 주석처리
            //Box box1 = new Box();
            //Box box2 = box1;                    // 주소값말고 값을 불러옴 (int정의를 봐보면 struct형임) 
            //box1.number = 100;
            //Console.WriteLine(box1.number);
            //Console.WriteLine(box2.number);

            //Box1 box3 = new Box1();
            //Box1 box4 = box3;                   // 주소값을 불러옴
            //box1.number = 100;
            //Console.WriteLine(box3.number);
            //Console.WriteLine(box4.number);
            #endregion
            #region
            /////////////////////////////////////////////////////////////////////////////////////

            //BaseUnit unit1 = new BaseUnit("마린", new UnitStatus(100, 0, 0));
            //Console.WriteLine("이름 : {0}, 체력 : {1}/{2}", unit1.Name, unit1.Hp, unit1.MAX_HP);

            //InitUnit();
            //BaseUnit unit2 = GetUnit("마린");
            //Console.WriteLine("이름 : {0}, 체력 : {1}/{2}", unit2.Name, unit2.Hp, unit2.MAX_HP);

            #endregion
            #region 상속(animal)
            /////////////////////////////////////////////////////////////////////////////////////
            //상속
            //Dog[] dogArray = new Dog[5];
            //dogArray[0] = new Dog("dogA", 3.0f, 4, "서울");
            //dogArray[1] = new Dog("dogB", 3.0f, 4, "서울");
            //dogArray[2] = new Dog("dogC", 3.0f, 4, "서울");

            //Cat[] catArray = new Cat[5];
            //catArray[0] = new Cat("catA", 3.0f, 4, "서울");
            //catArray[1] = new Cat("catB", 3.0f, 4, "서울");
            //catArray[2] = new Cat("catC", 3.0f, 4, "서울");
            //catArray[3] = new Cat("catD", 3.0f, 4, "서울");
            //catArray[4] = new Cat("catE", 3.0f, 4, "서울");

            //Animal[] animalArray = new Animal[8];
            //animalArray[0] = new Cat("catA", 3.0f, 4, "서울");
            //animalArray[1] = new Cat("catB", 3.0f, 4, "서울");
            //animalArray[2] = new Cat("catC", 3.0f, 4, "서울");
            //animalArray[3] = new Cat("catD", 3.0f, 4, "서울");
            //animalArray[4] = new Cat("catE", 3.0f, 4, "서울");

            //animalArray[5] = new Dog("dogA", 3.0f, 4, "서울");
            //animalArray[6] = new Dog("dogB", 3.0f, 4, "서울");
            //animalArray[7] = new Dog("dogC", 3.0f, 4, "서울");
            ////foreach (Cat cat in catArray)
            ////{
            ////    Console.Write(cat.name);
            ////    cat.Cry();
            ////}
            ////foreach(Dog dog in dogArray)
            ////{
            ////    dog.Cry();
            ////}
            //foreach (Animal animal in animalArray)
            //{
            //    animal.Cry();
            //    animal.Eat(Feed.CatFeed);
            //}
            #endregion

            BaseUnit[] allUnits = new BaseUnit[3];
            allUnits[0] = new Marine();
            allUnits[1] = new Medic();
            allUnits[2] = new Ghost();
            foreach (BaseUnit unit in allUnits)
                unit.ShowInfo();

            BaseUnit[] allEnemys = new BaseUnit[3];
            allEnemys[0] = new Marine();
            allEnemys[1] = new Medic();
            allEnemys[2] = new Ghost();

            //allUnits[0].AttackedTo(allEnemys[2]);

            while (true)
            {
                
                Console.WriteLine("[아군] {0}", GetAllUnitName(allUnits));
                Console.WriteLine("[적군] {0}", GetAllUnitName(allEnemys));
                Console.WriteLine("");
                for(int i =0; i<allUnits.Length; i++)
                {
                    Console.Write("공격할  유닛 선택 : ");
                    string input = Console.ReadLine();

                    Console.Write("적 유닛 선택 : ");
                    string target = Console.ReadLine();

                    int myIndex = int.Parse(input) - 1;
                    int enemyIndex = int.Parse(target) - 1;

                    allUnits[myIndex].AttackedTo(allEnemys[enemyIndex]);

                    Console.WriteLine("[아군] {0}", GetAllUnitName(allUnits));
                    Console.WriteLine("[적군] {0}", GetAllUnitName(allEnemys));
                }
                // Console.Clear();
                for (int i = 0; i < allEnemys.Length; i++)
                {
                    Console.Write("공격할 적군 유닛 선택 : ");
                    string input = Console.ReadLine();


                    Console.Write("아군 유닛 선택 : ");
                    string target = Console.ReadLine();

                    int enemyIndex = int.Parse(input) - 1;
                    int myIndex = int.Parse(target) - 1;

                    allEnemys[enemyIndex].AttackedTo(allUnits[myIndex]);

                    Console.WriteLine("[아군] {0}", GetAllUnitName(allUnits));
                    Console.WriteLine("[적군] {0}", GetAllUnitName(allEnemys));
                }

            }
        }
        static string GetAllUnitName(BaseUnit[] allUnits)
        {
            string result = string.Empty;
           
            for (int i =0; i<allUnits.Length; i++)
            {
                if (allUnits[i] != null)
                {
                    if (!allUnits[i].IsDead)
                        result += string.Format("{0}.{1}({2}/{3}) ", i + 1, allUnits[i].Name, allUnits[i].Hp, allUnits[i].MAX_HP);
                    else if (allUnits[i].IsDead)
                    {
                        result += string.Format("{0}.{1} die ", i + 1, allUnits[i].Name);
                        allUnits[i] = null;
                    }
                }
            }
     
            return result;
        }
      
        static void SetAllUnitAction(BaseUnit[] allunits)
        {
            for (int i=0; i<allunits.Length; i++)
            {
                BaseUnit unit = allunits[i];
                
                if (unit == null)
                    continue;

                unit.SetAction();
            }
        }
        static bool IsEndTurn(BaseUnit[] allUnits)
        {
            foreach(BaseUnit unit in allUnits)
            {
                if (unit == null)
                    continue;
                if (unit.IsAction)
                    return false;
            }
            return true;
        }
    }
}
