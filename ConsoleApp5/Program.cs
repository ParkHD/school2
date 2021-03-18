using System;

namespace ConsoleApp5
{
    class Program
    {
        class Unit
        {
            readonly int MAX_HP;                    // 상수로 취급 하지만 생성자에서 초기화 할때는 값이 지정된다.

            string name;
            int hp;
            float moveSpeed;
            int power;
            bool isDead;

            public event EventHandler ChangeName;

            public Unit(string name = "", int power = 0, int hp = 0)
            {
                MAX_HP = hp;
                this.name = name;
                this.power = power;
                this.hp = MAX_HP;
                isDead = false;
            }
           
            public string Name          // property
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
                    if (hp <= 0)
                        return hp = 0;
                    return hp;
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
            public bool IsDead
            {
                get
                {
                    if (hp <= 0)
                    {
                        Console.WriteLine("{0}가 죽음", name);
                        return isDead = true;
                    }
                    return isDead;      
                }
            }

            public void Move()
            {

            }
            public void TakeDamage(string attackerName, int damage)
            {
                hp -= damage;
                Console.WriteLine("{0}가 {1}에게 데미지 {2}를 받았다. [HP : {3}]", Name, attackerName, damage, Hp);
            }
            public void TakeDamage(Unit attacker)
            {
                TakeDamage(attacker.Name, attacker.Power);
            }
            public void TakeHeal(int heal)
            {
                int beforeHp = hp;
                hp += heal;
                if (hp >= MAX_HP)
                    hp = MAX_HP;
                Console.WriteLine("{0}이 회복을 받았습니다. [HP : {1} -> {2}]", Name, beforeHp, Hp);
            }
        }
        static void Main(string[] args)
        {
            Unit unit1 = new Unit();
           

            Unit unit2 = new Unit("Zergling",80,100);

            Unit unit3 = new Unit("Ultra", 10,300);
            while(!unit3.IsDead)
            {
                
                unit3.TakeDamage(unit2);
               
            }
            unit3.TakeHeal(10);
        }

    }
    
}
