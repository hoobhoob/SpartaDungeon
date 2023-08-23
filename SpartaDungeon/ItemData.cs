using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Numerics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace SpartaDungeon
{
    public struct Item
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Type { get; set; }
        public ItemStats Stats { get; set; }

        public int Price()
        {
            return Stats.Atk * 200 + Stats.Def * 200 + Stats.HP * 20;
        }

        public override string ToString()
        {
            string jsonString = JsonConvert.SerializeObject(this);
            return jsonString;
        }
    }
    public struct ItemStats
    {
        public int Atk { get; set; }
        public int Def { get; set; }
        public int HP { get; set; }

    }

    internal class ItemData
    {
        public static List<Item> allItemList;

        public ItemData()
        {
            string jsonString = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\..\\..\\..\\ItemData.json");
            allItemList = JsonConvert.DeserializeObject<List<Item>>(jsonString);
        }

        public Item GetItemFromCode(String code)
        {
            foreach(Item item in allItemList)
            {
                if (item.Code == code)
                    return item;
            }
            return new Item();
        }
    }
}
