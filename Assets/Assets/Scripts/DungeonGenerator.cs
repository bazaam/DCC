using UnityEngine;
using System.Collections;



public class DungeonGenerator : MonoBehaviour
{

    public GameObject Dungeon;
    public GameObject Player;



    void Awake()
    {
        CreateNewDungeonLevel();
    }
    void Start()
    {



    }

    public void CreateNewDungeonLevel()
    {
        Instantiate(Dungeon);
    }
}
