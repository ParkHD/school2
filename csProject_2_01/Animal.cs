using System;
using System.Collections.Generic;
using System.Text;

namespace csProject_2_01
{
    public enum Feed
    {
        // 먹이.
        DogFeed, // 개 먹이.
        CatFeed, // 고양이 먹이.
    }

    class Animal
    {
        // 접근 제한자 : public, private, protected.
        // public    : 모든 외부에 공개.
        // private   : 공개하지 않는다. (나만 접근 가능)
        // protected : 공개하지 않지만, 나를 상속한 자식 클래스에서는 접근 가능.
        
        protected string name;     // 이름.
        protected float weight;    // 몸무게.
        protected int age;         // 나이.

        // 그런데.. 만약 자식 클래스 조차도 접근할 수 없게 private로 설정한다.
        private string placeBirth; // 탄생지역.

        public Animal(string placeBirth)
        {
            this.placeBirth = placeBirth;
            Console.WriteLine("동물의 생성자");
        }

        // virtual 가상 함수.
        public virtual void Cry()
        {   
            Console.WriteLine("Animal클래스의 Cry()");
        }
        public virtual void Eat(Feed feed)
        {
            Console.WriteLine("{0}가 먹이 {1}를 맛있게 먹습니다.", name, feed);
        }
    }

    // Cat 클래스는 Animal 클래스를 상속한다.
    // 클래스 : 클래스
    class Cat : Animal
    {
        public int tall; // 신장.

        // Cat의 생성자.
        public Cat(string name, float weight, int age, string placeBirth)
            : base(placeBirth) // 부모 클래스의 생성자를 호출한다.
        {
            this.name = name;
            this.weight = weight;
            this.age = age;

            Console.WriteLine("고양이의 생성자");
        }

        // 울다.
        // 가상 함수를 '재정의' 할 수 있다.
        public override void Cry()
        {
            Console.WriteLine("고양이 : 야옹!");
        }
        public override void Eat(Feed feed)
        {
            if(feed == Feed.CatFeed)
            {
                Console.WriteLine("{0}이 {1}을 잘 먹습니다.", name, feed);
            }
            else
            {
                Console.WriteLine("{0}이 {1}을 거부합니다.", name, feed);
            }
        }
    }
    class Dog : Animal
    {
        public Dog(string name, float weight, int age, string placeBirth)
            : base(placeBirth)
        {
            this.name = name;
            this.weight = weight;
            this.age = age;
        }

        // Cry() 함수의 재정의.
        public override void Cry()
        {
            Console.WriteLine("강아지 : 멍멍!");
        }
    }

    // 더 많은 Animal을 상속 받은 클래스를 만들 수 있다.

}
