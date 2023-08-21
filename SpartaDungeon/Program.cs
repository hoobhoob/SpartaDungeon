using Newtonsoft.Json.Linq;
using System;
using System.Text.Json;

namespace SpartaDungeon
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ItemData itemData = new ItemData();
            StartScene startScene = new StartScene();
            Item[] playerInventory = new Item[] { itemData.GetItemFromCode("1"), itemData.GetItemFromCode("2") };
            Item[] playerEquipped = new Item[] { itemData.GetItemFromCode("1") };
            Character player = new Character("Chad", "전사", 1, 10, 5, 100, 1500, playerInventory, playerEquipped);
            StatusScene statusScene = new StatusScene(player);
            InventoryScene inventoryScene = new InventoryScene(player);
            string sceneChoice = "StartScene";
            bool isGameOver = false;

            Console.WriteLine(itemData.GetItemFromCode("1").ToString());


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