using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class ShopScene : DisplayGame
    {
        private Character _player;
        private List<Item> _items;

        public ShopScene(Character player)
        {
            buttons = new string[] { "StartScene", "ShopBuyScene", "ShopSellScene" };
            buttonsName = new string[] { "나가기", "아이템 구매", "아이템 판매" };
            this._player = player;
            _items = new List<Item>() { };
        }
        public override void DisplayTitle()
        {
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");

        }

        public override void DisplayMain()
        {
            Console.WriteLine($"\n[보유 골드]");
            Console.WriteLine($"{_player.Gold} G");
            Console.WriteLine($"\n[아이템 목록]\n");

        }
    }
}
