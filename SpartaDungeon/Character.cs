﻿
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
        public Item[] Invertory { get; }
        public Item[] EquippedItems { get; }
        public Character(string name, string job, int level, int atk, int def, int hp, int gold, Item[] inventory, Item[] equippedItems)
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
    }
}
