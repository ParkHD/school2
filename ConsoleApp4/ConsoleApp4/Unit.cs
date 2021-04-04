using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    class Unit
    {
        protected string name;
        protected int hp;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public Unit()
        {
        }
        public void Scouting()
        {
            Console.WriteLine("{0}이 정찰 중...", name);
        }
        public void ShowInfo()
        {
            Console.WriteLine("이름 : {0}\n체력 : {1}", name, hp);
        }

    }
    class Terran : Unit
    {
        public virtual void GetInBunker(Bunker bunker)
        {
            Console.WriteLine("벙커에 들어갈 수 없습니다.");
        }
    }
    class Marine : Terran
    {
        public Marine(string name)
        {
            this.name = name;
            hp = 50;

            Console.WriteLine("{0}이 생성되었습니다.", name);
        }

        public override void GetInBunker(Bunker bunker)
        {
            bunker.InUnit(this);
        }

    }
    class Medic : Terran
    {
        public Medic(string name)
        {
            this.name = name;
            hp = 50;
            Console.WriteLine("{0}이 생성되었습니다.", name);
        }
        public override void GetInBunker(Bunker bunker)
        {
            bunker.InUnit(this);
        }

    }
    class Ghost : Terran
    {
        public Ghost(string name)
        {
            this.name = name;
            hp = 75;
            Console.WriteLine("{0}이 생성되었습니다.", name);
        }
        public override void GetInBunker(Bunker bunker)
        {
            bunker.InUnit(this);
        }

    }
    class FireBat : Terran
    {
        public FireBat(string name)
        {
            this.name = name;
            hp = 75;
            Console.WriteLine("{0}이 생성되었습니다.", name);
        }
        public override void GetInBunker(Bunker bunker)
        {
            bunker.InUnit(this);
        }
    }
    class Tank : Terran
    {
        public Tank(string name)
        {
            this.name = name;
            hp = 200;
            Console.WriteLine("{0}이 생성되었습니다.", name);
        }

    }
    class Vulture : Terran
    {
        public Vulture(string name)
        {
            this.name = name;
            hp = 100;
            Console.WriteLine("{0}이 생성되었습니다.", name);
        }

    }
    class Goliat : Terran
    {
        public Goliat(string name)
        {
            this.name = name;
            hp = 150;
            Console.WriteLine("{0}이 생성되었습니다.", name);
        }

    }
}
