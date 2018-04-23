using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charecter_Controller : MonoBehaviour {
    //speed
    public float movementSpeed;
    public float MaxSpeed;
    //Jump & health
    public float jumpHeight;
    public float health = 100f;
    //stanima
    public float stanima;
    public float MaxStanima;
    private float MinStanima = 1;
    //is it true
    bool isGrounded;
    bool isBlocked;
    bool StanimaTim;

    Rigidbody rb;
    //UI
    public Text healthTxt;
    public Slider StanimaSlider;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        stanima = MaxStanima;
        movementSpeed = MaxSpeed;
        StanimaSlider.maxValue = MaxStanima;
        StanimaSlider.minValue = MinStanima;
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        Death();
        StanimaTimer();

        healthTxt.text = ("Health" + health);
        StanimaSlider.value = stanima;

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
            //transform.position += transform.up * jumpHeight * Time.deltaTime;
            rb.AddForce(transform.up * jumpHeight );
            print("Jump");
        }

        //Sprint & Stanima
        if (Input.GetKeyDown(KeyCode.LeftShift) & stanima >= 3)
        {
            movementSpeed = MaxSpeed * 1.5f;
            StanimaTim = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || stanima <= MinStanima)
        {
            movementSpeed = MaxSpeed;
            StanimaTim = false;
            stanima = MaxStanima;
        }

    }

    void Death()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void StanimaTimer()
    {
        if (StanimaTim == true)
        {
            stanima -= Time.deltaTime;
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
