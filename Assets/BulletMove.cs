using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

     public float speed = 50f;
     float timer = 0f;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += transform.forward * speed * Time.deltaTime;

        timer+= Time.deltaTime;
        if(timer >= 2)
        {
            Destroy(gameObject);
            
        }
	}
}
