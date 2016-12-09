using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DungeonGen : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }
    public class Map
    {
        #region Public variables
        //public DMMap visMap;
        public List<List<Tile>> tLList = new List<List<Tile>>();
        public List<Tile> openSpace = new List<Tile>();
        public List<List<int>> accessMap;
        public List<List<int>> IntMap;
        public Vector2 entry = new Vector2();
        public Vector2 exit = new Vector2();
        #endregion

        public Map() { }

        public Map(int xmax, int ymax, int steps, string type = "Dungeon")
        {
            Random rand = new Random();
            accessMap = new List<List<int>>();
            IntMap = new List<List<int>>();

            #region Create the bare map
            for (int i = 0; i < xmax; i++)
            {
                List<Tile> tempList = new List<Tile>();
                for (int j = 0; j < ymax; j++)
                {
                    tempList.Add(new Tile(i, j));
                }
                tLList.Add(new List<Tile>());
                accessMap.Add(new List<int>());
                foreach (Tile t in tempList) { tLList[i].Add(new Tile(t.x, t.y)); accessMap[i].Add(1); }

            }
            foreach (List<Tile> l in tLList)
            {
                foreach (Tile t in l.Where(z => z.x == 1 || z.x == xmax - 2 || z.y == 1 || z.y == ymax - 2))
                { t.BorderCheck(xmax, ymax); }
            }
            #endregion

            //Initialize pathways
            InitDungeon(xmax, ymax, steps);

            //Generate Blank Space
            List<Tile> flatList = new List<Tile>();
            for (int i = 0; i < xmax; i++)
            {
                for (int j = 0; j < ymax; j++)
                {
                    flatList.Add(tLList[i][j]);
                    if (tLList[i][j].isWall == true) { accessMap[i][j] = -1; }
                }
            }
            foreach (Tile t in flatList.Where(z => !z.isWall)) { openSpace.Add(t); }

            //Generate Walls
            foreach (List<Tile> ls in tLList)
            {
                foreach(Tile t in ls)
                {
                    if (/*t.isWall == false*/ accessMap[t.x][t.y] !=0 && accessMap[t.x][t.y]!= -1)
                    {
                        foreach(Coordinates n in t.neighbors)
                        {
                            //Debug.Log("xy: " + n.x + " " + n.y);
                            if (n.x == xmax || n.y == ymax ) continue;
                            if (n.x < 0 || n.y < 0) continue;
                            
                            if (tLList[n.x][n.y].isWall == true)
                            {
                                accessMap[n.x][n.y] = 0;
                            }
                        }
                    }
                }
            }



            #region Track Open Space

            

            #endregion

            #region Clean Open Space

            int xminClean =500, xmaxClean=0, yminClean=500, ymaxClean=0;


            //Find Boundaries of Open Space
            for (int i = 0; i < xmax; i++)
            {
                for(int j = 0; j < ymax; j++)
                {
                    if (accessMap[i][j] != 0)
                    {
                        if (i < xminClean) { xminClean = i; }
                        if (j < yminClean) yminClean = j;
                    }
                }
            }
            for (int i = xmax-1; i >= 0; i--)
            {
                for (int j = ymax-1; j >= 0; j--)
                {
                    if (accessMap[i][j] != 0)
                    {
                        if (i > xmaxClean) xmaxClean = i;
                        if (j > ymaxClean) ymaxClean = j;
                    }
                }
            }

            //////Clear Open Space
            for (int i = xmaxClean + 2; i < xmax; i++)
            {
                accessMap.RemoveAt(xmaxClean + 2);
            }
            foreach (List<int> xls in accessMap)
            {
                for (int j = ymaxClean + 2; j < ymax; j++) { xls.RemoveAt(ymaxClean + 2); }
                for (int j = 0; j < yminClean; j++) { xls.RemoveAt(0);  }
            }
            for (int j = 0; j < yminClean; j++) { entry.y--; exit.y--; }
            //Debug.Log("entry.x: " + entry.x);
            for (int i = 0; i < xminClean; i++)
            {
                accessMap.RemoveAt(0);
                entry.x--;
                exit.x--;
            }

            //////Add edges back on
            accessMap.Insert(0, new List<int>());
            accessMap.Add(new List<int>());
            for(int i = 0; i < accessMap[1].Count; i++)
            {
                accessMap[0].Add(0);
                accessMap[accessMap.Count - 1].Add(0);
            }
            entry.x++;
            exit.x++;
            
            foreach (List<int> xls in accessMap)
            {
                xls.Insert(0, 0);
                xls.Add(0);
            }
            entry.y++;
            exit.y++;

            //Add Doors
            for (int i = 0; i < accessMap.Count; i++)
            {
                for(int j = 0; j < accessMap[1].Count; j++)
                {
                    if (accessMap[i][j] == 1)
                    {
                        if (accessMap[i - 1][j] == 2 || accessMap[i + 1][j] == 2 || accessMap[i][j - 1] == 2 || accessMap[i][j + 1] == 2)
                        {
                            accessMap[i][j] = -4;
                        }
                    }
                }
            }

            

            //accessMap.Insert(0, new List<int>());
            //accessMap.Add(new List<int>());
            ////foreach (List<int> ls in accessMap)
            //foreach (int i in accessMap[1]){
            //    accessMap[0].Add(1);
            //    accessMap[accessMap.Count - 1].Add(1);

            //}


            #endregion

            #region Generate Accessible Map

            //Debug.Log("test");
            //Debug.Log("New entry.x, y: " + entry.x + ", " + entry.y);

            //Debug.Log("Size:" + accessMap.Count + " " + accessMap[0].Count);
            //Debug.Log(accessMap[(int)entry.x][(int)entry.y]);


            IntMap = accessMap;
            IntMap[(int)entry.x][(int)entry.y] = -3;
            IntMap[(int)exit.x][(int)exit.y] = -2;


            /*

            Old:
            3: Doors
            2: Room
            1: Wall
            0: Empty Space
            -1: Entry
            -2: Exit

            New:

            2: Room
            1: Floor
            0: Wall
            -1: NULL
            -2: Exit
            -3: Entry
            -4 Door

            */

            #endregion

        }

        #region Methods for generating the map
        //internal void InitCave(int xmax, int ymax, int steps)
        //{
        //    Random rand = new Random();
        //    Coordinates startCoord = new Coordinates(rand.Next(1, xmax - 1), rand.Next(1, ymax - 1));
        //    Coordinates nextCoord = new Coordinates(startCoord.x, startCoord.y);
        //    Tile startTile = tLList[startCoord.x][startCoord.y];
        //    this.tLList[startCoord.x][startCoord.y].isWall = false;
        //    for (int i = 0; i < steps; i++)
        //    {
        //        nextCoord = tLList[nextCoord.x][nextCoord.y].neighbors[rand.Next(0, tLList[nextCoord.x][nextCoord.y].neighbors.Count)];
        //        this.tLList[nextCoord.x][nextCoord.y].isWall = false;
        //    }
        //}

        internal void InitDungeon(int xmax, int ymax, int steps)
        {
            System.Random rand = new System.Random();
            Coordinates startCoord = new Coordinates(rand.Next(1, xmax - 1), rand.Next(1, ymax - 1));
            Coordinates nextCoord = new Coordinates(startCoord.x, startCoord.y);
            entry = new Vector2((float)startCoord.x, (float)startCoord.y);
            //Debug.Log(startCoord.y);

            int[] directionHelper = { -1, 0, 1 };
            int[] direction = { directionHelper[rand.Next(0, 3)], directionHelper[rand.Next(0, 3)] };
            //nextCoord.

            for (int i = 0; i < steps; i++)
            {
                int temp = rand.Next(1, 101);
                int[] dirModX = { 0, 3 };
                int[] dirModY = { 0, 3 };
                if (nextCoord.x == 1) { dirModX[0] = 1; }
                else if (nextCoord.x == xmax - 2) { dirModX[1] = 2; }
                else { dirModX[0] = 0; dirModX[1] = 3; }
                if (nextCoord.y == 1) { dirModY[0] = 1; }
                else if (nextCoord.y == ymax - 2) { dirModY[1] = 2; }
                else { dirModY[0] = 0; dirModY[1] = 3; }


                if (temp >= 90)
                {
                    direction[0] = directionHelper[rand.Next(dirModX[0], dirModX[1])];
                    direction[1] = directionHelper[rand.Next(dirModY[0], dirModY[1])];
                }

                if (nextCoord.x + direction[0] < 1 || nextCoord.x + direction[0] > xmax - 2) { continue; }
                if (nextCoord.y + direction[1] < 1 || nextCoord.y + direction[1] > ymax - 2) { continue; }
                if (direction[0] != 0) { nextCoord.x = nextCoord.x + direction[0]; }
                else { nextCoord.y = nextCoord.y + direction[1]; }
                //nextCoord.x = nextCoord.x + direction[0];
                //nextCoord.y = nextCoord.y + direction[1];
                this.tLList[nextCoord.x][nextCoord.y].isWall = false;
                


                //Generate rooms
                if (rand.Next(0, 100) > 85)
                {
                    if (nextCoord.x > 10 || nextCoord.x < xmax - 10)
                    {
                        if (nextCoord.y > 10 || nextCoord.y < ymax - 10)
                        {
                            for (int k = -1; k<2; k++)
                            {
                                for (int l = -1; l < 2; l++)
                                {
                                    this.tLList[nextCoord.x+k][nextCoord.y+l].isWall = false;
                                    accessMap[nextCoord.x][nextCoord.y] = 2;
                                }
                            }
                        }
                    }
                }
            }
            exit = new Vector2((float)nextCoord.x, (float)nextCoord.y);

        }
        #endregion


    }

    public class Tile
    {
        public Coordinates coord;
        public bool isWall = true;
        //neighbors is used primarily for map generation, but it may be useful for pathfinding later.
        public List<Coordinates> neighbors = new List<Coordinates>();
        public int[,] direction_ops = { { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, 1 } };
        public int x;
        public int y;
        public bool isVisible = false;
        public bool isViewed = false;

        public Tile(int x_in, int y_in)
        {
            coord = new Coordinates(x_in, y_in);
            for (int i = 0; i < 8; i++)
            {
                neighbors.Add(new Coordinates(x_in + direction_ops[i, 0], y_in + direction_ops[i, 1]));
            }
            x = coord.x;
            y = coord.y;
        }

        //Checks to see if the tile is on the edge of the allowable map, and if it is, then it removes the theoretical neighbors from neighbors.
        public void BorderCheck(int x_max, int y_max)
        {
            if (coord.x == x_max - 2)
            {
                neighbors.RemoveAt(2); neighbors.RemoveAt(1); neighbors.RemoveAt(0);
                if (coord.y == y_max - 2) { neighbors.RemoveAt(4); neighbors.RemoveAt(3); }
                if (coord.y == 1) { neighbors.RemoveAt(1); neighbors.RemoveAt(0); }
            }
            else if (coord.x == 1)
            {
                neighbors.RemoveAt(6); neighbors.RemoveAt(5); neighbors.RemoveAt(4);
                if (coord.y == y_max - 2) { neighbors.RemoveAt(4); neighbors.RemoveAt(0); }
                if (coord.y == 1) { neighbors.RemoveAt(3); neighbors.RemoveAt(2); }
            }
            else
            {
                if (coord.y == y_max - 2) { neighbors.RemoveAt(7); neighbors.RemoveAt(6); neighbors.RemoveAt(0); }
                if (coord.y == 1) { neighbors.RemoveAt(4); neighbors.RemoveAt(3); neighbors.RemoveAt(2); }
            }

        }
    }

    public class Coordinates
    {
        public int x { get; set; }
        public int y { get; set; }
        public string str_xy { get; set; }

        private void DistributeChange(object sender, System.EventArgs e)
        {
            str_xy = ToStringPair(x, y);
        }

        public Coordinates(int x_in, int y_in)
        {
            x = x_in;
            y = y_in;
            str_xy = ToStringPair(x_in, y_in);
        }

        //Not truly necessary, but when performing a deep copy, this constructor is useful.
        public Coordinates(string xy_str)
        {
            str_xy = xy_str;
            string[] temp = new string[2];
            temp = xy_str.Split();
            x = System.Convert.ToInt16(temp[0]);
            y = System.Convert.ToInt16(temp[1]);
        }

        public Coordinates()
        {
            x = 0; y = 0;
            str_xy = "0 0";
        }

        public void AddCoord(Coordinates otherCoord)
        {
            x = x + otherCoord.x;
            y = y + otherCoord.y;
            str_xy = ToStringPair(x, y);
        }

        public string ToStringPair(int x_in, int y_in)
        {
            return x_in.ToString() + " " + y_in.ToString();
        }

        public void Delta(int dx, int dy)
        {
            this.x = this.x + dx;
            this.y = this.y - dy;
        }
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
