using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpartaDungeon
{
    public struct Item
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Type { get; set; }
        public ItemStats Stats { get; set; }

        public override string ToString()
        {
            var options = new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All), WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(this, options);
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

        public static JArray? jsonItemArray;

        public ItemData()
        {
            jsonItemArray = JArray.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}\\..\\..\\..\\ItemData.json"));
        }

        public Item GetItemFromCode(String code)
        {
            Item item = new Item();
            foreach (JObject itemData in jsonItemArray)
            {
                string codeInJson = itemData["Code"].ToString();
                if (codeInJson == code)
                {
                    item.Code = itemData["Code"].ToString();
                    item.Name = itemData["Name"].ToString();
                    item.Info = itemData["Info"].ToString();
                    item.Stats = new ItemStats() { Atk = (int)itemData["Stats"]["Atk"], Def = (int)itemData["Stats"]["Def"], HP = (int)itemData["Stats"]["HP"] };
                    break;
                }
            }
            return item;
        }
    }
}
