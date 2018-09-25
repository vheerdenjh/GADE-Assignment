using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Assignment1
{
    class Map
    {
        private string display;
        private const int MAX_RANDOM_UNITS = 50;
        public const string FIELD_SYMBOL = ".";
        private string[,] map = new string[20, 20];
        private MeleeUnit[] mU = new MeleeUnit[20];
        private int numberofMeleeUnits;
        private RangedUnit[] rU = new RangedUnit[20];
        private int numberofRangedUnits;
        private List<Unit> unitsOnMap = new List<Unit>();
        private List<Building> buildings = new List<Building>();
        private int numberOfUnitsOnMap = 0;
        private string unitMove;

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

        public string initialiseMap()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    map[i, j] = ".";
                    display += map[i, j];
                }

                display += Environment.NewLine;
            }
            return display;
        }

        public void placeUnit(int x, int y, string unit)
        {
            map[x, y] = unit;
        }

        public void unitGenerator(string unitM = "M", string unitR = "R", string factory = "F")
        {
            Random rnd = new Random();
            numberofMeleeUnits = rnd.Next(10, 21);
            int x, y;
            for (int i = 0; i < numberofMeleeUnits; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                //mU[i] = new MeleeUnit(x, y, 10, -3, 1);
                placeUnit(x, y, unitM);
            }

            numberofRangedUnits = rnd.Next(10, 21);
            for (int i = 0; i < numberofRangedUnits; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                //rU[i] = new RangedUnit(x, y, 10, -2, 3);
                placeUnit(x, y, unitR);
            }

            for (int i = 0; i < 2; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                placeUnit(x, y, factory);
            }
        }

        public void update(Unit u, int newX, int newY)
        {
            if ((newX >= 0 && newX < 20) && (newY >= 0 && newY < 20))
            {
                //Unit(u, newX, newY);
                //u.move(newX, newY);
            }
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

        public List<Unit> Units
        {
            get { return unitsOnMap; }
        }

        public List<Building> Buildings
        {
            get { return buildings; }
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
                    Unit e = new Unit(x, y, health, speed, attack, attackRange, faction, symbol);
                    unitsOnMap.Add(e);
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
                    Building e = new Building(x, y, health, speed, attack, attackRange, faction, symbol);
                    Buildings.Add(e);
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
