using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Charecter_Controller : MonoBehaviour {
    //speed
    public float movementSpeed;
    public float MaxSpeed;
    //Jump & health
    public float jumpHeight;
    private float health = 100f;
    //stanima
    public float stanima;
    public float MaxStanima;
    private float MinStanima = 1;
    //is it true
    bool isGrounded;
    bool isBlocked;
    bool StanimaTim;

    public CharacterController controller;
    Rigidbody rb;
    //UI
    public Text healthTxt;
    public Slider StanimaSlider;
    public GameObject DialogeBox;
    public Image damageEffect;


	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        stanima = MaxStanima;
        movementSpeed = MaxSpeed;
        StanimaSlider.maxValue = MaxStanima;
        StanimaSlider.minValue = MinStanima;
        isBlocked = true;
    }
	
	// Update is called once per frame
	void Update () {

        GroundedCheck();
        Movement();
        Death();
        StanimaTimer();

        healthTxt.text = ("Health" + health);
        StanimaSlider.value = stanima;

 
    }

    void Movement()
    {

        GroundedCheck();

        if (!isGrounded)
            controller.SimpleMove(Physics.gravity * Time.deltaTime);

        Vector3 velocity = new Vector3();
        //Make the player move Foaward
        if(isBlocked == false)
        {
            //transform.position += transform.forward * Time.deltaTime * movementSpeed;
            //controller.SimpleMove(transform.forward * movementSpeed * Time.deltaTime);
            velocity += transform.forward * movementSpeed;
        }

        //Makes the player 'Jump'
        if (Input.GetKeyDown(KeyCode.Space) & isGrounded)
        {
            //controller.SimpleMove(transform.up * jumpHeight);
            velocity += transform.up * jumpHeight;
            //rb.AddForce(transform.up * jumpHeight );
            print("Jump");
        }

        controller.Move(velocity * Time.deltaTime);


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
    public void changehealth(float amount)
    {
        health += amount;
        damageEffect.GetComponent<FadeImage>().transitioning = true;
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

  /*  private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            print("YES");
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
            print("NO");
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obsticle")
        {
             isBlocked = true;
            print("blocked");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Obsticle")
        {
            isBlocked = false;
            print("NotBLocked");
        }
    }

    public void StartLvl()
    {
        isBlocked = false;
        DialogeBox.SetActive(false);
    }

    void GroundedCheck()
    {
        isGrounded = Physics.Raycast(transform.position - transform.up * controller.height / 2.0f, -Vector3.up, 0.25f);
    }

}
