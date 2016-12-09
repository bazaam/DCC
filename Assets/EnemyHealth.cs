using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public float startingHealth = 10;            // The amount of health the enemy starts the game with.
    float currentHealth;                   // The current health the enemy has.

	// Use this for initialization
	void Awake () {

        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void ApplyDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Destroy(this.gameObject);
    }

}
