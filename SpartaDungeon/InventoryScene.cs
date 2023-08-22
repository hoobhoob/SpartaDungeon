using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class InventoryScene : DisplayGame
    {
        private Character player;

        public InventoryScene(Character player)
        {
            buttons = new string[] { "StartScene", "InventoryManager" };
            buttonsName = new string[] { "나가기", "장착 관리"};
            this.player = player;
        }

        public override void DisplayTitle()
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        }

        public override void DisplayMain()
        {
            Console.WriteLine($"\n[아이템 목록]\n");
            int y = 5;
            foreach (Item item in player.EquippedItems)
            {
                Console.Write($"- [E] {item.Name}");
                Console.SetCursorPosition(20, y);
                Console.Write(" | " + item.Stats.ToString());
                Console.SetCursorPosition(50, y);
                Console.WriteLine(" | " + item.Info);
                y++;

            }
            foreach (Item item in player.Invertory)
            {
                if (!player.EquippedItems.Contains(item))
                {
                    Console.Write($"-     {item.Name}");
                    Console.SetCursorPosition(20, y);
                    Console.Write(" | " + item.Stats.ToString());
                    Console.SetCursorPosition(50, y);
                    Console.WriteLine(" | " + item.Info);
                    y++;
                    //int oldY= y;
                    //Console.Write($"-     {item.Name}");
                    //Console.SetCursorPosition(20, y);
                    //if
                    //{

                    //}
                    //Console.SetCursorPosition(50, oldY);
                    //Console.Write(" | " + item.Info);

                }
            }
        }
    }
}
