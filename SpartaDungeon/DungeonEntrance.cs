using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class DungeonEntrance : DisplayGame
    {
        private List<Dungeon> dungeons;

        public DungeonEntrance(Character player)
        {
            buttons = new string[] { "StartScene" };
            buttonsName = new string[] { "나가기" };
            this.player = player;
            dungeons = new List<Dungeon>() { new Dungeon("쉬운 던전", 5, 1000),
                                            new Dungeon("일반 던전", 11, 1700),
                                            new Dungeon("어려운 던전", 17, 2500)
                                            };
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
            for (int i = 0; i < dungeons.Count; i++)
            {
                fontColorChange.Write(ConsoleColor.Magenta, $"{i + 1}");
                Console.Write($". {dungeons[i].Name}");
                Console.SetCursorPosition(x , y);
                Console.Write($"| 방어력 ");
                fontColorChange.Write(ConsoleColor.Magenta, $"{dungeons[i].DefCost}");
                Console.WriteLine(" 이상 권장");
                y++;
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
                    else if (number <= dungeons.Count)
                    {
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
