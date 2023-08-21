using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    abstract class DisplayGame
    {
        public string[]? buttons;
        public string[]? buttonsName;

        public abstract void DisplayTitle();

        public abstract void DisplayMain();

        public void DisplayChoice()
        {
            Console.WriteLine();
            if (buttonsName != null && buttonsName.Length > 0)
            {
                for (int i = 0; i < buttonsName.Length; i++)
                {
                    Console.WriteLine($"{i}. {buttonsName[i]}");
                }
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
                Console.WriteLine("잘못된 입력입니다.");
            }
            return "NoChoice";
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
