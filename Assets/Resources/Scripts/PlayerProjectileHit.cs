using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileHit : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.SendMessageUpwards("ApplyDamage", 100f);
            Destroy(gameObject);
        }

    }
}