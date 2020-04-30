using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMotion : MonoBehaviour {

    public float span = 1f;
    public float span2 = 2f;
    private float currentTime = 0f;
    public Material material;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > span)
        {
            this.GetComponent<Renderer>().material = this.material;
        }

        if (currentTime > span2)
        {
            this.GetComponent<Renderer>().material.color = Color.white;
            currentTime = 0f;
        }
    }
}
