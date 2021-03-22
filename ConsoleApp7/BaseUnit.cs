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
    class BaseUnit
    {
        string  name;           // 이름
        int     killCount;      // 킬수
        int     attack;         // 공격력
        int     defence;        // 방어력
        float   attackSpeed;    // 공격속도
        float   moveSpeed;      // 이동속도
        float   shieldDefence;  // 쉴드방어력

        UnitStatus baseStatus;  // 기본능력치
        UnitStatus finalStatus; // 실 사용 능력치

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
        
        public BaseUnit(string name, UnitStatus unitStatus)
        {
            this.name = name;
            baseStatus = unitStatus;
            finalStatus = unitStatus;
        }
        public BaseUnit(BaseUnit unit)
        {

        }
    }
}
