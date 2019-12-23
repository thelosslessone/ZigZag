using UnityEngine;
using System.Collections;

public class TriggerChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // pokrece se kada objekt col napusti trigger
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Invoke("FallDown", 0.5f);   // pokrece metodu FallDown nakon 0.5 sec
        }
    }

   

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 2f);   // unistava objekt nakon 2 sec
    }


}
