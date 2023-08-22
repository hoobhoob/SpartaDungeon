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
    }
}
