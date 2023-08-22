using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class InventoryManager : DisplayGame
    {
        private Character _player;
        private List<Item> _equipItems;

        public InventoryManager(Character player)
        {
            buttons = new string[] { "InventoryScene" , "InventoryManager" };
            buttonsName = new string[] { "나가기" };
            this._player = player;
            _equipItems = new List<Item>();
        }

        public override void DisplayTitle()
        {
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        }

        public override void DisplayMain()
        {
            Console.WriteLine($"\n[아이템 목록]\n");
            int i = 1;
            int y = 5;
            _equipItems.Clear();
            foreach (Item item in _player.EquippedItems)
            {
                int count = 0;
                Console.Write($"- {i,2} [E] {item.Name}");
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
                i++;
                _equipItems.Add(item);
            }
            foreach (Item item in _player.Invertory)
            {
                if (!_player.EquippedItems.Contains(item))
                {
                    int count = 0;
                    Console.Write($"- {i,2}     {item.Name}");
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
                        _player.EquipItem(_equipItems[number - 1]);
                        return buttons[1];
                    }
                }
                Console.WriteLine("잘못된 입력입니다.");
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
