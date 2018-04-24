using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour {

    public bool transitioning;
    Color c1;
    Color c0;
    float fadetimer;
    public void startFade()
    {
        transitioning = true;
    }
	// Use this for initialization
	void Start () {
        c1 = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
        c0 = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, -1);
    }
	
	// Update is called once per frame
	void Update () {
        if (transitioning)
        {
            fadetimer += (Time.deltaTime / 0.5f);
            GetComponent<Image>().color = Color.Lerp(c1, c0, fadetimer);
        }

        if (fadetimer >= .5f)
        {
            transitioning = false;
            fadetimer = 0;
        }
	}
}
