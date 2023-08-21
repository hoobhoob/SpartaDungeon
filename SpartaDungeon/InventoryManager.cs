using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class InventoryManager : DisplayGame
    {
        private Character player;
        private List<string> _equipItems;

        public InventoryManager(Character player)
        {
            buttons = new string[] { "InventoryScene" , "InventoryManager" };
            buttonsName = new string[] { "나가기" };
            this.player = player;
            _equipItems = new List<string>();
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
            foreach (Item item in player.EquippedItems)
            {
                Console.WriteLine($"- {i,2} [E] {item.Name,-15} | {item.Stats.ToString(),-30} | {item.Info}");
                i++;
                _equipItems.Add(item.Code);
            }
            foreach (Item item in player.Invertory)
            {
                if (!player.EquippedItems.Contains(item))
                {
                    Console.WriteLine($"- {i,2}    {item.Name,-15} | {item.Stats.ToString(),-30} | {item.Info}");
                    i++;
                    _equipItems.Add(item.Code);
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
                    //if (number >= 0 && number < buttons.Length)
                    //{
                    //    return buttons[number];
                    //}
                    if (number == 0)
                    {
                        return buttons[0];
                    }
                    else if (number <= _equipItems.Count)
                    {

                        return buttons[1];
                    }
                }
                Console.WriteLine("잘못된 입력입니다.");
            }
            return "NoChoice";
        }
    }
}
