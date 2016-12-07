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

            #region Create the map
            for (int i = 0; i < xmax; i++)
            {
                List<Tile> tempList = new List<Tile>();
                for (int j = 0; j < ymax; j++)
                {
                    tempList.Add(new Tile(i, j));
                }
                tLList.Add(new List<Tile>());
                accessMap.Add(new List<int>());
                foreach (Tile t in tempList) { tLList[i].Add(new Tile(t.x, t.y)); accessMap[i].Add(0); }

            }
            foreach (List<Tile> l in tLList)
            {
                foreach (Tile t in l.Where(z => z.x == 1 || z.x == xmax - 2 || z.y == 1 || z.y == ymax - 2))
                { t.BorderCheck(xmax, ymax); }
            }
            #endregion

            #region Initialize pathways
            //if (type == "Cave") { InitCave(xmax, ymax, steps); }
            //else if (type == "Dungeon") { InitDungeon(xmax, ymax, steps); }
            //else if (type == "Test") { }
            InitDungeon(xmax, ymax, steps);
            #endregion

            #region Create Display
            //visMap = new DMMap(this);

            #endregion

            #region Track Open Space

            List<Tile> flatList = new List<Tile>();
            //foreach (List<Tile> tList in tLList)
            for (int i = 0; i < xmax; i++)
            {
                //foreach (Tile t in tList)
                for (int j = 0; j < ymax; j++)
                {
                    flatList.Add(tLList[i][j]);
                    if (tLList[i][j].isWall == true) { accessMap[i][j] = 1; }
                }
            }
            foreach (Tile t in flatList.Where(z => !z.isWall)) { openSpace.Add(t); }

            #endregion

            #region GenerateAccessibleMap

            IntMap = accessMap;
            IntMap[(int)entry.x][(int)entry.y] = -1;
            IntMap[(int)exit.x][(int)exit.y] = -2;

            #endregion

        }

        //public List<List<int>> IntMap { get { return accessMap; } }

        #region Different methods for generating the map
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

            int[] directionHelper = { -1, 0, 1 };
            int[] direction = { directionHelper[rand.Next(0, 3)], directionHelper[rand.Next(0, 3)] };
            //nextCoord.

            for (int i = 0; i < steps; i++)
            {
                int temp = rand.Next(1, 11);
                int[] dirModX = { 0, 3 };
                int[] dirModY = { 0, 3 };
                if (nextCoord.x == 1) { dirModX[0] = 1; }
                else if (nextCoord.x == xmax - 2) { dirModX[1] = 2; }
                else { dirModX[0] = 0; dirModX[1] = 3; }
                if (nextCoord.y == 1) { dirModY[0] = 1; }
                else if (nextCoord.y == ymax - 2) { dirModY[1] = 2; }
                else { dirModY[0] = 0; dirModY[1] = 3; }


                if (temp >= 8)
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
