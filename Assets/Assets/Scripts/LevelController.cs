using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	// Use this for initialization
	void Start () {

        NewLevel();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NewLevel()
    {
        Dungeonizer dungeonizer = GetComponent<Dungeonizer>();

        dungeonizer.ClearOldDungeon();
        dungeonizer.Generate();

        StartCoroutine(Respawn());
        Debug.Log("Locating Player");


    }

    IEnumerator Respawn()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        PlayerController PlayerController = Player.GetComponent<PlayerController>();

        Debug.Log("Player Found");

        yield return new WaitForSeconds(.1f);

        PlayerController.SetSpawn();
    }
}
