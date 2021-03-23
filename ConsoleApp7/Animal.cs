using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp7
{
    public enum Feed
    {
        DogFeed,
        CatFeed,
    }
    class Animal
    {
        // public - 공개
        // private - 비공개
        // protected - 비공개지만 상속 받은 자식 클래스에게는 공개.

        protected string name;
        protected float weight;
        protected int age;
        private string birthPlace;

        public Animal(string birthPlace)
        {
            this.birthPlace = birthPlace;
        }

        public virtual void Cry() { }
        public virtual void Eat(Feed feed)
        {
            Console.WriteLine("{0}가 먹이 {1}를 맛나게 먹습니다.", name, feed);
        }
    }
    class Cat : Animal
    {
        public Cat(string name, float weight, int age, string birthPlace)
            :base(birthPlace)
        {
            this.name = name;
            this.weight = weight;
            this.age = age;
        }
        public override void Cry()
        {
            Console.WriteLine("야옹!");
        }

    }
    class Dog : Animal
    {
        public Dog(string name, float weight, int age, string birthPlace)
            :base(birthPlace)
        {
            this.name = name;
            this.weight = weight;
            this.age = age;
        }
        public override void Cry()
        {
            Console.WriteLine("멍!");
        }
        public override void Eat(Feed feed)
        {
            if(feed == Feed.DogFeed)
            {
                Console.WriteLine("{0}가 먹이 {1}를 맛나게 먹습니다.", name, feed);
            }
            else
                Console.WriteLine("{0}가 먹이 {1}를 맛없게 먹습니다.", name, feed);
        }
    }
}
