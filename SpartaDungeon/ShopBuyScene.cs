
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
            fontColorChange.Write(ConsoleColor.Cyan, "\n상점");
            Console.Write(" - ");
            fontColorChange.WriteLine(ConsoleColor.Yellow, "아이템 구매");
            Console.WriteLine("\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
        }

        public override void DisplayMain()
        {
            Console.WriteLine($"\n[보유 골드]");
            fontColorChange.Write(ConsoleColor.Yellow, $"{_player.Gold}");
            Console.WriteLine(" G");
            Console.WriteLine($"\n[아이템 목록]\n");
            int i = 1;
            int x = 25;
            int y = 11;
            foreach (Item item in _items)
            {
                int count = 0;
                int oldY = y;
                Console.Write("- ");
                fontColorChange.Write(ConsoleColor.Magenta, $"{i,2} ");
                Console.Write($" {item.Name}");
                Console.SetCursorPosition(x + 35, y);
                Console.Write($" | {item.Info}");
                if (item.Stats.Atk != 0)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" | 공격력 ");
                    fontColorChange.WriteLine(ConsoleColor.Magenta, $"{item.Stats.Atk.ToString("+#;-#")}");
                    count++;
                }
                if (item.Stats.Def != 0)
                {
                    Console.SetCursorPosition(x, y + count);
                    Console.Write(" | 방어력 ");
                    fontColorChange.WriteLine(ConsoleColor.Magenta, $"{item.Stats.Def.ToString("+#;-#")}");
                    count++;
                }
                if (item.Stats.HP != 0)
                {
                    Console.SetCursorPosition(x, y + count);
                    Console.Write(" | 체  력 ");
                    fontColorChange.WriteLine(ConsoleColor.Magenta, $"{item.Stats.HP.ToString("+#;-#")}");
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
                    Console.Write(" | ");
                    fontColorChange.WriteLine(ConsoleColor.Red, "구매완료");
                }
                else
                {
                    Console.Write(" | ");
                    fontColorChange.Write(ConsoleColor.Green, $"{item.Price()}");
                    Console.WriteLine(" G");
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
                        fontColorChange.BackgroundWriteLine(ConsoleColor.DarkRed, "\n잘못된 입력입니다.");
                        Console.WriteLine();
                        break;
                    case 1:
                        fontColorChange.BackgroundWriteLine(ConsoleColor.DarkGreen, "\n이미 구매한 아이템입니다.");
                        Console.WriteLine();
                        break;
                    case 2:
                        fontColorChange.BackgroundWriteLine(ConsoleColor.DarkYellow, "\nGold 가 부족합니다.");
                        Console.WriteLine();
                        break;
                    default:
                        fontColorChange.BackgroundWriteLine(ConsoleColor.DarkRed, "\n잘못된 입력입니다.");
                        Console.WriteLine();
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
