using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject[] enemyPrefabs;                // The prefab to be spawned.
    public float spawnTime = 6f;            // How long between each spawn.
    private Vector3 spawnPosition;

    // Use this for initialization
    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    void Spawn()
    {
        float rand1 = Random.Range(-64, -40);
        float rand2 = Random.Range(-64, 64);
        //if (rand1 > -20f && rand2 > -20f && rand2 < 20f)
        //    rand1 += 40f;
        //if (rand2 > -20f && rand1 > -20f && rand1 < 20f)
        //    rand2 += 40f;
        spawnPosition.x = rand1;
        spawnPosition.y = 0.5f;
        spawnPosition.z = rand2;

        GameObject newEnemy = Instantiate(enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Length - 1)], spawnPosition, Quaternion.identity) as GameObject;
        newEnemy.transform.parent = this.transform;
    }
}