using System;
using System.Collections.Generic;
using System.Text;

namespace csProject_2_01
{
    // C#에서 자주 쓰는 형태인데.
    struct UnitStatus
    {
        public int hp;             // 체력. (o)
        public int mp;             // 마나. (o)
        public int shield;         // 쉴드. (o)

        public UnitStatus(int hp, int mp, int shield)
        {
            this.hp = hp;
            this.mp = mp;
            this.shield = shield;
        }

        public void Sometine()
        {

        }
    }

    // 무기 클래스.
    struct Weapon
    {
        public string name;            // 무기 이름.
        public int power;              // 무기 공격력.
        public float attackSpeed;      // 공격 속도.
        public float range;            // 무기 사거리.

        // 클래스의 생성자.
        // 공개범위 클래스명(....).
        public Weapon(string name, int power, float attackSpeed, float range)
        {
            this.name = name;
            this.power = power;
            this.attackSpeed = attackSpeed;
            this.range = range;
        }

        public void ShowInfo()
        {
            Console.WriteLine("무기:{0}, 공격력:{1}, 공속:{2}, 사거리:{3}", name, power, attackSpeed, range);
        }
    }

    // abstract class는 독립적으로 생성할 수 없다.
    abstract class BaseUnit
    {
        // 유닛을 만들었는데 이번에는 내부 속성을 생각해보자.
        // 잘 생각해보면 내부에는 변하는 값과 변하지 않는 값이 있다. (게임상)
        // 물론 업그레이드라는 게 없다고 가정.
        protected string name;            // 이름.
        protected UnitStatus baseStatus;  // 기본 능력치.    (변하지 않는 초기 값)
        protected UnitStatus finalStatus; // 실 사용 능력치. (변하는 실제 조작 값)
        protected Weapon weapon;          // 무기.

        public string Name 
        {
            get
            {
                return name;
            }
        }
        public int Hp
        {
            // public
            get
            {
                return finalStatus.hp;
            }
            // set은 private.
            private set
            {
                // 체력은 최대체력을 넘지 않는다.
                // 외부에서 대입하는 값에 들어있다.
                int getValue = value;

                // 최대 체력이 넘어가면 최대 체력으로 고정하라.
                if (getValue > MAX_HP)
                {
                    getValue = MAX_HP;
                }
                // 체력이 0이하이면 0으로 고정하라.
                else if (getValue < 0)
                {
                    getValue = 0;
                }

                // 실제 hp에 들어가는 값은 0이상 max_hp이하를 보장한다.
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
        public int MP
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

        // 살아있는가? 죽었는가?.
        public bool IsAlive
        {
            get
            {
                return Hp > 0;
            }
        }

        protected bool isAction;  // 행동을 했는가?
        public bool IsAction
        {
            get
            {
                return isAction;
            }
        }

        // 능력치를 보여주는 함수.
        // 이름만 선언한 것이다.
        // ShowInfo는 상속 받으면 무조건 구현해야 한다.
        public abstract void ShowInfo();

        public virtual void SetAction()
        {
            // 만약에 살아있다면 액션을 true로 만든다.
            if(IsAlive)
                isAction = true;
        }

        // 공격한다.
        public virtual void AttackedTo(BaseUnit target)
        {
            // 내가 생존해 있지 않을 경우.
            if(!IsAlive)
            {
                Console.WriteLine("{0}은 죽어있어서 행동할 수 없습니다.", name);
                return;
            }
            // 내가 행동을 이미 했다면(false) 실행하지 않는다.
            if (!IsAction)
            {
                Console.WriteLine("{0}은 이미 행동 했습니다.", name);
                return;
            }
            // 공격 대상이 생존해있지 않다면.
            if(!target.IsAlive)
            {
                Console.WriteLine("{0}은 죽어있어서 공격할 수 없습니다.", target.name);
                return;
            }

            isAction = false;                        

            // this는 나를 뜻한다.
            target.TakeDamaged(this);
        }
        // 공격을 받는다.
        protected void TakeDamaged(BaseUnit attacker)
        {
            Hp -= attacker.weapon.power;

            Console.WriteLine("{0} >> {1} >> {2}({3}/{4})를 공격", attacker.name, attacker.weapon.power,
                name, Hp, MAX_HP);
        }
    }

    class Marine : BaseUnit
    {
        public Marine()
        {
            name = "마린";
            baseStatus = new UnitStatus(100, 0, 0);
            weapon = new Weapon("가우스소총", 40, 0.2f, 2);

            // 구조체이기 때문에 대입하면 값이 직접 복사가 된다.
            // 클래스라면 가르키고 있는 주소값을 넘겨줄 것이다.
            finalStatus = baseStatus;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("================");
            Console.WriteLine("이름 : {0}", name);
            Console.WriteLine("체력:{0}/{1}", Hp, MAX_HP);
            Console.WriteLine("================");
        }

    }

    class Medic : BaseUnit
    {
        public Medic()
        {
            name = "메딕";
            baseStatus = new UnitStatus(100, 200, 0);            
            finalStatus = baseStatus;
        }

        public override void SetAction()
        {
            isAction = false;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("================");
            Console.WriteLine("이름 : {0}", name);
            Console.WriteLine("체력:{0}/{1}, 마나:{2}/{3}", Hp, MAX_HP, MP, MAX_MP);
            Console.WriteLine("================");
        }
        public override void AttackedTo(BaseUnit target)
        {
            Console.WriteLine("{0}은 공격할 수 없습니다.", name);
        }
    }

    class Ghost : BaseUnit
    {
        public Ghost()
        {
            name = "고스트";
            baseStatus = new UnitStatus(120, 150, 0);
            weapon = new Weapon("저격총", 105, 0.8f, 6);
            finalStatus = baseStatus;
        }

        public override void ShowInfo()
        {
            // 몸통을 만들어 줘야 한다.
            Console.WriteLine("================");
            Console.WriteLine("이름 : {0}", name);
            Console.WriteLine("체력:{0}/{1}, 마나:{2}/{3}", Hp, MAX_HP, MP, MAX_MP);
            Console.WriteLine("================");
        }
    }
}
