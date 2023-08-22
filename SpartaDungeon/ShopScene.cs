
namespace SpartaDungeon
{
    internal class ShopScene : DisplayGame
    {
        private List<Item> _items;

        public ShopScene(Character player)
        {
            buttons = new string[] { "StartScene", "ShopBuyScene", "ShopSellScene" };
            buttonsName = new string[] { "나가기", "아이템 구매", "아이템 판매" };
            this.player = player;
            _items = ItemData.allItemList;
            //_items.RemoveAt(0);
        }

        public override void DisplayTitle()
        {
            fontColorChange.WriteLine(ConsoleColor.Cyan, "\n상점");
            Console.WriteLine("\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
        }

        public override void DisplayMain()
        {
            Console.WriteLine($"\n[보유 골드]");
            fontColorChange.Write(ConsoleColor.Yellow, $"{player.Gold}");
            Console.WriteLine(" G");
            Console.WriteLine("\n[아이템 목록]\n");
            int x = 25;
            int y = 11;
            foreach (Item item in _items)
            {
                int count = 0;
                int oldY = y;
                Console.Write($"-  {item.Name}");
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
                if (player.Invertory.Contains(item))
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
                y += count;
                Console.SetCursorPosition(0, y);
            }
        }
    }
}
