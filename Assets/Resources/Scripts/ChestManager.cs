using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestManager : MonoBehaviour
{
    public GameObject chestUI;

    

    public int chestItemMinimum;
    public int chestItemMaximum;

    public int resourceAMinimum;
    public int resourceAMaximum;
    public int resourceBMinimum;
    public int resourceBMaximum;
    public int resourceCMinimum;
    public int resourceCMaximum;

    public Text resourceAText;
    public Text resourceBText;
    public Text resourceCText;

    public GameObject chestItemPrefab;
    public Transform chestItemsPanel;
    

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OpenChest(int resourceA, int resourceB, int resourceC, List<ChestItem> items)
    {
        resourceAText.text = resourceA.ToString();
        resourceBText.text = resourceB.ToString();
        resourceCText.text = resourceC.ToString();

        //Debug.Log("The number of items received was");
        //Debug.Log(items.Count);

        foreach (ChestItem item in items)
        {
            GameObject thisChestItem = Instantiate(chestItemPrefab, chestItemsPanel);
            Debug.Log(item.itemName[1]);
            string spritePath = "Sprites/" + item.itemName[1];
            Debug.Log(spritePath);
            thisChestItem.transform.GetChild(0).GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(spritePath);
            
        }



        //populate with items from chest
        chestUI.SetActive(true);
        //
    }

    public void CloseChest()
    {
        chestUI.SetActive(false);
        //return changes in chest inventory
    }


    public class ChestItem
    {
        public string[] itemName = new string[3];

    }

}
