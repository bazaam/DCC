using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestBehavior : MonoBehaviour {


    bool isChestActive;
    bool isChestOpen;

    int resourceA;
    int resourceB;
    int resourceC;
    int numberOfItems;


    List<ChestManager.ChestItem> items;

    int[] resourceQuantities;

    GameObject inventoryManager;
    ChestManager chestManager;
    ChestManager.ChestItem newItem;
    ItemGenerator itemGenerator;

    // Use this for initialization

    private void Awake()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager");

        chestManager = inventoryManager.GetComponent<ChestManager>();

        newItem = new ChestManager.ChestItem();

        itemGenerator = inventoryManager.GetComponent<ItemGenerator>();

        items = new List<ChestManager.ChestItem>();
    }


    void Start ()
    {
        //Create new chest inventory and populate with base resource values
        isChestActive = false;
       

        resourceA = Random.Range(chestManager.resourceAMinimum, chestManager.resourceAMaximum);
        resourceB = Random.Range(chestManager.resourceBMinimum, chestManager.resourceBMaximum);
        resourceC = Random.Range(chestManager.resourceCMinimum, chestManager.resourceCMaximum);
        numberOfItems = Random.Range(chestManager.chestItemMinimum, chestManager.chestItemMaximum);

       

        for (int i = 0; i < numberOfItems; ++i)
            newItem = itemGenerator.GenerateItem();
            items.Add(newItem);


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
        if (other.tag == "Player")
        {
        isChestActive = true;
        Debug.Log("This chest is active");

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isChestActive = false;
            if (isChestOpen)
                chestManager.CloseChest();

        }
    }

    void ToggleChest()
    {
        if (isChestOpen)
        {
            chestManager.CloseChest();
            isChestOpen = false;
        }

        else
        {
            chestManager.OpenChest(resourceA, resourceB, resourceC, items);
            isChestOpen = true;
        }

    }


}
