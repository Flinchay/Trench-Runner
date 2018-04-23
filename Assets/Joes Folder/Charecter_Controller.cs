using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charecter_Controller : MonoBehaviour {

    public float movementSpeed = 5f;
    public float jumpHeight;
    public float health = 100;

    bool isGrounded;
    bool isBlocked;

    public Text healthTxt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        Death();

        healthTxt.text = ("Health" + health);
	
	}

    void Movement()
    {
        //Make the player move Foaward
        if(isBlocked == false)
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }

        //Makes the player 'Jump'
        if (Input.GetKeyDown(KeyCode.Space) & isGrounded)
        {
            transform.position += transform.up * jumpHeight * Time.deltaTime;
        }

    }

    void Death()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
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
