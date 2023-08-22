
namespace SpartaDungeon
{
    internal class StartScene : DisplayGame
    {

        public StartScene()
        {
            buttons = new string[] { "Escape", "StatusScene", "InventoryScene", "ShopScene", "DungeonEntrance" };
            buttonsName = new string[] { "나가기", "상태 보기", "인벤토리", "상점", "던전입장" };
        }

        public override void DisplayTitle()
        {
            fontColorChange.Write(ConsoleColor.Cyan, "\n스파르타 마을");
            Console.WriteLine("에 오신 여러분 환영합니다.");
            Console.WriteLine("\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
        }

        public override void DisplayMain()
        {
            Console.WriteLine();
        }


    }
}
