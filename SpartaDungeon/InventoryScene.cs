
namespace SpartaDungeon
{
    internal class InventoryScene : DisplayGame
    {
        private Character _player;

        public InventoryScene(Character player)
        {
            buttons = new string[] { "StartScene", "InventoryManager" };
            buttonsName = new string[] { "나가기", "장착 관리" };
            this._player = player;
        }

        public override void DisplayTitle()
        {
            fontColorChange.WriteLine(ConsoleColor.Cyan, "\n인벤토리");
            Console.WriteLine("\n보유 중인 아이템을 관리할 수 있습니다.\n");
        }

        public override void DisplayMain()
        {
            Console.WriteLine("\n[아이템 목록]\n");
            int x = 25;
            int y = 8;
            foreach (Item item in _player.EquippedItems)
            {
                int count = 0;
                Console.Write($"- ");
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
            }
            foreach (Item item in _player.Invertory)
            {
                if (!_player.EquippedItems.Contains(item))
                {
                    int count = 0;
                    Console.Write($"-     {item.Name}");
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
                    if(item.Stats.Atk == 0 && item.Stats.Def == 0 && item.Stats.HP == 0)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine(" | ");
                    }
                    y += count;
                }
            }
        }
    }
}
