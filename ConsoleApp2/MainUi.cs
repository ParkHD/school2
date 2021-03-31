using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    delegate void DlSendInt(int value);
    delegate void DlAction();
    class MainUi
    {
        string hpIcon;
        string minimap;
        string weapon;
        public MainUi()
        {
            minimap = "미니맵 출력중...";
            weapon = "내 무기 출력중...";
            hpIcon = "최대체력 출력중...";
        }
        public void ShowUI()
        {
            Console.WriteLine("미니맵 : {0}", minimap);
            Console.WriteLine("무기 : {0}", weapon);
            Console.WriteLine("체력 : {0}", hpIcon);
        }
        public void UpdateHp(int hp)
        {
            hpIcon = string.Format("HP : {0}", hp.ToString());
        }
    }

    class Player
    {
        int hp;
        DlSendInt onSendHp;
        public event DlAction onGameover;
        public int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
                if (onSendHp != null)
                {
                    onSendHp(hp);
                }

                    if (hp <= 0)
                        onGameover?.Invoke();

                   

            } 
        }

        public Player(int hp)
        {
            this.Hp = hp;
        }
        public void RegestedHpEvent(DlSendInt onSendHp)
        {
            this.onSendHp += onSendHp;
        }
        public void TakeDamage(int power)
        {
            Hp -= power;
        }
        public void Heal(int power)
        {
            Hp += power;
        }
    }
}
