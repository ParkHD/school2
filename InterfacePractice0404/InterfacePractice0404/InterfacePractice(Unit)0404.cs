using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacePractice0404
{
    interface IBunker
    {
        void InBunker();
        void OutBunker();
    }
    class Terran
    {
        protected string name;

        public string Name
        {
            get
            {
                return name;
            }
        }
    }
    class Unit : Terran
    {
        public void Scouting()
        {
            Console.WriteLine("{0}이 정찰중...", name);
        }
    }
    class Marine : Unit ,IBunker
    {
        public Marine(string name)
        {
            this.name = name;
            Console.WriteLine("{0}이 생성되었습니다.", name);
        }
        void IBunker.InBunker()
        {
            Console.WriteLine("{0}이 벙커에 들어갔습니다", name);
        }
        void IBunker.OutBunker()
        {
            Console.WriteLine("{0}이 벙커에서 나왔습니다.", name);
        }
    }
    class Medic : Unit, IBunker
    {
        public Medic(string name)
        {
            this.name = name;
            Console.WriteLine("{0}이 생성되었습니다.", name);
        }
        void IBunker.InBunker()
        {
            Console.WriteLine("{0}이 벙커에 들어갔습니다", name);
        }
        void IBunker.OutBunker()
        {
            Console.WriteLine("{0}이 벙커에서 나왔습니다.", name);
        }
    }
    class FireBat : Unit, IBunker
    {
        public FireBat(string name)
        {
            this.name = name;
            Console.WriteLine("{0}이 생성되었습니다.", name);
        }
        void IBunker.InBunker()
        {
            Console.WriteLine("{0}이 벙커에 들어갔습니다", name);
        }
        void IBunker.OutBunker()
        {
            Console.WriteLine("{0}이 벙커에서 나왔습니다.", name);
        }
    }
    class Ghost : Unit, IBunker
    {
        public Ghost(string name)
        {
            this.name = name;
            Console.WriteLine("{0}이 생성되었습니다.", name);
        }
        void IBunker.InBunker()
        {
            Console.WriteLine("{0}이 벙커에 들어갔습니다", name);
        }
        void IBunker.OutBunker()
        {
            Console.WriteLine("{0}이 벙커에서 나왔습니다.", name);
        }
    }
    class Vulture : Unit
    {
        public Vulture(string name)
        {
            this.name = name;
            Console.WriteLine("{0}이 생성되었습니다.", name);
        }
    }
    class Goliat : Unit
    {
        public Goliat(string name)
        {
            this.name = name;
            Console.WriteLine("{0}이 생성되었습니다.", name);
        }
    }
    class Tank : Unit
    {
        public Tank(string name)
        {
            this.name = name;
            Console.WriteLine("{0}이 생성되었습니다.", name);
        }
    }
    class Building : Terran
    {

    }
    class Barrack : Building
    {
        public Barrack(string name)
        {
            this.name = name;
            Console.WriteLine("{0}이 건설되었습니다.", name);
        }
        public void Produce(ref Unit[] unit)
        {
            Console.Write("1.마린 2.메딕 3.파이어벳 4.고스트\n생산 유닛을 선택하세요 : ");
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
    class Factory : Building
    {
        public Factory(string name)
        {
            this.name = name;
            Console.WriteLine("{0}이 건설되었습니다.", name);
        }
        public void Produce(ref Unit[] unit)
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
    class Bunker : Building
    {
        Unit[] bunkerList;
        public Bunker(string name)
        {
            this.name = name;
            bunkerList = new Unit[4];
            Console.WriteLine("{0}이 건설되었습니다.", name);
        }
        public void InBunker(IBunker bunker)
        {

            for (int i = 0; i < bunkerList.Length; i++)
            {
                if (bunkerList[i] == (Unit)bunker)
                {
                    Console.WriteLine("이미 들어가있씁니다");
                    return;
                }
            }
            for (int i = 0; i < bunkerList.Length; i++)
            {
                if (bunkerList[i] == null)
                {
                    bunkerList[i] = (Unit)bunker;
                    bunker.InBunker();
                    break;
                }
            }
        }
        public void OutBunker()
        {
            for (int i = 0; i < bunkerList.Length; i++)
            {
                if (bunkerList[i] != null)
                {
                    bunkerList[i] = null;
                }
            }
            Console.WriteLine("벙커가 비었습니다.");
        }
        public void ShowBunkerUnit()
        {
            int unitCount = 0;

            for (int i = 0; i < bunkerList.Length; i++)
            {
                if (bunkerList[i] != null)
                {
                    Console.WriteLine("{0}은 벙커 {1}자리에 있습니다.", bunkerList[i].Name, i + 1);
                    unitCount++;
                }
            }
            if(unitCount ==0)
            {
                Console.WriteLine("벙커가 비었습니다.");
            }
        }
    }
}
