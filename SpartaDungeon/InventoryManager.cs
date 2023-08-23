
namespace SpartaDungeon
{
    internal class InventoryManager : DisplayGame
    {
        private List<Item> _equipItems;

        public InventoryManager(Character player)
        {
            buttons = new string[] { "InventoryScene" , "InventoryManager" };
            buttonsName = new string[] { "나가기" };
            this.player = player;
            _equipItems = new List<Item>();
        }

        public override void DisplayTitle()
        {
            fontColorChange.Write(ConsoleColor.Cyan, "\n인벤토리");
            Console.Write(" - ");
            fontColorChange.WriteLine(ConsoleColor.Yellow, "장착 관리");
            Console.WriteLine("\n보유 중인 아이템을 관리할 수 있습니다.\n");
        }

        public override void DisplayMain()
        {
            Console.WriteLine("\n[아이템 목록]\n");
            int i = 1;
            int x = 25;
            int y = 8;
            _equipItems.Clear();
            foreach (Item item in player.EquippedItems)
            {
                int count = 0;
                Console.Write("- ");
                fontColorChange.Write(ConsoleColor.Magenta, $"{i,2} ");
                fontColorChange.BackgroundWrite(ConsoleColor.Blue, "[E]");
                Console.Write($" {item.Name}");
                Console.SetCursorPosition(x + 20, y);
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
                y += count;
                i++;
                _equipItems.Add(item);
            }
            foreach (Item item in player.Inventory)
            {
                if (!player.EquippedItems.Contains(item))
                {
                    int count = 0;
                    Console.Write("- ");
                    fontColorChange.Write(ConsoleColor.Magenta, $"{i,2} ");
                    Console.Write($"    {item.Name}");
                    Console.SetCursorPosition(x + 20, y);
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
                    y += count;
                    i++;
                    _equipItems.Add(item);
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
                    else if (number <= _equipItems.Count)
                    {
                        player.EquipItem(_equipItems[number - 1]);
                        return buttons[1];
                    }
                }
                fontColorChange.BackgroundWriteLine(ConsoleColor.DarkRed, "\n잘못된 입력입니다.");
                Console.WriteLine();
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
