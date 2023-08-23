﻿
namespace SpartaDungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ItemData itemData = new ItemData();
            StartScene startScene = new StartScene();
            List<Item> playerInventory = new List<Item> { itemData.GetItemFromCode("1"), itemData.GetItemFromCode("2") };
            List<Item> playerEquipped = new List<Item> { itemData.GetItemFromCode("1") };
            List<Dungeon> dungeons = new List<Dungeon>() { new Dungeon("쉬운 던전", 5, 1000),
                                                           new Dungeon("일반 던전", 11, 1700),
                                                           new Dungeon("어려운 던전", 17, 2500)
                                                          };
            Character player = new Character("Chad", "전사", 1, 10, 5, 100, 150000000, playerInventory, playerEquipped);
            StatusScene statusScene = new StatusScene(player);
            InventoryScene inventoryScene = new InventoryScene(player);
            InventoryManager inventoryManager = new InventoryManager(player);
            ShopScene shopScene = new ShopScene(player);
            ShopBuyScene shopBuyScene = new ShopBuyScene(player);
            ShopSellScene shopSellScene = new ShopSellScene(player);
            DungeonEntrance dungeonEntrance = new DungeonEntrance(player, dungeons);
            DungeonResult dungeonResult = new DungeonResult(player, dungeons);
            string sceneChoice = "StartScene";
            bool isGameOver = false;
            int dungeonSelectNum = -1;

            //JObject job2 = JObject.Parse(jsonString);

            //JArray jsonArray = new JArray() { job1, job2 };
            //File.WriteAllText($"{Directory.GetCurrentDirectory()}\\..\\..\\..\\ItemData.json", jsonArray.ToString());

            while (!isGameOver)
            {
                switch (sceneChoice)
                {
                    case "StartScene":
                        sceneChoice = startScene.Display();
                        break;
                    case "StatusScene":
                        sceneChoice = statusScene.Display();
                        break;
                    case "InventoryScene":
                        sceneChoice = inventoryScene.Display();
                        break;
                    case "InventoryManager":
                        sceneChoice = inventoryManager.Display();
                        break;
                    case "ShopScene":
                        sceneChoice = shopScene.Display();
                        break;
                    case "ShopBuyScene":
                        sceneChoice = shopBuyScene.Display();
                        break;
                    case "ShopSellScene":
                        sceneChoice = shopSellScene.Display();
                        break;
                    case "DungeonEntrance":
                        sceneChoice = dungeonEntrance.Display(out dungeonSelectNum);
                        break;
                    case "DungeonResult":
                        sceneChoice = dungeonResult.Display(dungeonSelectNum);
                        break;
                    case "Escape":
                        isGameOver = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}