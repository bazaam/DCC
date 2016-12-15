using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFireControllerHitscan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100)) {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.SendMessageUpwards("ApplyDamage", 100f);
                }
            }
        }
    }
}
