using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace ConsoleApp8
{
    interface IConnect
    {

        bool CheckValid(string systemOS, string systemVersion);
        string GetInfo();
    }
    interface IPower
    {

    }
    class ComputerPart
    {

    }
    class Keyboard : ComputerPart, IConnect
    {
        string name;
        public Keyboard(string name)
        {
            this.name = name;
        }
        bool IConnect.CheckValid(string systemOS, string systemVersion)
        {
            return true;
        }

        string IConnect.GetInfo()
        {
            return name;
        }
    }
    class Mouse : ComputerPart, IConnect
    {
        string name;
        public Mouse(string name)
        {
            this.name = name;
        }
        bool IConnect.CheckValid(string systemOS, string systemVersion)
        {
            return true;
        }

        string IConnect.GetInfo()
        {
            return name;
        }
    }
    class Usb : ComputerPart, IConnect,IPower
    {
        string usbType;
        int size;

        bool IConnect.CheckValid(string systemOS, string systemVersion)
        {
            return true;
        }

        string IConnect.GetInfo()
        {
            return string.Format("USB : {0} [{1}]", usbType, size);
        }
        public Usb(string usbType, int size)
        {
            this.usbType = usbType;
            this.size = size;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> power = new List<int>();
            power.Add(10);
            power.Add(20);
            ShowList(power);
            
            power.RemoveAt(0);
            ShowList(power);
            power.Insert(0,50);
            ShowList(power);

            List<int> list = new List<int>();
            for(int i =0; i<100; i++)
            {
                list.Add(0);
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(list[10]);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            
            
            
            return;
            

            Computer computer = new Computer();
            Usb usb = new Usb("Sandisk", 32);
            Usb usb1 = new Usb("SBS", 64);
            computer.Port(usb);
            computer.Port(usb1);

            Keyboard keyboard = new Keyboard("SAMSUNG KeyBoard");
            Mouse mouse = new Mouse("삼성마우스");

            computer.Port(keyboard);
            computer.Port(mouse);
        }
        static void ShowList(List<int> list)
        {
            Console.WriteLine("list의 길이는 : {0}", list.Count);
            for (int i=0;i<list.Count;i++)
            {
                Console.WriteLine("list[{0}]의 값은 : {1}", i, list[i]);
            }
        }
    }

}
