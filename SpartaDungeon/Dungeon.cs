using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class Dungeon
    {
        public string Name { get; }
        public int DefCost { get; }
        public int HPCost { get; }
        public int Reward { get; }

        public Dungeon(string name, int defCost, int reward)
        {
            Name = name;
            DefCost = defCost;
            HPCost = new Random().Next(20, 36);
            Reward = reward;
        }

        public bool IsClear(Character player)
        {
            player.GetEquippedItemsStats(out int itemAtk, out int itemDef, out int itemHP);
            int totalAtk = player.Atk + itemAtk;
            int totalDef = player.Def + itemDef;
            int totalHP = player.Hp + itemHP;
            Random rand = new Random();
            int clearPercentage = rand.Next(0, 101);
            int rewardPercentage = rand.Next(totalAtk, totalAtk * 2 + 1) + 100;
            if (totalDef < HPCost && clearPercentage <= 40)
            {
                player.Hp /= 2;
                return false;
            }
            else
            {
                int totalHpCost = HPCost + DefCost - totalDef;
                if (totalHpCost > 0)
                {
                    player.Hp -= totalHpCost;
                }
                player.Gold += Reward * rewardPercentage / 100;

                player.DungeonClearCount++;
                int totalCount = 0;
                for (int i = 1; i <= player.Level; i++)
                {
                    totalCount += i;
                }
                if (player.DungeonClearCount >= totalCount)
                {
                    player.LevelUp();
                }
                return true;
            }
        }
    }
}
