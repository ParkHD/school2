using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp3
{
    
    class Player
    {
        string name;
        int hp;

        public event Action<string> OnDead;
        

        //Func<string> func;
        readonly int MAX_HP;
        public Player(string name, int hp)
        {
            this.name = name;
            this.hp = hp;

            MAX_HP = hp;
        }
        public void TakeDamager(int power)
        {
            hp -= power;
            Console.WriteLine("{0}이 {1}의 데미지를 받았습니다. [남은 체력 : {2}", name, power, hp);
            if(hp <= 0)
            {
                OnDead?.Invoke(name);
                
                Revive();
            }
        }
        public void Revive()
        {
            hp = MAX_HP;
            Console.WriteLine("{0}이 부활했습니다.", name);
        }
        public void RegedstedDeadForce(ref Action action)
        {
            action += DeadForce;
        }
        private void DeadForce()
        {
            hp = 0;
            Console.WriteLine("{0}은 죽었습니다.", name);
        }
    }
    class Party
    {
        Player[] player;
        int liveCount = 0;


        public event Action onKillAll;
        public Party(Player[] player)
        {
            this.player = player;
            liveCount = 3;
            for(int i=0;i<player.Length; i++)
            {
                player[i].OnDead += OnDeadPlayer;
                player[i].RegedstedDeadForce(ref onKillAll);
            }
        }
        public void OnDeadPlayer(string name)
        {
            Console.WriteLine("{0}이 죽었습니다!!", name);
            Console.WriteLine("남은 파티 목숨 :{0}", --liveCount);

            if (liveCount <= 0)
            {
                onKillAll?.Invoke();
                Console.WriteLine("도전 실패...");
            }
        }
        
    }

    class Popup
    {
        string title;
        string content;
        Action<int> OnCallback;
        void Show(params string[] choice)
        {
            Console.WriteLine(title);
            Console.WriteLine(content);
            for(int i=0;i<choice.Length; i++)
            {
                Console.WriteLine("{0}.{1} ", i + 1, choice[i]);
            }
            Console.WriteLine("");
            Console.WriteLine("선택은 : ");

            string input = Console.ReadLine();
            OnCallback(int.Parse(input) -1);
        }
        public void OnShowPopup(string title, string content,Action<int> onCallback, params string[] choice)
        {
            this.title = title;
            this.content = content;
            this.OnCallback = onCallback;

            Show(choice);
        }
    }
    class Shop
    {
        public void Buy()
        {
            Popup popup = new Popup();
            popup.OnShowPopup("캐쉬장", "크리스탈 2000개를 구매하시겠습니까?", (index) => 
            {
                if (index > 0)
                    return;
                switch(index)
                {
                    case 0:
                        Console.WriteLine("크리스탈 구매 완료");
                        break;
                    case 1:
                        break;

                }
            }, "예", "아니요");
        }
    }
}
