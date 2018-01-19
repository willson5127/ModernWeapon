﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEffect : MonoBehaviour {

    [SerializeField] Transform RayPoint;

    private LineRenderer linE;

	// Use this for initialization
	void Start () {
        linE = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void SpawnDecal (RaycastHit hit, GameObject prefab) {

        GameObject spawnedDecal = GameObject.Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));

        spawnedDecal.transform.SetParent(hit.collider.transform);
	}

    public void UpdateLaser(float distance)
    {
        Transform tShoot = RayPoint;
        if (linE != null)
        {
            linE.SetPosition(0, RayPoint.position);
            linE.SetPosition(1, RayPoint.position + RayPoint.forward * distance);
        }
    }
}
