using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class DungeonGenerator : MonoBehaviour
{
    List<List<int>> levelMap = new List<List<int>>();
    DungeonGen.Map dungeonMap = new DungeonGen.Map(100, 120, 750);

    void SpawnDungeon()
    {

        public GameObject wall;
        public GameObject floor;

        
        

        levelMap = dungeonMap.IntMap;
        int x = 0;
        int y = 0;

        foreach (List<int> subList in levelMap) 
        {
	        foreach (int tileType in subList) 
            {

                InstantiateDungeonTile(x, y, tileType);
		        ++y;
	        }

	        ++x;
        }
    }

    void InstantiateDungeonTile(int x, int y, int tileType)
    {
        if (tileType == 0)
        {
            GameObject newTile = GameObject.Instantiate(floor, Vector3(x, y, 0), Quaternion.identity);
        }
        else if (tileType == 1)
        {
            Instantiate(wall, Vector3(x, y, 0), Quaternion.identity);
    }
}







