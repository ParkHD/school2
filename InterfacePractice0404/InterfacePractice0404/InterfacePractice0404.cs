using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacePractice0404
{
    interface IConnect
    {
        bool CheckValid();
        string GetInfo();
    }
    interface IPower
    {
        bool OnPower();
    }

    class Computer
    {
        public void Connect(IConnect connect)
        {
            if (connect.CheckValid())
            {
                Console.WriteLine("{0} 연결성공 ", connect.GetInfo());
            }
        }
        public void GivePower(IPower power)
        {
            power.OnPower();
        }
    }
    class Usb : IConnect
    {
        string name;
        public Usb(string name)
        {
            this.name = name;
        }
        bool IConnect.CheckValid()
        {
            return true;
        }
        string IConnect.GetInfo()
        {
            return string.Format("[USB]{0}",name);
        }
    }
    class Keyboard : IConnect, IPower
    {
        string name;
        public Keyboard(string name)
        {
            this.name = name;
        }
        bool IConnect.CheckValid()
        {
            return true;
        }
        string IConnect.GetInfo()
        {
            return string.Format("[KEYBOARD]{0}", name);
        }
        bool IPower.OnPower()
        {
            Console.WriteLine("키보드 전원 연결완료");
            return true;
        }
    }
}
