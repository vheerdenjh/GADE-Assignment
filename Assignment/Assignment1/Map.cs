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
        private int numberofRangedUnits;
        private int numberofRBuildings;
        private int numberofFBuildings;
        private int numberofHBuilding;
        private int numberofJetpackUnits;
        private int numberofBruteUnits;
        private int numberOfUnitsOnMap = 0;
        private RangedUnit[] rU = new RangedUnit[20];        
        private List<Unit> unitsOnMap = new List<Unit>();
        private List<Building> buildingsOnMap = new List<Building>();
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
           
            numberofRangedUnits = rnd.Next(10, 21);
            for (int i = 0; i < numberofRangedUnits; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                unitsOnMap.Add(new RangedUnit(x, y, 10, 2, 1, 2, "R", "R"));
                map[x, y] = "R";
            }

            numberofMeleeUnits = rnd.Next(10, 21);
            for (int i = 0; i < numberofMeleeUnits; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                unitsOnMap.Add(new MeleeUnit(x, y, 10, 2, 2, 1, "M", "M"));
                map[x, y] = "M";
            }

            numberofBruteUnits = rnd.Next(2, 6);
            for (int i = 0; i < numberofBruteUnits; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                unitsOnMap.Add(new BruteUnit(x, y, 15, 1, 4, 1, "B", "B"));
                map[x, y] = "B";
            }

            numberofJetpackUnits = rnd.Next(2, 6);
            for (int i = 0; i < numberofJetpackUnits; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                unitsOnMap.Add(new JetpackUnit(x, y, 15, 1, 4, 1, "J", "J"));
                map[x, y] = "J";
            }

            numberofRBuildings = rnd.Next(1, 3);
            for (int i = 0; i < numberofRBuildings; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                buildingsOnMap.Add(new ResourceBuilding(x, y, 20, "B", "B"));
                map[x, y] = "B";
            }

            numberofFBuildings = rnd.Next(1, 3);
            for (int i = 0; i < numberofFBuildings; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                buildingsOnMap.Add(new FactoryBuilding(x, y, 20, "F", "F"));
                map[x, y] = "F";
            }

            numberofHBuilding = 1;
            for (int i = 0; i < numberofHBuilding; i++)
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);

                buildingsOnMap.Add(new FactoryBuilding(x, y, 20, "H", "H"));
                map[x, y] = "H";
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    display = map[j, i];
                }

                display += Environment.NewLine;
            }

            return display;
        }

        public void update(Unit u, int newX, int newY)
        {
            if ((newX >= 0 && newX < 20) && (newY >= 0 && newY < 20))
            {
                //Unit(u, newX, newY);
                u.move(newX, newY);
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
