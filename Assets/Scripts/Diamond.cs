using UnityEngine;
using System.Collections;

public class Diamond : MonoBehaviour {

    public GameObject particle;
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {

            GameObject partic = Instantiate(particle, this.transform.position, Quaternion.identity) as GameObject;
            StatsManager.instance.score += 3;
            Destroy(gameObject);
            Destroy(partic, 2f);
        }
    }
}
