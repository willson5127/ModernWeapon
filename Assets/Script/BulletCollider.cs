using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour {

    [SerializeField] float MissTime;
    [SerializeField] CapsuleCollider collideR;
    private float timeR;

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
        timeR += Time.deltaTime;
        OnTriggerEnter(collideR);
        if(timeR > MissTime)
        {
            print("miss");
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != null)
        {
            print(other.gameObject.tag);
            if (other.gameObject.tag == "Wall")
                Destroy(this.gameObject);
        }
    }
}
