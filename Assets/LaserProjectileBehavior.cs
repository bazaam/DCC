using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectileBehavior : MonoBehaviour {

    public float projectileSpeed = 1500f;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);
    }
}
