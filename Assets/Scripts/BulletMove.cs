using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

     public float speed = 50f;
     float timer = 0f;
    float Ddelt = 2;

	// Use this for initialization
	void Start () {

		
	}

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.forward * speed * Time.deltaTime;

        timer += Time.deltaTime;
        if (timer >= 2)
        {
            Destroy(gameObject);

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = other.gameObject;
            //playera = transform.gameObject.name ("Player");
            player.GetComponent<Charecter_Controller>().changehealth(-Ddelt);
        }
    }
}

