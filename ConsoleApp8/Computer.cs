using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace ConsoleApp8
{
    class Computer
    {
        List<int> power = new List<int>();

        public Computer()
        {
            power.Add(10);
        }
        public void Port(IConnect connect)
        {
            Console.WriteLine("USB확인중...");
            Thread.Sleep(1000);
            if (connect.CheckValid("window10", "20.24"))
            {
                Console.WriteLine("USB연결 : {0}", connect.GetInfo());
            }
            else
            {
                Console.WriteLine("USB 연결 실패 : {0}", connect.GetInfo());
            }
        }
        //public void Port(Usb usb)
        //{
        //    Console.WriteLine("USB확인중...");
        //    Thread.Sleep(1000);
        //    Console.WriteLine("usb연결 : {0},", connect.GetInfo());
        //}
    }
}
