using System;

namespace ConsoleApp7
{
    using static BaseUnit;
    using static Animal;
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
            /////////////////////////////////////////////////////////////////////////////////////
            //상속
            Dog[] dogArray = new Dog[5];
            dogArray[0] = new Dog("dogA", 3.0f, 4);
            dogArray[1] = new Dog("dogB", 3.0f, 4);
            dogArray[2] = new Dog("dogC", 3.0f, 4);

            Cat[] catArray = new Cat[5];
            catArray[0] = new Cat("catA", 3.0f, 4);
            catArray[1] = new Cat("catB", 3.0f, 4);
            catArray[2] = new Cat("catC", 3.0f, 4);
            catArray[3] = new Cat("catD", 3.0f, 4);
            catArray[4] = new Cat("catE", 3.0f, 4);

            Animal[] animalArray = new Animal[8];
            animalArray[0] = new Cat("catA", 3.0f, 4);
            animalArray[1] = new Cat("catB", 3.0f, 4);
            animalArray[2] = new Cat("catC", 3.0f, 4);
            animalArray[3] = new Cat("catD", 3.0f, 4);
            animalArray[4] = new Cat("catE", 3.0f, 4);

            animalArray[5] = new Dog("dogA", 3.0f, 4);
            animalArray[6] = new Dog("dogB", 3.0f, 4);
            animalArray[7] = new Dog("dogC", 3.0f, 4);
            //foreach (Cat cat in catArray)
            //{
            //    Console.Write(cat.name);
            //    cat.Cry();
            //}
            //foreach(Dog dog in dogArray)
            //{
            //    dog.Cry();
            //}
            foreach (Animal animal in animalArray)
            {
                animal.Cry();
                animal.Eat(Feed.CatFeed);
            }
        }

        static BaseUnit[] unitArray = new BaseUnit[10];
        static void InitUnit()
        {
            unitArray[0] = new BaseUnit("마린", new UnitStatus(100, 0, 0));
        }

        static BaseUnit GetUnit(String name)
        {
            BaseUnit result = null;
            int count = 0;
            foreach(BaseUnit unit in unitArray)
            {
                if (unit == null)
                    continue;
                if(unit.Name == name)
                {
                    result = unit;
                    break;
                }
            }
            return result;
        }
    
    }
}
