using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTSgame
{
    class ResourceBuilding : Building
    {
        private string resourceType;
        private int resourceTick = 1;
        private int resourceTotal = -1;

        public ResourceBuilding(int x, int y, int health, string faction, string symbol)
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

        private void Resources()
        {
            Random gen = new Random();

            if(resourceTotal == -1)
            {
                resourceTotal = gen.Next(10, 20);
            }

            else
            {
                resourceTotal = resourceTotal + resourceTick;
            }
        }
    }
}
