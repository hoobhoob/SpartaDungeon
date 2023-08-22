
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace SpartaDungeon
{
    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }
        public List<Item> Invertory { get; }
        public List<Item> EquippedItems { get; }
        public Character(string name, string job, int level, int atk, int def, int hp, int gold, List<Item> inventory, List<Item> equippedItems)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
            Invertory = inventory;
            EquippedItems = equippedItems;
        }

        public void EquipItem(Item item)
        {
            if (!Invertory.Contains(item))
            {
                Invertory.Add(item);
                EquippedItems.Add(item);
            }
            else
            {
                if(!EquippedItems.Contains(item))
                {
                    for (int i = 0;  i < EquippedItems.Count; i++)
                    {
                        if (EquippedItems[i].Type == item.Type)
                        {
                            UnEquipItem(EquippedItems[i]);
                            break;
                        }
                    }
                    EquippedItems.Add(item);
                }
                else
                {
                    UnEquipItem(item);
                }
            }
        }

        public void UnEquipItem(Item item)
        {
            if(EquippedItems.Contains(item))
            {
                EquippedItems.Remove(item);
            }
        }

        public void GetEquippedItemsStats(out int totalatk, out int totaldef, out int totalhp)
        {
            totalatk = 0;
            totaldef = 0;
            totalhp = 0;
            foreach(Item item in EquippedItems)
            {
                totalatk += item.Stats.Atk;
                totaldef += item.Stats.Def;
                totalhp += item.Stats.HP;
            }
        }
    }
}
