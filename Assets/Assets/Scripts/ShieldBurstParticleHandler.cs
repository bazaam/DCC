using UnityEngine;
using System.Collections;

public class ShieldBurstParticleHandler : MonoBehaviour {


    public GameObject target;


    // Use this for initialization
    void Start () {

        ParticleSystem particles = gameObject.GetComponent<ParticleSystem>();
        transform.LookAt(target.transform);
        particles.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
