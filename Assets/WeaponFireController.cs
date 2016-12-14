using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFireController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1000)) {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.SendMessageUpwards("ApplyDamage", 100f);
                }
            }
        }
    }
}
