using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class StatusScene : DisplayGame
    {
        private Character player;
        public StatusScene(Character player)
        {
            buttons = new string[] { "StartScene" };
            buttonsName = new string[] { "나가기" };
            this.player = player;
        }

        public override void DisplayTitle()
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        }

        public override void DisplayMain()
        {
            Console.WriteLine();
            Console.WriteLine($"Lv. {player.Level}");
            Console.WriteLine($"{player.Name} ( {player.Job} )");
            Console.WriteLine($"공격력 : {player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체  력 : {player.Hp}");
            Console.WriteLine($"Gold   : {player.Gold}");
        }
    }
}
