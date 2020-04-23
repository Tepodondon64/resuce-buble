using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutText : MonoBehaviour
{

    public float speed = 0.01f;
    public float timer = 0;
    float alfa = 1;
    float red, green, blue;

    public GameObject Floor;

    // Use this for initialization
    void Start()
    {
        red = GetComponent<Text>().color.r;
        green = GetComponent<Text>().color.g;
        blue = GetComponent<Text>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().color = new Color(red, green, blue, alfa);

        if (timer >= 1)
        {
            timer = 1;
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
