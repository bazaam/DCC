using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : MonoBehaviour
{

    LineRenderer line;
    public GameObject gunTip;
    public bool continuousFire;
    public GameObject projectile;
    public float projectileSpeed;

	void Start ()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
	}
	
	void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            if (continuousFire)
            {
                StopCoroutine("FireLaser");
                StartCoroutine("FireLaser");
            }

            else
            {
                GameObject firedProjectile = Instantiate(projectile, gunTip.transform.position, gunTip.transform.rotation);
                firedProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);

            }

        }
	}

    IEnumerator FireLaser()
    {
        line.enabled = true;

        while(Input.GetButton("Fire1"))
        {
            Ray ray = new Ray(gunTip.transform.position, gunTip.transform.forward);
            RaycastHit hit;

            line.SetPosition(0, ray.origin);

            if (Physics.Raycast(ray, out hit, 100))
            {
                line.SetPosition(1, hit.point);
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.SendMessageUpwards("ApplyDamage", 100f);
                }

            }
            else
                line.SetPosition(1, ray.GetPoint(100));
            
            
            yield return null;
        }

        line.enabled = false;
    }
}
