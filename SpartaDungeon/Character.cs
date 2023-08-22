
namespace SpartaDungeon
{
    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }
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

        public void BuyItem(Item item)
        {
            if (!Invertory.Contains(item))
            {
                Invertory.Add(item);
                Gold -= item.Price();
            }
        }

        public void SellItem(Item item, int gold)
        {
            if (Invertory.Contains(item))
            {
                if (EquippedItems.Contains(item))
                {
                    EquippedItems.Remove(item);
                }
                Invertory.Remove(item);
                Gold += gold;
            }
        }

        public void LevelUp()
        {
            Level++;
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
