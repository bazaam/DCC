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
    Vector2 start = new Vector2();
    Vector2 exit = new Vector2();


    void SpawnDungeon(int a, int b, int c)
    {

        dungeonMap = new DungeonGen.Map(a, b, c);
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

    public Vector2 GetEntryPoint()
    {
        return dungeonMap.entry;
    }

    public Vector2 GetExitPoint()
    {
        return dungeonMap.exit;
    }

    public void NewDungeon(int a, int b, int c)
    {
        SpawnDungeon(a, b, c);
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







