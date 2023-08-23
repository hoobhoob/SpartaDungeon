using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class RestScene : DisplayGame
    {
        private int _restGold;

        public RestScene(Character player)
        {
            buttons = new string[] { "StartScene" , "RestScene" };
            buttonsName = new string[] { "나가기" , "휴식하기"};
            this.player = player;
            _restGold = 500;
        }

        public override void DisplayTitle()
        {
            fontColorChange.WriteLine(ConsoleColor.Cyan, "\n휴식하기");
            fontColorChange.Write(ConsoleColor.Magenta, $"\n{_restGold}");
            Console.Write(" G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : ");
            if (player.Gold >= _restGold)
            {
                fontColorChange.Write(ConsoleColor.Green, $"{player.Gold}");
            }
            else
            {
                fontColorChange.Write(ConsoleColor.Red, $"{player.Gold}");
            }
            Console.WriteLine(" G)\n");
        }

        public override void DisplayMain()
        {
            Console.WriteLine("");
        }

        public new string DIsplayReadNumber()
        {
            Console.WriteLine();
            while (buttons != null)
            {
                int msgNumber = 0;
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>  ");
                string? choice = Console.ReadLine();
                if (choice != null && int.TryParse(choice, out int number))
                {
                    if (number == 0)
                    {
                        return buttons[number];
                    }
                    else
                    {
                        if (player.Gold >= _restGold)
                        {
                            msgNumber = 1;
                            player.Gold -= _restGold;
                            player.Hp = 100;
                        }
                        else
                        {
                            msgNumber = 2;
                        }
                    }
                }
                switch (msgNumber)
                {
                    case 0:
                        fontColorChange.BackgroundWriteLine(ConsoleColor.DarkRed, "\n잘못된 입력입니다.");
                        Console.WriteLine();
                        break;
                    case 1:
                        fontColorChange.BackgroundWriteLine(ConsoleColor.DarkGreen, "\n휴식을 완료했습니다.");
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
