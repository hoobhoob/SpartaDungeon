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
        private Character _player;

        public InventoryScene(Character player)
        {
            buttons = new string[] { "StartScene", "InventoryManager" };
            buttonsName = new string[] { "나가기", "장착 관리" };
            this._player = player;
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
            foreach (Item item in _player.EquippedItems)
            {
                int count = 0;
                Console.Write($"- [E] {item.Name}");
                Console.SetCursorPosition(40, y);
                Console.Write($" | {item.Info}");
                if (item.Stats.Atk != 0)
                {
                    Console.SetCursorPosition(20, y);
                    Console.WriteLine($" | 공격력 {item.Stats.Atk.ToString("+#;-#")}");
                    count++;
                }
                if (item.Stats.Def != 0)
                {
                    Console.SetCursorPosition(20, y + count);
                    Console.WriteLine($" | 방어력 {item.Stats.Def.ToString("+#;-#")}");
                    count++;
                }
                if (item.Stats.HP != 0)
                {
                    Console.SetCursorPosition(20, y + count);
                    Console.WriteLine($" | 체  력 {item.Stats.HP.ToString("+#;-#")}");
                    count++;
                }
                if (item.Stats.Atk == 0 && item.Stats.Def == 0 && item.Stats.HP == 0)
                {
                    Console.SetCursorPosition(20, y);
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
                    Console.SetCursorPosition(40, y);
                    Console.Write($" | {item.Info}");
                    if (item.Stats.Atk != 0)
                    {
                        Console.SetCursorPosition(20, y);
                        Console.WriteLine($" | 공격력 {item.Stats.Atk.ToString("+#;-#")}");
                        count++;
                    }
                    if (item.Stats.Def != 0)
                    {
                        Console.SetCursorPosition(20, y + count);
                        Console.WriteLine($" | 방어력 {item.Stats.Def.ToString("+#;-#")}");
                        count++;
                    }
                    if (item.Stats.HP != 0)
                    {
                        Console.SetCursorPosition(20, y + count);
                        Console.WriteLine($" | 체  력 {item.Stats.HP.ToString("+#;-#")}");
                        count++;
                    }
                    if(item.Stats.Atk == 0 && item.Stats.Def == 0 && item.Stats.HP == 0)
                    {
                        Console.SetCursorPosition(20, y);
                        Console.WriteLine(" | ");
                    }
                    y += count;
                }
            }
        }
    }
}
