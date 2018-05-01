using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public float Ddelt;


    private void OnTriggerEnter(Collider other)
    {
        //Deals Damage to the player
        if (other.gameObject.tag == "Player")
        {
            GameObject player = other.gameObject;
            player.GetComponent<Charecter_Controller>().changehealth(-Ddelt);
        }
    }
}
