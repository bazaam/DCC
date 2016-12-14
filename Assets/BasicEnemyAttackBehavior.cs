using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicEnemyAttackBehavior : MonoBehaviour {

    public float moveSpeed;

    GameObject player;
    GameObject target;
    GameObject[] baseDestructibles;
    
    Transform GetClosestObject (GameObject[] potentialTargets) {
        
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in potentialTargets)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }

        return bestTarget;
    }

    void FindNewTarget()
    {
        target = GetClosestObject(baseDestructibles).gameObject;
        transform.LookAt(target.transform);
    }

	// Use this for initialization
	void Start () {

        baseDestructibles = GameObject.FindGameObjectsWithTag("BaseDestructible");
        FindNewTarget();
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
