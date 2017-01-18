using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestBehavior : MonoBehaviour {


    bool isChestActive;
    bool isChestOpen;
    int numberOfItems;

    int quantityResourceA;
    int quantityResourceB;
    int quantityResourceC;

    int[] resourceQuantities;

    ChestManager chestManager;
    ItemGenerator itemGenerator;

	// Use this for initialization
	void Start ()
    {
        //Create new chest inventory and populate with base resource values
        ChestManager.ChestInventory thisChestInventory = new ChestManager.ChestInventory(
            quantityResourceA = Random.Range(chestManager.resourceAMinimum, chestManager.resourceAMaximum), 
            quantityResourceB = Random.Range(chestManager.resourceBMinimum, chestManager.resourceBMaximum),
            quantityResourceC = Random.Range(chestManager.resourceCMinimum, chestManager.resourceCMaximum),
            numberOfItems = Random.Range(chestManager.chestItemMinimum, chestManager.chestItemMaximum));

        isChestActive = false;
       
        chestManager = FindObjectOfType<ChestManager>();
        itemGenerator = FindObjectOfType<ItemGenerator>();

        
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
            chestManager.CloseChest();
    }

    void ToggleChest()
    {
        if (isChestOpen)
            chestManager.CloseChest();
        else
            chestManager.OpenChest();
    }


}
