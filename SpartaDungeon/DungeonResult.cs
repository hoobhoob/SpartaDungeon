
namespace SpartaDungeon
{
    internal class DungeonResult : DisplayGame
    {
        private List<Dungeon> _dungeons;
        private int _playerOldLevel;
        private int _playerOldHP;
        private int _playerOldGold;
        private int _dungeonSelectNum;
        private bool _isClear;
        public DungeonResult(Character player, List<Dungeon> dungeons)
        {
            buttons = new string[] { "DungeonEntrance" };
            buttonsName = new string[] { "나가기" };
            this.player = player;
            _dungeons = dungeons;
            _playerOldLevel = player.Level;
            _playerOldHP = player.Hp;
            _playerOldGold = player.Gold;
            _dungeonSelectNum = -1;
            _isClear = false;
        }

        public override void DisplayTitle()
        {
            fontColorChange.Write(ConsoleColor.Cyan, "\n던전 ");
            if (_isClear )
            {
                fontColorChange.WriteLine(ConsoleColor.Green, "클리어");
                Console.WriteLine("\n축하합니다!!");
                fontColorChange.Write(ConsoleColor.Yellow, $"{_dungeons[_dungeonSelectNum].Name}");
                Console.WriteLine("을 클리어 하셨습니다.\n");
            }
            else
            {
                fontColorChange.WriteLine(ConsoleColor.Red, "실패");
                Console.WriteLine("\n\n\n");
            }
        }

        public override void DisplayMain()
        {
            Console.WriteLine("\n[탐험 결과]\n");
            Console.Write("체력 : ");
            fontColorChange.Write(ConsoleColor.Magenta, $"{_playerOldHP}");
            Console.Write(" -> ");
            fontColorChange.WriteLine(ConsoleColor.Red, $"{player.Hp}");
            Console.Write("Gold : ");
            fontColorChange.Write(ConsoleColor.Yellow, $"{_playerOldGold}");
            Console.Write(" -> ");
            fontColorChange.WriteLine(ConsoleColor.Green, $"{player.Gold}");
            if (_playerOldLevel != player.Level)
            {
                Console.Write("Level : ");
                fontColorChange.Write(ConsoleColor.Cyan, $"{_playerOldLevel}");
                Console.Write(" -> ");
                fontColorChange.WriteLine(ConsoleColor.Green, $"{player.Level}");
            }
        }

        public string Display(int dungeonSelectNum)
        {
            _dungeonSelectNum = dungeonSelectNum;
            _playerOldLevel = player.Level;
            _playerOldHP = player.Hp;
            _playerOldGold = player.Gold;
            _isClear = _dungeons[_dungeonSelectNum].IsClear(player);
            Console.Clear();
            DisplayTitle();
            DisplayMain();
            DisplayChoice();
            return DIsplayReadNumber();
        }
    }
}
