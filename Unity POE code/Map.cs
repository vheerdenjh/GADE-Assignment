using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace RTSgame
{
    class Map
    {

        private string display;
        private const int MAX_RANDOM_UNITS = 50;
        public const string FIELD_SYMBOL = ".";
        private string[,] map = new string[20, 20];
        private MeleeUnit[] mU = new MeleeUnit[20];
        private int numberofBuildings = 1;
        private int numberOfUnitsOnMap;
        private RangedUnit[] rU = new RangedUnit[20];        
        public List<Unit> unitsOnMap = new List<Unit>();
        private List<Building> buildingsOnMap = new List<Building>();
        private string unitMove;

        public IEnumerable<Unit>UnitsOnMap
        {
            get;
            internal set;
        }

        public string redraw()
        {
            display = "";
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    display += map[i, j] + "";
                }
                display += Environment.NewLine;
            }
            return display;
        }

        public void placeUnit(int x, int y, string unit)
        {
            map[x, y] = unit;
        }

        public string mapGenerate()
        {
            Random rnd = new Random();
            int x, y;

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    map[i, j] = ".";
                }
            }

            numberOfUnitsOnMap = rnd.Next(10, 21);
            for (int i = 0; i < numberOfUnitsOnMap; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                unitsOnMap.Add(new RangedUnit(x, y, 10, 1, 1, 2, "Blue", "R"));
                map[x, y] = "R";
            }

            numberOfUnitsOnMap = rnd.Next(10, 21);
            for (int i = 0; i < numberOfUnitsOnMap; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                unitsOnMap.Add(new MeleeUnit(x, y, 10, 1, 2, 1, "Blue", "M"));
                map[x, y] = "M";
            }

            numberOfUnitsOnMap = rnd.Next(2, 6);
            for (int i = 0; i < numberOfUnitsOnMap; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                unitsOnMap.Add(new BruteUnit(x, y, 15, 1, 4, 1, "Blue", "B"));
                map[x, y] = "B";
            }

            numberOfUnitsOnMap = rnd.Next(2, 6);
            for (int i = 0; i < numberOfUnitsOnMap; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                unitsOnMap.Add(new JetpackUnit(x, y, 10, 1, 4, 1, "Blue", "J"));
                map[x, y] = "J";
            }

            numberofBuildings = rnd.Next(1, 3);
            for (int i = 0; i < numberofBuildings; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                buildingsOnMap.Add(new ResourceBuilding(x, y, 20, "Blue", "B"));
                map[x, y] = "B";
            }

            numberofBuildings = rnd.Next(1, 3);
            for (int i = 0; i < numberofBuildings; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                buildingsOnMap.Add(new FactoryBuilding(x, y, 20, "Blue", "F"));
                map[x, y] = "F";
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    display = map[j, i];
                }

                display += Environment.NewLine;
            }

            numberOfUnitsOnMap = rnd.Next(10, 21);
            for (int i = 0; i < numberOfUnitsOnMap; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                unitsOnMap.Add(new RangedUnit(x, y, 10, 1, 1, 2, "Red", "R"));
                map[x, y] = "R";
            }

            numberOfUnitsOnMap = rnd.Next(10, 21);
            for (int i = 0; i < numberOfUnitsOnMap; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                unitsOnMap.Add(new MeleeUnit(x, y, 10, 2, 1, 1, "Red", "M"));
                map[x, y] = "M";
            }

            numberOfUnitsOnMap = rnd.Next(2, 6);
            for (int i = 0; i < numberOfUnitsOnMap; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                unitsOnMap.Add(new BruteUnit(x, y, 15, 1, 4, 1, "Red", "B"));
                map[x, y] = "B";
            }

            numberOfUnitsOnMap = rnd.Next(2, 6);
            for (int i = 0; i < numberOfUnitsOnMap; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                unitsOnMap.Add(new JetpackUnit(x, y, 15, 1, 4, 1, "Red", "J"));
                map[x, y] = "J";
            }

            numberofBuildings = rnd.Next(1, 3);
            for (int i = 0; i < numberofBuildings; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                buildingsOnMap.Add(new ResourceBuilding(x, y, 20, "Red", "B"));
                map[x, y] = "B";
            }

            numberofBuildings = rnd.Next(1, 3);
            for (int i = 0; i < numberofBuildings; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                buildingsOnMap.Add(new FactoryBuilding(x, y, 20, "Red", "F"));
                map[x, y] = "F";
            }

            return display;
        }

        public void move(Unit u, Unit closestEnemy)
        {
            int newX = u.X;
            int newY = u.Y;

            if (closestEnemy.X - newX > u.X)
            {
                newX += 1;
                update(u, newX, newY);
                u.move(newX, newY);
            }
            else if (closestEnemy.X - newX < u.X)
            {
                newX -= 1;
                update(u, newX, newY);
                u.move(newX, newY);
            }
            if (closestEnemy.Y - newX > u.Y)
            {
                newY += 1;
                update(u, newX, newY);
                u.move(newX, newY);
            }
            else if (closestEnemy.Y - newX < u.Y)
            {
                newY -= 1;
                update(u, newX, newY);
                u.move(newX, newY);
            }
            if (newX < 20 && newX >= 0 && newY < 20 && newY >= 0)
            {
                if (map[newX, newY].Equals("."))
                {
                    update(u, newX, newY);
                    u.move(newX, newY);
                }
            }

            update(u, newX, newY);
            u.move(newX, newY);
        }

        public void update(Unit u, int newX, int newY)
        {

            map[u.X, u.Y] = ".";
            map[newX, newY] = u.Symbol;
        }

        public void checkHealth()
        {
            for (int i = 0; i < numberOfUnitsOnMap; i++)
            {
                if (!unitsOnMap[i].isAlive())
                {
                    map[unitsOnMap[i].X, unitsOnMap[i].Y] = FIELD_SYMBOL;
                    unitsOnMap.RemoveAt(i);
                    numberOfUnitsOnMap--;
                }
            }
        }

        public void update(Unit uRange)
        {

        }

        public string[,] field
        {
            get { return map; }
            set { map = value; }
        }

        public List<Unit> health
        {
            get { return health; }
        }

        public List<Unit> Units
        {
            get { return unitsOnMap; }
        }

        public List<Building> Buildings
        {
            get { return buildingsOnMap; }
        }

        public void loadUnits()
        {
            FileStream inFile = null;
            StreamReader reader = null;
            string input;
            int Unit;
            int x;
            int y;
            int health;
            int speed;
            bool attack;
            int attackRange;
            string faction;
            string symbol;

            try
            {
                inFile = new FileStream(@"Units.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                input = reader.ReadLine();
                while (input != null)
                {
                    Unit = int.Parse(input);
                    faction = reader.ReadLine();
                    //Unit e = new Unit(x, y, health, speed, attack, attackRange, faction, symbol);
                    //unitsOnMap.Add(e);
                    input = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }
            finally
            {
                if (inFile != null)
                {
                    reader.Close();
                    inFile.Close();
                }
            }
        }

        public void loadBuildings()
        {
            FileStream inFile = null;
            StreamReader reader = null;
            string input;
            int Unit;
            int x;
            int y;
            int health;
            int speed;
            bool attack;
            int attackRange;
            string faction;
            string symbol;

            try
            {
                inFile = new FileStream(@"Buildings.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                input = reader.ReadLine();
                while (input != null)
                {
                    Unit = int.Parse(input);
                    faction = reader.ReadLine();
                    //Building e = new Building(x, y, health, speed, attack, attackRange, faction, symbol);
                    //Buildings.Add(e);
                    input = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }
            finally
            {
                if (inFile != null)
                {
                    reader.Close();
                    inFile.Close();
                }
            }
        }
    }
}
