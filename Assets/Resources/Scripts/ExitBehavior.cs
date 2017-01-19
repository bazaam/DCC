using UnityEngine;
using System.Collections;

public class ExitBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   


    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Collision detected");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Collision Detected");

            GameObject GameManager = GameObject.FindGameObjectWithTag("GameController");

            LevelController levelController = GameManager.GetComponent<LevelController>();

            levelController.NewLevel();

            
        }
        
    }
    

    public void ActivateExit()
    {
        GetComponent<Collider>().isTrigger = true;
    }

}
