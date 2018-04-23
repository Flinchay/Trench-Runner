using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charecter_Controller : MonoBehaviour {

    public float movementSpeed = 5f;
    public float jumpHeight;

    bool isGrounded;
    bool isBlocked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
		
	}

    void Movement()
    {
        //Make the player move Foaward
        if(isBlocked == false)
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) & isGrounded)
        {
            transform.position += transform.up * jumpHeight * Time.deltaTime;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obsticle")
        {
             isBlocked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Obsticle")
        {
            isBlocked = false;
        }
    }


}
