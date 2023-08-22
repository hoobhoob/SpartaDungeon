using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class ShopSellScene : DisplayGame
    {
        private Character _player;
        private List<Item> _items;
        private float _discountPercentage;

        public ShopSellScene(Character player)
        {
            buttons = new string[] { "ShopScene", "ShopSellScene" };
            buttonsName = new string[] { "나가기" };
            this._player = player;
            _items = _player.Invertory;
            _discountPercentage = 0.85f;
        }
        public override void DisplayTitle()
        {
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");

        }

        public override void DisplayMain()
        {
            Console.WriteLine($"\n[보유 골드]");
            Console.WriteLine($"{_player.Gold} G");
            Console.WriteLine($"\n[아이템 목록]\n");
            int i = 1;
            int x = 25;
            int y = 8;
            foreach (Item item in _player.EquippedItems)
            {
                int count = 0;
                int oldY = y;
                Console.Write($"- {i,2} [E] {item.Name}");
                Console.SetCursorPosition(x + 35, y);
                Console.Write($" | {item.Info}");
                if (item.Stats.Atk != 0)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine($" | 공격력 {item.Stats.Atk.ToString("+#;-#")}");
                    count++;
                }
                if (item.Stats.Def != 0)
                {
                    Console.SetCursorPosition(x, y + count);
                    Console.WriteLine($" | 방어력 {item.Stats.Def.ToString("+#;-#")}");
                    count++;
                }
                if (item.Stats.HP != 0)
                {
                    Console.SetCursorPosition(x, y + count);
                    Console.WriteLine($" | 체  력 {item.Stats.HP.ToString("+#;-#")}");
                    count++;
                }
                if (item.Stats.Atk == 0 && item.Stats.Def == 0 && item.Stats.HP == 0)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" | ");
                }
                Console.SetCursorPosition(x + 20, oldY);
                Console.WriteLine($" | {(int)(item.Price() * _discountPercentage)} G");
                y += count;
                i++;
            }
            foreach (Item item in _player.Invertory)
            {
                if (!_player.EquippedItems.Contains(item))
                {
                    int count = 0;
                    int oldY = y;
                    Console.Write($"- {i,2}     {item.Name}");
                    Console.SetCursorPosition(x + 35, y);
                    Console.Write($" | {item.Info}");
                    if (item.Stats.Atk != 0)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine($" | 공격력 {item.Stats.Atk.ToString("+#;-#")}");
                        count++;
                    }
                    if (item.Stats.Def != 0)
                    {
                        Console.SetCursorPosition(x, y + count);
                        Console.WriteLine($" | 방어력 {item.Stats.Def.ToString("+#;-#")}");
                        count++;
                    }
                    if (item.Stats.HP != 0)
                    {
                        Console.SetCursorPosition(x, y + count);
                        Console.WriteLine($" | 체  력 {item.Stats.HP.ToString("+#;-#")}");
                        count++;
                    }
                    if (item.Stats.Atk == 0 && item.Stats.Def == 0 && item.Stats.HP == 0)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine(" | ");
                    }
                    Console.SetCursorPosition(x + 20, oldY);
                    Console.WriteLine($" | {(int)(item.Price() * _discountPercentage)} G");
                    y += count;
                    i++;
                }
            }
        }

        public new string DIsplayReadNumber()
        {
            Console.WriteLine();
            while (buttons != null)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>  ");
                string? choice = Console.ReadLine();
                if (choice != null && int.TryParse(choice, out int number))
                {
                    if (number == 0)
                    {
                        return buttons[0];
                    }
                    else if (number <= _items.Count)
                    {
                        _player.SellItem(_items[number - 1], (int)(_items[number - 1].Price() * _discountPercentage));
                        return buttons[1];
                    }
                }
                Console.WriteLine("\n잘못된 입력입니다.\n");
            }
            return "StartScene";
        }

        public new string Display()
        {
            Console.Clear();
            DisplayTitle();
            DisplayMain();
            DisplayChoice();
            return DIsplayReadNumber();
        }
    }
}
