using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class ItemGenerator : MonoBehaviour
{
    string storedJson;
    string parsedJson;

    static string[] itemTypes;
    static string[] itemProperties;
    static string[] itemQualities;

    // Use this for initialization
    private void Awake()
    {
        if (!Directory.Exists("Data"))
            Directory.CreateDirectory("Data");
        
        if (!File.Exists("Data/itemlibrary.json"))
        {
            //File.Create("Data/itemlibrary.json");

            DynamicLootList newList = new DynamicLootList();

            newList.itemType = "Item Types";
            newList.propertyModifier = "Item Properties";
            newList.qualityModifier = "Item Qualities";

            string json = JsonUtility.ToJson(newList);

            File.WriteAllText("../DCC/Data/itemlibrary.json", json);
        }

    }

    void Start ()
    {
        storedJson = File.ReadAllText("../DCC/Data/itemlibrary.json");
        DynamicLootList lootList = JsonUtility.FromJson<DynamicLootList>(storedJson);

        itemTypes = lootList.itemType.Split(' ');
        itemProperties = lootList.propertyModifier.Split(' ');
        itemQualities = lootList.qualityModifier.Split(' ');

        Debug.Log(itemQualities[Random.Range(0, itemQualities.Length)] + ' ' + itemTypes[Random.Range(0, itemTypes.Length)] + " of " + itemProperties[Random.Range(0, itemProperties.Length)]);
        Debug.Log(itemQualities[Random.Range(0, itemQualities.Length)] + ' ' + itemTypes[Random.Range(0, itemTypes.Length)] + " of " + itemProperties[Random.Range(0, itemProperties.Length)]);
        Debug.Log(itemQualities[Random.Range(0, itemQualities.Length)] + ' ' + itemTypes[Random.Range(0, itemTypes.Length)] + " of " + itemProperties[Random.Range(0, itemProperties.Length)]);
        Debug.Log(itemQualities[Random.Range(0, itemQualities.Length)] + ' ' + itemTypes[Random.Range(0, itemTypes.Length)] + " of " + itemProperties[Random.Range(0, itemProperties.Length)]);
        Debug.Log(itemQualities[Random.Range(0, itemQualities.Length)] + ' ' + itemTypes[Random.Range(0, itemTypes.Length)] + " of " + itemProperties[Random.Range(0, itemProperties.Length)]);

        //Debug.Log(itemTypes[0]);
        //Debug.Log(itemProperties[1]);
        //Debug.Log(itemQualities[2]);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public static ChestManager.ChestItem GenerateItem()
    {
        ChestManager.ChestItem newItem = new ChestManager.ChestItem();

        newItem.ItemName = new string[3] {itemQualities[Random.Range(0, itemQualities.Length)], itemTypes[Random.Range(0, itemTypes.Length)],
            itemProperties[Random.Range(0, itemProperties.Length)]};

        return newItem;
        
    }

    [System.Serializable]
    class DynamicLootList
    {
        public string itemType;
        public string propertyModifier;
        public string qualityModifier;
    }

}



