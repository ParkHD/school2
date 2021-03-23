using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp7
{
    struct UnitStatus
    {
        public int hp;             // 체력
        public int mp;             // 마나
        public int shield;         // 쉴드

        public UnitStatus(int hp, int mp, int shield)
        {
            this.hp = hp;
            this.mp = mp;
            this.shield = shield;
        }
    }
    struct Weapon
    {
        public int     power;
        public float   attackSpeed;
        public float   range;
        public string  name;
        public Weapon(string name, float attackSpeed, float range, int power)
        {
            this.name = name;
            this.power = power;
            this.range = range;
            this.attackSpeed = attackSpeed;
        }
        public void ShowInfo()
        {
            Console.WriteLine("무기 : {0}, 공격력 : {1}, 공속 : {2}, 사거리 : {3}", name, power, attackSpeed, range);
        }
    }
    abstract class BaseUnit                             // abstract 독립적으로 생성할 수 없다.(함수도 가능)
    {
        protected string name;           // 이름
        protected int killCount;         // 킬수
        protected int attack;            // 공격력
        protected int defence;           // 방어력
        protected float attackSpeed;     // 공격속도
        protected float moveSpeed;       // 이동속도
        protected float shieldDefence;   // 쉴드방어력

        protected UnitStatus baseStatus;  // 기본능력치
        protected UnitStatus finalStatus; // 실 사용 능력치
        protected Weapon weapon;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public int Hp
        {
            get
            {
                return finalStatus.hp;
            }
            private set
            {
                int getValue = value;

                if (getValue > MAX_HP)
                {
                    getValue = MAX_HP;
                }
                if (getValue < 0)
                {
                    getValue = 0;
                }
                finalStatus.hp = getValue;
            }
        }
        public int MAX_HP
        {
            get
            {
                return baseStatus.hp;
            }
        }
        public int Mp
        {
            get
            {
                return finalStatus.mp;
            }
            set
            {
                if (value < 0)
                    value = 0;
                else if (value > MAX_MP)
                    value = MAX_MP;

                finalStatus.mp = value;
            }
        }
        public int MAX_MP
        {
            get
            {
                return baseStatus.mp;
            }
        }
        public int Attack
        {
            get
            {
                return weapon.power;
            }
        }
        public abstract void ShowInfo();
        public virtual void AttackedTo(BaseUnit target)
        {
            target.TakeDamaged(this);
        }
        protected void TakeDamaged(BaseUnit attacker)
        {
            Hp -= attacker.Attack;
            Console.WriteLine("{0}[{1}/{2}]가 {3}에게 {4}의 피해를 받음", name, Hp, MAX_HP, attacker.name, attacker.Attack);
        }
    
    }
    class Marine : BaseUnit
    {
        public Marine()
        {
            name = "마린";
            baseStatus = new UnitStatus(100, 0, 0);
            finalStatus = baseStatus;
            weapon = new Weapon("가스총", 3.5f, 5.5f, 5);
        }
        public override void ShowInfo()
        {
            Console.WriteLine("============");
            Console.WriteLine("이름 : {0} \n체력 : {1}/{2}", name, Hp, MAX_HP);
            Console.WriteLine("============");
        }
    }
    class Medic : BaseUnit
    {
        public Medic()
        {
            name = "매딕";
            baseStatus = new UnitStatus(100, 100, 0);
            finalStatus = baseStatus;
        }   
        public override void ShowInfo()
        {
            Console.WriteLine("============");
            Console.WriteLine("이름 : {0} \n체력 : {1}/{2} \n마나 : {3}/{4}", name, Hp, MAX_HP, Mp, MAX_MP);
            Console.WriteLine("============");
        }
        public override void AttackedTo(BaseUnit target)
        {
            Console.WriteLine("매딕은 공격할 수 없습니다.");
        }

    }
    class Ghost : BaseUnit
    {
        public Ghost()
        {
            name = "고스트";
            baseStatus = new UnitStatus(150, 75, 0);
            finalStatus = baseStatus;
            weapon = new Weapon("저격총", 10.5f, 10.5f, 20);
        }
        public override void ShowInfo()
        {
            Console.WriteLine("============");
            Console.WriteLine("이름 : {0} \n체력 : {1}/{2} \n마나 : {3}/{4}", name, Hp, MAX_HP, Mp, MAX_MP);
            Console.WriteLine("============");
        }
    }
}
