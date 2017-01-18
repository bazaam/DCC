using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public int chestItemMinimum;
    public int chestItemMaximum;

    public int resourceAMinimum;
    public int resourceAMaximum;
    public int resourceBMinimum;
    public int resourceBMaximum;
    public int resourceCMinimum;
    public int resourceCMaximum;

    public ItemGenerator itemGenerator;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OpenChest()
    {
        //populate with items from chest
        //enable canvas
        //
    }

    public void CloseChest()
    {
        //disable canvas
        //return changes in chest inventory
    }

    public class ChestInventory 
    {
        int quantityResourceA;
        int quantityResourceB;
        int quantityResourceC;
        int numberOfItems;
        List<ChestItem> itemsInChest = new List<ChestItem>();

        public ChestInventory(int amountA, int amountB, int amountC, int totalItems)
        {
            quantityResourceA = amountA;
            quantityResourceB = amountB;
            quantityResourceC = amountC;
            numberOfItems = totalItems;
            
            ChestItem newItem = new ChestItem();
            
            for (int i = 0; i < numberOfItems; ++i)
                newItem = ItemGenerator.GenerateItem();
                itemsInChest.Add(newItem);
        }
    }

    public class ChestItem
    {
        private string[] itemName = new string[3];
        public string[] ItemName
        {
            get {return itemName;}
            set {itemName = value;}
        }

    }

}
