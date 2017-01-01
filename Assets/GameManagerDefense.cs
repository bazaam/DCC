using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerDefense : MonoBehaviour
{

    bool isPaused = true;

    public GameObject player;
    public GameObject pauseMenu;

    public void TogglePauseMenu()
    {
        if (isPaused)
        {
            pauseMenu.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
            isPaused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            player.GetComponentInChildren<LaserFire>().enabled = true;
        }

        else
        {
            pauseMenu.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0.0f;
            isPaused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            player.GetComponentInChildren<LaserFire>().enabled = false;

        }
    }


	// Use this for initialization
	void Start ()
    {
        TogglePauseMenu();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
