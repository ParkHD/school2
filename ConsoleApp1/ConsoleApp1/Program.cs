using System;

namespace ConsoleApp1
{
    class Program
    {


        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //string string_value = "Hello";
            //string string_value2 = " World!";

            //string_value += string_value2;

            //Console.WriteLine(string_value + string_value.Length);

            //int[] array_value = new int[3];
            //int[] array_value2 = new int[] { 2, 3, 4, 5, 6 };

            //Console.WriteLine(array_value2.Length);

            //for(int i = 0;i<array_value2.Length; i++)
            //{

            //}
            //foreach(int value in array_value2)
            //{
            //    Console.WriteLine(value);
            //}

            //int[,] array3 = new int[2, 3];
            //int[,] array4 = new int[,] { { 1, 2, 3 }, { 4, 5, 6, } };

            //for (int i = 0; i < array4.GetLength(0); i++)
            //{
            //    for(int j =0;j<array4.GetLength(1); j++)
            //    {
            //        Console.WriteLine(array4[i, j]);
            //    }
            //}
            //foreach (int value in array4)
            //    Console.WriteLine(value);


            //Player player = new Player(100);
            //player.info();
            //int hp = player.Atk;
            //Console.WriteLine(hp);


            //int[] array = new int[10];
            //for(int i =0; i<array.Length; i++)
            //{
            //    array[i] = i;
            //}
            //foreach(int value in array)
            //{
            //    Console.WriteLine(value);
            //}


            Dog dog1 = new Dog(1, "A", 1.2f);
            Dog dog2 = new Dog(2, "B", 1.3f);
            Dog dog3 = new Dog(3, "C", 1.4f);

            dog1.Info();
            dog2.Info();
            dog3.Info();

            Dog[] dogs = new Dog[3];
            dogs[0] = new Dog(1, "A", 1.2f);
            dogs[1] = new Dog(2, "B", 1.3f);
            dogs[2] = new Dog(3, "C", 1.4f);

            foreach (Dog dog in dogs)
                dog.Info();
        }
    }
    class Player
    {
        readonly int Max_hp = 100;
        int atk = 10;
        public int Atk
        {
            get;
        
        }

           
        public Player(int max_hp)
        {
            Max_hp = max_hp;
        }
        public void info()
        {
            Console.WriteLine(Max_hp);
        }
    }
    class Dog
    {
        int age;
        string name;
        float weight;

        public Dog(int _age, string _name, float _weight)
        {
            age = _age;
            name = _name;
            weight = _weight;
        }
        public void Info()
        {
            Console.WriteLine("나이 : {0}, 이름 : {1}, 몸무게 : {2}", age, name, weight);
        }
    }


}
