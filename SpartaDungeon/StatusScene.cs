
namespace SpartaDungeon
{
    internal class StatusScene : DisplayGame
    {
        public StatusScene(Character player)
        {
            buttons = new string[] { "StartScene" };
            buttonsName = new string[] { "나가기" };
            this.player = player;
        }

        public override void DisplayTitle()
        {
            fontColorChange.WriteLine(ConsoleColor.Cyan, "\n상태 보기");
            Console.WriteLine("\n캐릭터의 정보가 표시됩니다.\n");
        }

        public override void DisplayMain()
        {
            int[] itemStats = new int[3];
            string[] itemStatsString = new string[3];

            player.GetEquippedItemsStats(out itemStats[0], out itemStats[1], out itemStats[2]);

            Console.WriteLine();
            Console.Write("Lv. ");
            fontColorChange.WriteLine(ConsoleColor.Green, $"{player.Level}");
            Console.WriteLine($"{player.Name} ( {player.Job} )");
            if (itemStats[0] != 0)
            {
                Console.Write("공격력 : ");
                fontColorChange.Write(ConsoleColor.Magenta, $"{player.Atk + itemStats[0]} ");
                Console.Write("(");
                fontColorChange.Write(ConsoleColor.Magenta, itemStats[0].ToString("+#; -#"));
                Console.WriteLine(")");
            }
            else
            {
                Console.WriteLine($"공격력 : {player.Atk}");
            }
            if (itemStats[1] != 0)
            {
                Console.Write("방어력 : ");
                fontColorChange.Write(ConsoleColor.Magenta, $"{player.Def + itemStats[1]} ");
                Console.Write("(");
                fontColorChange.Write(ConsoleColor.Magenta, itemStats[1].ToString("+#; -#"));
                Console.WriteLine(")");
            }
            else
            {
                Console.WriteLine($"방어력 : {player.Def}");
            }
            if (itemStats[2] != 0)
            {
                Console.Write("체  력 : ");
                fontColorChange.Write(ConsoleColor.Magenta, $"{player.Hp + itemStats[2]} ");
                Console.Write("(");
                fontColorChange.Write(ConsoleColor.Magenta, itemStats[2].ToString("+#; -#"));
                Console.WriteLine(")");
            }
            else
            {
                Console.WriteLine($"체  력 : {player.Hp}");
            }
            Console.Write("Gold   : ");
            fontColorChange.Write(ConsoleColor.Yellow, $"{player.Gold}");
            Console.WriteLine(" G");
        }
    }
}
