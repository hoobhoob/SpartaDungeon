using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class DungeonEntrance : DisplayGame
    {
        public DungeonEntrance(Character player)
        {
            buttons = new string[] { "StartScene" };
            buttonsName = new string[] { "나가기" };
            this.player = player;
        }

        public override void DisplayTitle()
        {
            throw new NotImplementedException();
        }

        public override void DisplayMain()
        {
            throw new NotImplementedException();
        }
    }
}
