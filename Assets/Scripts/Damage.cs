using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public float Ddelt;
    public GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        //Deals Damage to the player
        if (other.gameObject.tag == "Player")
        {
            //playera = transform.gameObject.name ("Player");
            player.GetComponent<Charecter_Controller>().changehealth(-Ddelt);
        }
    }
}
