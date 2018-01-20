using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {

    [SerializeField] GameObject Shoot;
    [SerializeField] GameObject Bullet;
    [SerializeField] GunEffect guneffect;
    [SerializeField] float ShootForce = 10000;
    [SerializeField] float FireRange = 100;
    [SerializeField] float FireRate = 0.15f;
    //[SerializeField] int FireDamage = 100;

    private string fireMode = "Auto";
    private double fireInterval;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("FireModeShift"))
        {
            if (fireMode == "Auto")
                fireMode = "Simi";
            else
                fireMode = "Auto";
        }

        switch (fireMode)
        {
            case "Auto":
                if (Input.GetButton("FireTrigger") && Time.time > fireInterval)
                    Fire();
                guneffect.UpdateLaser(FireRange);
                break;
            case "Simi":
                if (Input.GetButtonDown("FireTrigger") && Time.time > fireInterval)
                    Fire();
                guneffect.UpdateLaser(FireRange);
                break;
        }
        
		
	}
    private void Fire()
    {
        fireInterval = Time.time + FireRate;

        Vector3 rayOrign = Shoot.transform.position;
        RaycastHit hiT;

        if (Physics.Raycast(rayOrign, Shoot.transform.forward, out hiT, FireRange))
        {
            print(hiT.point);
            Transform tShoot = Shoot.transform;
            GameObject clonE = Instantiate(Bullet, tShoot.position, tShoot.rotation);
            clonE.GetComponent<Rigidbody>().AddForce(tShoot.forward * ShootForce);
        }
        else
        {
            print("void");
            Transform tShoot = Shoot.transform;
            GameObject clonE = Instantiate(Bullet, tShoot.position, tShoot.rotation);
            clonE.GetComponent<Rigidbody>().AddForce(tShoot.forward * ShootForce);
        }

        guneffect.GunShoot();
    }


}
