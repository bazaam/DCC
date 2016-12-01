using UnityEngine;
using System.Collections;

public class ShieldAttack : MonoBehaviour
{
    public Transform ShieldBurst;
    public int radius;
    public float minimumHeight;
    public float attackFrequency;

    void Start()
    {
        StartCoroutine("ShieldUnderAttack");
    }
   

    Vector3 randomSpherePoint(int x0, int y0, int z0, int radius)
    {

        var y = minimumHeight - 1;

        Vector3 position = new Vector3();
        while (y < minimumHeight)
        {
            var u = Random.value;
            var v = Random.value;
            var theta = 2 * Mathf.PI * u;
            var phi = Mathf.Acos(2 * v - 1);
            var x = x0 + (radius * Mathf.Sin(phi) * Mathf.Cos(theta));
            y = y0 + (radius * Mathf.Sin(phi) * Mathf.Sin(theta));
            var z = z0 + (radius * Mathf.Cos(phi));

            
            position.x = x;
            position.y = y;
            position.z = z;

            Debug.Log(u);
            Debug.Log(v);

        }

        return position;
    }

    

    private IEnumerator ShieldUnderAttack ()
    {
        while(true)
        {
            yield return new WaitForSeconds(attackFrequency);
            Instantiate(ShieldBurst, randomSpherePoint(0, 0, 0, radius), Quaternion.identity);
        }
            

    }
}
