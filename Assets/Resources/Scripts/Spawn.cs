using UnityEngine;
using System.Collections;



public class Spawn : MonoBehaviour {

    public GameObject DungeonGenerator;
    public GameObject Player;



    void Awake ()
    {
        CreateNewDungeonLevel();
    }
	void Start () {
        

	
	}
	
	public void CreateNewDungeonLevel()
    {
        Instantiate(DungeonGenerator);
    }
}
