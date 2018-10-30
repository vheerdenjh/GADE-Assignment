using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace RTSgame
{
    abstract class Unit
    {
        private int x;
        private int y;
        public int health;
        private int speed;
        private int attack;
        private int attackRange;
        private string faction;
        private string symbol;
        private string nameField;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y 
        {
            get { return y; }
            set { y = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        public int AttackRange
        {
            get { return attackRange; }
            set { attackRange = value; }
        }
        public string Faction
        {
            get { return faction; }
            set { faction = value; }
        }
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public Unit(int x, int y, int health, int speed, int attack, int attackRange, string faction, string symbol)
        {

            this.x = x;
            this.y = y;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.faction = faction;
            this.symbol = symbol;

        }

        public void save()
        {
            FileStream outFile = null;
            StreamWriter writer = null;
            try
            {
                outFile = new FileStream(@"Units.txt", FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(outFile);

                writer.WriteLine(x);
                writer.WriteLine(y);
                writer.WriteLine(health);
                writer.WriteLine(speed);
                writer.WriteLine(attack);
                writer.WriteLine(attackRange);
                writer.WriteLine(faction);
                writer.WriteLine(symbol);

                writer.Close();
                outFile.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }
            finally
            {
                if (outFile != null)
                {
                    outFile.Close();
                    writer.Close();
                }
            }
        }

        ~Unit()
        {
        }
        
        public abstract void move(int x, int y);
        public abstract void combat(Unit enemy);
        public abstract bool isWithinAttackRange(Unit enemy);
        public abstract Unit nearestUnit(List<Unit> u);
        public abstract bool isAlive();
        public abstract string toString();
    }
}
