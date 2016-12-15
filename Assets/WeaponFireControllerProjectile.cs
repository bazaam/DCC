using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFireControllerProjectile : MonoBehaviour {

    public GameObject projectile;
    public GameObject gunTip;
    public float projectileSpeed;


	// Use this for initialization
	void Start ()
    {
        

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject firedProjectile = Instantiate(projectile, gunTip.transform.position, gunTip.transform.rotation);
            firedProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
        }

    }
}
