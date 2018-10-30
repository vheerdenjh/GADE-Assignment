using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTSgame
{
    class JetpackUnit : Unit
    {
        private const int DAMAGE = 2;

        public JetpackUnit(int
            x, int y, int health, int speed, int attack, int attackRange, string faction, string symbol)
            : base(x, y, health, speed, attack, attackRange, faction, symbol)
        {

        }

        public override void move(int x, int y)
        {
            if (x >= 0 || x < 20)
            {
                X = x;
            }

            if (y >= 20 || y < 20)
            {
                Y = y;
            }
        }

        public override void combat(Unit enemy)
        {
            if (this.isWithinAttackRange(enemy))
            {
                enemy.Health -= DAMAGE;
            }
        }

        public override bool isWithinAttackRange(Unit enemy)
        {
            if (!this.Faction.Equals(enemy.Faction))
            {
                if ((Math.Abs(this.X - enemy.X) <= this.AttackRange) && (Math.Abs(this.Y - enemy.Y) <= this.AttackRange))
                {
                    return true;
                }

            }
            return false;

        }

        public override Unit nearestUnit(List<Unit> list)
        {
            Unit closest = null;
            int attackRangeX, attackRangeY;
            double range;
            int shortestRange = 2;

            foreach (Unit u in list)
            {
                attackRangeX = Math.Abs(this.X - u.X);
                attackRangeY = Math.Abs(this.Y = u.Y);

                range = Math.Sqrt(Math.Pow(attackRangeX, 2) + Math.Pow(attackRangeY, 2));

                if (attackRangeX < shortestRange)
                {
                    shortestRange = attackRangeX;
                    closest = u;
                }
                if (attackRangeY < shortestRange)
                {
                    shortestRange = attackRangeY;
                    closest = u;
                }
            }
            return closest;
        }

        public override bool isAlive()
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
                + "Speed : " + Speed + Environment.NewLine
                + "Attack : " + Attack + Environment.NewLine
                // + "Attack Range : " + (Attack ? "Yes" : "No") + Environment.NewLine
                + "Faction : " + Faction + Environment.NewLine
                + "Symbol : " + Symbol + Environment.NewLine;
            return output;
        }
    }
}
