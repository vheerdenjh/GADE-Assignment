using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTSgame
{
    class HomeBuilding : Building
    {
        private int unitsProduce;
        private int tickProduce;
        private int x;
        private int y;

        public HomeBuilding(int x, int y, int health, string faction, string symbol)
           : base(x, y, health, faction, symbol)
        {
        }

        public override bool isStanding()
        {
            if (this.Health <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string toString()
        {
            string output = "x : " + X + Environment.NewLine
                + "y : " + Y + Environment.NewLine
                + "Health : " + Health + Environment.NewLine
                + "Faction : " + Faction + Environment.NewLine
                + "Symbol : " + Symbol + Environment.NewLine;
            return output;
        }

        public void factorySpawn(int tick)
        {
            int clock;
            clock = tick / 5;

            if ((clock % 1) > 0)
            {
                unitsProduce = unitsProduce + 1;
            }
        }
    }
}
