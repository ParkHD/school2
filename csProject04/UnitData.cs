using System;
using System.Collections.Generic;
using System.Text;

namespace csProject04
{
    class UnitData
    {
        // 클래스 이야기할 때. 저는 스타크레프트.
        public class Unit
        {
            public enum UnitKind
            {
                None,
                Marine,
                Ghost,
                Ultra,
                Zergling,
                Firebet,
            }
            // 필드(=맴버변수)
            // 앞에 public을 안 붙이면 기본적으로 private.
            // 5가지의 제한자가 있는데.. 일단 3개만 씁니다.
            // public, private, protected.

            // readonly는 상수로 지정하겠다.
            // 단, 생성자 부분에서 초기화 할때는 값이 지정된다.
            readonly int MAX_HP;

            string name;     // 기본 값인 공백.
            int hp;          // 기본 값이 0.
            float moveSpeed; // 기본 값이 0.0f.
            int power;       // 기본 값이 0.
            UnitKind unitKind;

            //private bool isDead; // 이게 true(1)이면 살아있다. false(0)이면 죽어있다.
            public string Name
            {
                get
                {
                    return name;
                }
            }
            public int Power
            {
                get
                {
                    return power;
                }
            }
            public float MoveSpeed
            {
                get
                {
                    return moveSpeed;
                }
            }
            public int Hp
            {
                get
                {
                    return hp;
                }
            }

            // 프로퍼티.
            /* 보통 이렇게 쓰지는 않는다.
            public string Name
            {
                get;            // 값을 읽는것.
                private set;    // 값을 넣는것.
            }
            */
            /*
            public int HP
            {
                get
                {
                    return hp;
                }
                set
                {
                    int hpValue = value;

                    // value는 외부에서 넣은 값이 들어온다.
                    if (hpValue >= 0)
                        hp = value;
                }
            }
            */
            public bool IsAlive
            {
                get
                {
                    return hp > 0;
                }
            }
            public bool IsDead
            {
                get
                {
                    return hp <= 0;
                }
            }

            // 생성자.
            public Unit(string name, int hp, float moveSpeed, int power, UnitKind unitKind)
            {
                // 상수 이지만... readonly상수 형태라서 생성자 부분에서 최초 값 대입이 가능.
                MAX_HP = hp;

                this.name = name;
                this.hp = hp;
                this.moveSpeed = moveSpeed;
                this.power = power;
                this.unitKind = unitKind;
                // this.atkSpeed = 0;
            }
            public Unit(Unit unit, string name) : this(name, unit.hp, unit.moveSpeed, unit.power, unit.unitKind)
            {

            }


            // 이벤트.
            public event EventHandler ChangeName;

            // 메서드(=맴버함수)
            // 데미지를 받았다.
            public void TakeDamage(string attakerName, int power)
            {
                // 만약에 hp가 10인데. power가 15다.
                /*
                if ((hp -= power) < 0)
                    hp = 0;
                */
                // 이건 선택이다.
                hp -= power;
                if (hp < 0)
                    hp = 0;

                Console.WriteLine("{0}가 {1}에게 데미지 {2}를 받았다. [HP : {3} / {4}]",
                    name, attakerName, power, hp, MAX_HP);

                if (IsDead)
                    Console.WriteLine("{0}은 죽었습니다.", name);
            }

            // 함수 오버로딩.
            public void TakeDamage(Unit attaker)
            {
                // 분명히.. name = 맴버 변수 name은 private인데... 왜 접근이 가능하죠?
                TakeDamage(attaker.name, attaker.power);
            }
            public void Heal(int heal)
            {
                int beforeHp = hp;
                hp += heal;

                // 최대 HP를 넘어갔으니 최대 HP로 고정하라.
                if (hp > MAX_HP)
                    hp = MAX_HP;

                Console.WriteLine("회복을 받았습니다. {0} > {1}(+{2})", beforeHp, hp, heal);
            }

            public void Move()
            {

            }
            public void ShowInfo()
            {
                Console.WriteLine("이름 : {0}, 체력 : {1}/{4}, 공력력 : {2}, Type : {3}", name, hp, power, unitKind, MAX_HP);
            }
            public bool IsKind(UnitKind unitKind)
            {
                return this.unitKind == unitKind;
            }
        }
    }
}
