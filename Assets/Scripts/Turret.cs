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
        print(gunTimmer);
       /* if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit) && gunTimmer >= 1.5f)
        {
            //print("RayCast hit: " + hit.collider.name);
            Instantiate(bulletEffect, gameObject.transform.position, gameObject.transform.rotation);
            //gunTimmer = 0f;
            timmerStart = false;
            print("hi");

        }*/

        if (gunTimmer >= 1.5f)
        {
            Instantiate(bulletEffect, gameObject.transform.position, gameObject.transform.rotation);
            
        }

        Debug.DrawRay(transform.position, Vector3.forward, Color.green);

        if (gunTimmer >= 1.6f)
        {
            gunTimmer = 0;
        }

        if (timmerStart)
        {
            gunTimmer += Time.deltaTime;
            print("ggg");
            
        }
		

	}
}
