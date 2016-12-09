using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//test


public class LevelController : MonoBehaviour {

    public int width;
    public int height;
    public int totalSteps;
    public int roomFrequency;
    public int roomSize;
	// Use this for initialization
	void Start () {

        NewLevel();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NewLevel()
    {
        //Dungeonizer dungeonizer = GetComponent<Dungeonizer>();

        //dungeonizer.ClearOldDungeon();
        //dungeonizer.Generate();

        //StartCoroutine(Respawn());
        //Debug.Log("Locating Player");
        ////DungeonGenLibrary.Tile t;
        Debug.Log("new level called");
        DungeonGenerator newDungeon = gameObject.GetComponent<DungeonGenerator>();
        newDungeon.NewDungeon(width, height, totalSteps, roomFrequency, roomSize);
        Debug.Log("New dungeon spawned");
        
        
        
        
        


    }

    IEnumerator Respawn(Vector2 startTile)
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        PlayerController PlayerController = Player.GetComponent<PlayerController>();

        Debug.Log("Player Found");

        yield return new WaitForSeconds(.1f);
        
        PlayerController.SetLocation(startTile);
    }
}
