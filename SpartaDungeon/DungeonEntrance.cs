using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class DungeonEntrance : DisplayGame
    {
        private List<Dungeon> _dungeons;
        private int _dungeonSelectNum;

        public DungeonEntrance(Character player, List<Dungeon> dungeons)
        {
            buttons = new string[] { "StartScene" , "DungeonResult" };
            buttonsName = new string[] { "나가기" };
            this.player = player;
            _dungeons = dungeons;
            _dungeonSelectNum = -1;
        }

        public override void DisplayTitle()
        {
            fontColorChange.WriteLine(ConsoleColor.Cyan, "\n던전입장");
            Console.WriteLine("\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
        }

        public override void DisplayMain()
        {
            int x = 25;
            int y = 6;
            Console.WriteLine();
            for (int i = 0; i < _dungeons.Count; i++)
            {
                fontColorChange.Write(ConsoleColor.Magenta, $"{i + 1}");
                Console.Write($". {_dungeons[i].Name}");
                Console.SetCursorPosition(x , y);
                Console.Write($"| 방어력 ");
                fontColorChange.Write(ConsoleColor.Magenta, $"{_dungeons[i].DefCost}");
                Console.WriteLine(" 이상 권장");
                y++;
            }
        }

        public new string DIsplayReadNumber()
        {
            Console.WriteLine();
            player.GetEquippedItemsStats(out int titematk, out int itemdef, out int itemhp);
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
                    else if (number <= _dungeons.Count)
                    {
                        if (player.Hp + itemhp > 0)
                        {
                            _dungeonSelectNum = number - 1;
                            return buttons[1];
                        }
                        else
                        {
                            fontColorChange.BackgroundWriteLine(ConsoleColor.DarkRed, "\nHP가 0 이하라 던전 입장이 불가능합니다.");
                            Console.WriteLine();
                        }
                    }
                }
                fontColorChange.BackgroundWriteLine(ConsoleColor.DarkRed, "\n잘못된 입력입니다.");
                Console.WriteLine();
            }
            return "StartScene";
        }

        public string Display(out int dungeonSelectNum)
        {
            Console.Clear();
            DisplayTitle();
            DisplayMain();
            DisplayChoice();
            string displayReadNumberResult = DIsplayReadNumber();
            dungeonSelectNum = _dungeonSelectNum;
            return displayReadNumberResult;
        }
    }
}
