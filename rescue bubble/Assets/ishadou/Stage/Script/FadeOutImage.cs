using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutImage : MonoBehaviour {

    public float speed = 0.01f;
    public float timer = 0;
    float alfa=1;
    float red, green, blue;

    public GameObject Floor;

    public bool FadeEndflg; //timerが1になったらtrueになる

	// Use this for initialization
	void Start () {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        FadeEndflg = false;
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);

        if (timer >= 1)
        {
            timer = 1;
            FadeEndflg = true;
            if (alfa == 0)
            {
                alfa = 0;
            }
            else
            {
                alfa -= speed + 0.01f;
            }
        }
        else
        {
            timer += speed;
        }
    }
}
