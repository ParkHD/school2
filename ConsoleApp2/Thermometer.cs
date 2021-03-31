using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class meterManager
    {
        readonly string name;
        public meterManager(string name)
        {
            this.name = name;
        }
        public void GetWarningMsg(string msg)
        {
            Console.WriteLine("{0}이 문자 수신 : {1}", name, msg);
        }
    }
    class meterOwner
    {
        public void GetWarningMsg(string msg)
        {
            Console.WriteLine("문자 수신 : {0}", msg);
        }
    }

    delegate void DlSendMessage(string msg);
    class Thermometer
    {
        DlSendMessage onSendMessage;
        readonly int warningTempre; // 특정온도
        
        public Thermometer(int warningTempre)
        {
            this.warningTempre = warningTempre;
        }
        public void RedgistedMessage(DlSendMessage onSendMessage)
        {
            this.onSendMessage += onSendMessage;
        }
        public void CollectTempre(meterManager manager)
        {
            Random random = new Random();
            int tempre = random.Next(15, 41);

            Console.WriteLine("현재 온도 : {0}", tempre);

            if(tempre >= warningTempre)
            {
                manager.GetWarningMsg(string.Format("특정온도를 넘어 섰습니다. [온도:{0}]", tempre));
            }
        }
        public void CollectTempre(DlSendMessage onSendMessage)
        {
            onSendMessage += onSendMessage;
        }
    }
}
