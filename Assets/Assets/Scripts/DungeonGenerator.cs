using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class DungeonGenerator : MonoBehaviour
{
    List<List<int>> levelMap = new List<List<int>>();
    DungeonGen.Map dungeonMap = new DungeonGen.Map(100, 120, 1000);
    public GameObject wall;
    public GameObject floor;
    Vector2 start = new Vector2();
    Vector2 exit = new Vector2();


    public void SpawnDungeon()
    {

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
        start = dungeonMap.entry;
        //Debug.Log("Entry Point Returned");
        //Debug.Log(start + "is start");
        //Debug.Log(dungeonMap.entry + "is dungeonMap.entry");
        return start;
    }

    public Vector2 GetExitPoint()
    {
        exit = dungeonMap.exit;
        return exit;
    }



    void InstantiateDungeonTile(int x, int y, int tileType)
    {
        if (tileType != 1)
        {
            Instantiate(floor, new Vector3(x, 0, y), Quaternion.identity);
        }
        else if (tileType == 1)
        {
            Instantiate(wall, new Vector3(x, 0, y), Quaternion.identity);
        }
    }


}







