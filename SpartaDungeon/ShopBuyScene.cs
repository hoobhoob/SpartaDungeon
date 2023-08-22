using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class ShopBuyScene : DisplayGame
    {
        private Character _player;
        private List<Item> _items;

        public ShopBuyScene(Character player)
        {
            buttons = new string[] { "ShopScene", "ShopBuyScene" };
            buttonsName = new string[] { "나가기" };
            this._player = player;
            _items = ItemData.allItemList;
            //_items.RemoveAt(0);
        }
        public override void DisplayTitle()
        {
            Console.WriteLine("상점 - 아이템 구매");
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
            foreach (Item item in _items)
            {
                int count = 0;
                int oldY = y;
                Console.Write($"- {i,2}  {item.Name}");
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
                if (_player.Invertory.Contains(item))
                {
                    Console.WriteLine($" | 구매완료");
                }
                else
                {
                    Console.WriteLine($" | {item.Price()} G");
                }
                i++;
                y += count;
                Console.SetCursorPosition(0, y);

            }
        }

        public new string DIsplayReadNumber()
        {
            Console.WriteLine();
            while (buttons != null)
            {
                int errNumber = 0;
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
                        if (_player.Invertory.Contains(_items[number - 1]))
                        {
                            errNumber = 1;
                        }
                        else
                        {
                            if(_items[number - 1].Price() > _player.Gold)
                            {
                                errNumber = 2;
                            }
                            else
                            {
                                _player.BuyItem(_items[number - 1]);
                                return buttons[1];
                            }
                        }
                    }
                }
                switch (errNumber)
                {
                    case 0:
                        Console.WriteLine("\n잘못된 입력입니다.\n");
                        break;
                    case 1:
                        Console.WriteLine("\n이미 구매한 아이템입니다.\n");
                        break;
                    case 2:
                        Console.WriteLine("\nGold 가 부족합니다.\n");
                        break;
                    default:
                        Console.WriteLine("\n잘못된 입력입니다.\n");
                        break;
                }
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
