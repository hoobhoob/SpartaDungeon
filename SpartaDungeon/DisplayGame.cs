using System;

namespace SpartaDungeon
{
    abstract class DisplayGame
    {
        public string[]? buttons;
        public string[]? buttonsName;
        protected FontColorChange fontColorChange = new FontColorChange();
        protected Character player;

        public abstract void DisplayTitle();

        public abstract void DisplayMain();

        public void DisplayChoice()
        {
            Console.WriteLine();
            if (buttonsName != null && buttonsName.Length > 0)
            {
                for (int i = 1; i < buttonsName.Length; i++)
                {
                    fontColorChange.Write(ConsoleColor.Magenta, $"{i}");
                    Console.WriteLine($". {buttonsName[i]}");
                }
                fontColorChange.Write(ConsoleColor.Magenta, $"0");
                Console.WriteLine($". {buttonsName[0]}");
            }
            else
            {
                Console.WriteLine("선택지가 없다.");
            }
        }

        public string DIsplayReadNumber()
        {
            Console.WriteLine();
            while (buttons != null)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>  ");
                string? choice = Console.ReadLine();
                if (choice != null && int.TryParse(choice, out int number))
                {
                    if (number >= 0 && number < buttons.Length)
                    {
                        return buttons[number];
                    }
                }
                fontColorChange.BackgroundWriteLine(ConsoleColor.DarkRed, "\n잘못된 입력입니다.");
                Console.WriteLine();
            }
            return "StartScene";
        }

        public string Display()
        {
            Console.Clear();
            DisplayTitle();
            DisplayMain();
            DisplayChoice();
            return DIsplayReadNumber();
        }
        
    }
}
