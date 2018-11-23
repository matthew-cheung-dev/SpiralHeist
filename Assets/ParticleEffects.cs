﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffects : MonoBehaviour
{
    public ParticleSystem sparks;
    public CarMovement carController;
    public MeshCollider boxCollider;

	// Use this for initialization
	void Start ()
    {
        carController = GetComponent<CarMovement>();
	}

    private void LateUpdate()
    {
        //GameObject[] allParticles = GameObject.FindGameObjectsWithTag("Spark");

        //foreach (GameObject obj in allParticles)
        //{
        //    ParticleSystem ps = obj.GetComponent<ParticleSystem>();
        //    if (!ps.IsAlive()|| obj == null)
        //        Destroy(obj);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if(carController.carVelocity > 0)
            {
                Vector3 pos = contact.point;
                Quaternion rot = Quaternion.FromToRotation(Vector3.back, contact.normal);
                ParticleSystem temp = Instantiate(sparks, pos, rot);
                temp.transform.parent = transform;
                temp.loop = false;
                //temp.Emit(1);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (carController.carVelocity > 0)
            {
                Vector3 pos = contact.point;
                Quaternion rot = Quaternion.FromToRotation(Vector3.back, contact.normal);
                ParticleSystem temp = Instantiate(sparks, pos, rot);
                temp.transform.parent = transform;
                temp.loop = false;
                //temp.Emit(1);
            }
        }
    }
}
