using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RTSgame
{
    public class GameEngine : MonoBehaviour
    {
        [SerializeField]
        private int height;
        [SerializeField]
        private int width;
        List<Unit> unitsOnMap = new List<Unit>();
        List<GameObject> objects = new List<GameObject>();
        float tick = 0;

        private Map map = new Map();

        // Use this for initialization
        void Start()
        {
            int xStart = 10;
            int yStart = 10;
            var tileSize = new Vector2(2, 2);

            for (int k = 0; k < height; k++)
            {
                var yPos = -k * tileSize.y + yStart;
                for(int i = 0; i < width; i++)
                {
                    var xPos = i * tileSize.x - xStart;
                    Instantiate(Resources.Load("Arena"), new Vector3(xPos, yPos, 0), Quaternion.identity);
                }
            }

            map.mapGenerate();
            foreach (Building temp in map.Buildings)
            {
                var unitType = temp.GetType().ToString();
                var buildingType = temp.GetType().ToString();
                var xPos = temp.X * tileSize.x - xStart;
                var yPos = -temp.Y * tileSize.y + yStart;

                if (buildingType.Contains("ResourceBuilding"))
                {
                    {
                        if (temp.Faction.Equals("Blue"))
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("ResourceBlue"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                        else
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("ResourceRed"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO);
                            objects.Add(GO2);
                        }
                    }
                }

                if (buildingType.Contains("FactoryBuilding"))
                {
                    if (temp.Faction.Equals("Blue"))
                    {
                        GameObject GO = ((GameObject)Instantiate(Resources.Load("FactoryBlue"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                        GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                        objects.Add(GO);
                        objects.Add(GO2);
                    }
                    else
                    {
                        GameObject GO = ((GameObject)Instantiate(Resources.Load("FactoryRed"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                        GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                        objects.Add(GO);
                        objects.Add(GO2);
                    }

                }
            }

            foreach (Unit temp in map.Units)
            {
                var unitType = temp.GetType().ToString();
                var xPos = temp.X * tileSize.x - xStart;
                var yPos = -temp.Y * tileSize.y + yStart;

                if(unitType.Contains("MeleeUnit"))
                {
                    {
                        if (temp.Faction.Equals("Blue"))
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("MeleeBlue"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO);
                            objects.Add(GO2);
                        }
                        else
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("MeleeRed"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO);
                            objects.Add(GO2);
                        }
                    }
                }

                else if(unitType.Contains("RangedUnit"))
                {
                    if (temp.Faction.Equals("Blue"))
                    {
                        GameObject GO = ((GameObject)Instantiate(Resources.Load("RangedBlue"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                        GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                        objects.Add(GO);
                        objects.Add(GO2);
                    }
                    else
                    {
                        GameObject GO = ((GameObject)Instantiate(Resources.Load("RangedRed"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                        GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                        objects.Add(GO);
                        objects.Add(GO2);
                    }

                }

                else if (unitType.Contains("BruteUnit"))
                {
                    {
                        if (temp.Faction.Equals("Blue"))
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("BruteBlue"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO);
                            objects.Add(GO2);
                        }
                        else
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("BruteRed"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO);
                            objects.Add(GO2);
                        }
                    }
                }

                else if (unitType.Contains("JetpackUnit"))
                {
                    if (temp.Faction.Equals("Blue"))
                    {
                        GameObject GO = ((GameObject)Instantiate(Resources.Load("JetpackBlue"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                        GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                        objects.Add(GO);
                        objects.Add(GO2);
                    }
                    else
                    {
                        GameObject GO = ((GameObject)Instantiate(Resources.Load("JetpackRed"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                        GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                        objects.Add(GO);
                        objects.Add(GO2);
                    }

                }
            }
        }
            

        // Update is called once per frame
        void Update()
        {
            tick += Time.deltaTime;

            if (tick >= 1)
            {
                foreach (GameObject thing in objects)
                {
                    Destroy(thing);
                }

                int xStart = 10;
                int yStart = 10;
                var tileSize = new Vector2(2, 2);

                foreach (Building temp in map.Buildings)
                {
                    var unitType = temp.GetType().ToString();
                    var buildingType = temp.GetType().ToString();
                    var xPos = temp.X * tileSize.x - xStart;
                    var yPos = -temp.Y * tileSize.y + yStart;

                    if (buildingType.Contains("ResourceBuilding"))
                    {
                        {
                            if (temp.Faction.Equals("Blue"))
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("ResourceBlue"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                objects.Add(GO2);
                                objects.Add(GO);                                
                            }
                            else
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("ResourceRed"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                objects.Add(GO2);
                                objects.Add(GO);
                            }
                        }
                    }

                    if (buildingType.Contains("FactoryBuilding"))
                    {
                        if (temp.Faction.Equals("Blue"))
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("FactoryBlue"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                        else
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("FactoryRed"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }

                    }
                }

                foreach (Unit temp in map.Units)
                {
                    var unitType = temp.GetType().ToString();
                    var xPos = temp.X * tileSize.x - xStart;
                    var yPos = -temp.Y * tileSize.y + yStart;

                    if (unitType.Contains("MeleeUnit"))
                    {
                        {
                            if (temp.Faction.Equals("Blue"))
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("MeleeBlue"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                objects.Add(GO2);
                                objects.Add(GO);
                            }
                            else
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("MeleeRed"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                objects.Add(GO2);
                                objects.Add(GO);
                            }
                        }
                    }

                    else if (unitType.Contains("RangedUnit"))
                    {
                        if (temp.Faction.Equals("Blue"))
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("RangedBlue"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                        else
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("RangedRed"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }

                    }

                    else if (unitType.Contains("BruteUnit"))
                    {
                        {
                            if (temp.Faction.Equals("Blue"))
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("BruteBlue"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                objects.Add(GO2);
                                objects.Add(GO);
                            }
                            else
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("BruteRed"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                objects.Add(GO2);
                                objects.Add(GO);
                            }
                        }
                    }

                    else if (unitType.Contains("JetpackUnit"))
                    {
                        if (temp.Faction.Equals("Blue"))
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("JetpackBlue"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                        else
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("JetpackRed"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }

                    }
                }

                foreach (Unit u in map.Units)
                {

                    Unit closestEnemy = u.nearestUnit(map.Units);
                    if (u.isWithinAttackRange(closestEnemy))
                    {
                        u.combat(closestEnemy);
                    }
                    else
                    {
                        map.move(u, closestEnemy);
                    }

                    tick = 0;
                }
            }
        }
    }
}
