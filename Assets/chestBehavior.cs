using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestBehavior : MonoBehaviour {

    public InventoryManager inventoryManager;

    bool isChestActive;
    bool isChestOpen;

	// Use this for initialization
	void Start ()
    {

        isChestActive = false;
        // Grab some items from the item list
        inventoryManager = FindObjectOfType<InventoryManager>();
		 
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isChestActive)
                ToggleChest();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        isChestActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isChestActive = false;
        if (isChestOpen)
            ToggleChest();
    }

    void ToggleChest()
    {
        if (isChestOpen)
            inventoryManager.CloseChest();
        else
            inventoryManager.OpenChest();
    }


}
