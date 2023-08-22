
namespace SpartaDungeon
{
    internal class StatusScene : DisplayGame
    {
        private Character _player;
        public StatusScene(Character player)
        {
            buttons = new string[] { "StartScene" };
            buttonsName = new string[] { "나가기" };
            this._player = player;
        }

        public override void DisplayTitle()
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        }

        public override void DisplayMain()
        {
            int[] itemStats = new int[3];
            string[] itemStatsString = new string[3];

            _player.GetEquippedItemsStats(out itemStats[0], out itemStats[1], out itemStats[2]);

            for (int i = 0; i < itemStats.Length; i++) 
            {
                if (itemStats[i] > 0)
                {
                    itemStatsString[i] = $"(+{itemStats[i]})";
                }
                else if (itemStats[i] < 0)
                {
                    itemStatsString[i] = $"({itemStats[i]})";
                }
                else
                {
                    itemStatsString[i] = "";
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Lv. {_player.Level}");
            Console.WriteLine($"{_player.Name} ( {_player.Job} )");
            Console.WriteLine($"공격력 : {_player.Atk + itemStats[0]} {itemStatsString[0]}");
            Console.WriteLine($"방어력 : {_player.Def + itemStats[1]} {itemStatsString[1]}");
            Console.WriteLine($"체  력 : {_player.Hp + itemStats[2]} {itemStatsString[2]}");
            Console.WriteLine($"Gold   : {_player.Gold}");
        }
    }
}
