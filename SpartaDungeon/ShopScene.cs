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
            _items = ItemData.allItemList;
            //_items.RemoveAt(0);
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

            int y = 8;
            foreach (Item item in _items)
            {
                int count = 0;
                int itemPrice = 0;
                int oldY = y;
                Console.Write($"-  {item.Name}");
                Console.SetCursorPosition(55, y);
                Console.Write($" | {item.Info}");
                if (item.Stats.Atk != 0)
                {
                    Console.SetCursorPosition(20, y);
                    Console.WriteLine($" | 공격력 {item.Stats.Atk.ToString("+#;-#")}");
                    count++;
                    itemPrice += item.Stats.Atk * 200;
                }
                if (item.Stats.Def != 0)
                {
                    Console.SetCursorPosition(20, y + count);
                    Console.WriteLine($" | 방어력 {item.Stats.Def.ToString("+#;-#")}");
                    count++;
                    itemPrice += item.Stats.Def * 200;
                }
                if (item.Stats.HP != 0)
                {
                    Console.SetCursorPosition(20, y + count);
                    Console.WriteLine($" | 체  력 {item.Stats.HP.ToString("+#;-#")}");
                    count++;
                    itemPrice += item.Stats.HP * 20;
                }
                if (item.Stats.Atk == 0 && item.Stats.Def == 0 && item.Stats.HP == 0)
                {
                    Console.SetCursorPosition(20, y);
                    Console.WriteLine(" | ");
                }
                Console.SetCursorPosition(40, oldY);
                Console.WriteLine($" | {itemPrice} G");
                y += count;
                Console.SetCursorPosition(0, y);

            }
        }
    }
}
