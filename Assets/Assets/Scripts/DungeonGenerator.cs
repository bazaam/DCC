using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class DungeonGenerator : MonoBehaviour
{

    
    List<List<int>> levelMap = new List<List<int>>();
    DungeonGen.Map dungeonMap = new DungeonGen.Map();
    
    public GameObject wall;
    public GameObject floor;
    public GameObject entry;
    public GameObject chest;
    public GameObject resourceA;
    public GameObject resourceB;
    public GameObject resourceC;
    


    void SpawnDungeon(int width, int height, int totalSteps, int roomFrequency, int roomSize)
    {

        dungeonMap = new DungeonGen.Map(width, height, totalSteps, roomFrequency, roomSize);
        levelMap = dungeonMap.IntMap;
        int x = 0;
        int y = 0;

        foreach (List<int> subList in levelMap)
        {
            foreach (int tileType in subList)
            {
                if (tileType != -1)
                {
                    InstantiateDungeonTile(x, y, tileType);
                }
                
                ++y;
            }

            y = 0;
            ++x;
        }
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        PlayerController PlayerController = Player.GetComponent<PlayerController>();
        Debug.Log("Player Found");
        PlayerController.SetLocation(dungeonMap.entry);

    }
    void SpawnDungeonObject(float density, GameObject objectToSpawn, GameObject[] floorTiles)
    {
        for (int i = 0; i < (floorTiles.Length * density); ++i)
        {
            int spawnTileIndex = Random.Range(0, floorTiles.Length);
            GameObject spawnTile = floorTiles[spawnTileIndex];

            Instantiate(objectToSpawn, new Vector3(spawnTile.transform.position.x, 0.1f, spawnTile.transform.position.z), objectToSpawn.transform.rotation);
        }
    }

    public Vector2 GetEntryPoint()
    {
        return dungeonMap.entry;
    }

    public Vector2 GetExitPoint()
    {
        return dungeonMap.exit;
    }

    public void NewDungeon(int width, int height, int totalSteps, int roomFrequency, int roomSize)
    {
        SpawnDungeon(width, height, totalSteps, roomFrequency, roomSize);
    }
    
    public void PopulateDungeon(float chestDensity, float resourceADensity, float resourceBDensity, float resourceCDensity)
    {
        GameObject[] floorTiles = GameObject.FindGameObjectsWithTag("floor");
        Debug.Log(floorTiles.Length);

        SpawnDungeonObject(chestDensity, chest, floorTiles);
        SpawnDungeonObject(resourceADensity, resourceA, floorTiles);
        SpawnDungeonObject(resourceBDensity, resourceB, floorTiles);
        SpawnDungeonObject(resourceCDensity, resourceC, floorTiles);
    }

    void InstantiateDungeonTile(int x, int y, int tileType)
    {
        if (tileType == -3)
        {
            Instantiate(entry, new Vector3(x, 0, y), Quaternion.identity);
        }
        else if (tileType == 0)
        {
            Instantiate(wall, new Vector3(x, 0, y), Quaternion.identity);
        }
        else
        {
            Instantiate(floor, new Vector3(x, 0, y), Quaternion.identity);
        }
    }


}







