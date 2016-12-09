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
        spawnPosition.x = Random.Range(-32, 32);
        spawnPosition.y = 0.5f;
        spawnPosition.z = Random.Range(-32, 32);

        GameObject newEnemy = Instantiate(enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Length - 1)], spawnPosition, Quaternion.identity) as GameObject;
        newEnemy.transform.parent = this.transform;
    }
}