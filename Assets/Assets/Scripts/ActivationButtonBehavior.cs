using UnityEngine;
using System.Collections;

public class ActivationButtonBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Activator Collision detected");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Activator Player Collision Detected");

            GameObject Exit = GameObject.FindGameObjectWithTag("Exit");

            ExitBehavior exitScript = Exit.GetComponent<ExitBehavior>();

            exitScript.ActivateExit();


        }

    }

}
