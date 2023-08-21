using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class StartScene : DisplayGame
    {

        public StartScene()
        {
            buttons = new string[] { "Escape", "StatusScene", "InventoryScene" };
            buttonsName = new string[] { "나가기", "상태 보기", "인벤토리" };
        }

        public override void DisplayTitle()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
        }

        public override void DisplayMain()
        {
            Console.WriteLine();
        }


    }
}
