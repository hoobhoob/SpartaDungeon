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
            Console.WriteLine();
            Console.WriteLine($"[아이템 목록]");
            Console.Write("- ");
            Console.WriteLine($"{player.Name} ( {player.Job} )");
            Console.WriteLine($"공격력 : {player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체  력 : {player.Hp}");
            Console.WriteLine($"Gold   : {player.Gold}");
        }
    }
}
