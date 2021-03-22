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
        public string name;
        public float weight;
        public int age;
        int tall;

        public int Tall
        {
            get
            {
                return tall;
            }
            set
            {
                tall = value;
            }
        }
        public virtual void Cry() { }
        public virtual void Eat(Feed feed)
        {
            Console.WriteLine("{0}가 먹이 {1}를 맛나게 먹습니다.", name, feed);
        }
    }
    class Cat : Animal
    {
        public Cat(string name, float weight, int age, int tall = 0)
        {
            this.name = name;
            this.weight = weight;
            this.age = age;
            Tall = tall;
        }
        public override void Cry()
        {
            Console.WriteLine("야옹!");
        }

    }
    class Dog : Animal
    {
        public Dog(string name, float weight, int age)
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
