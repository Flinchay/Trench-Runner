using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    float gunTimmer;
    bool timmerStart;

    public GameObject bulletEffect;

	// Use this for initialization
	void Start () {
        timmerStart = true;
		
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit) && gunTimmer >= 3)
        {
            print("RayCast hit: " + hit.collider.name);
            Instantiate(bulletEffect, gameObject.transform.position, gameObject.transform.rotation);
            gunTimmer = 0f;

        }
        Debug.DrawRay(transform.position, Vector3.forward, Color.green);

        if (timmerStart || gunTimmer >= 0)
        {
            gunTimmer += Time.deltaTime;
            
        }
		

	}
}
