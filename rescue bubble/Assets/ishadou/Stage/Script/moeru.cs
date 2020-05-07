using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moeru : MonoBehaviour {

    private int StayEnemy = 0;
    private float TimeOut = 1.0f;
    private float Timer = 0.0f;
    private int ObjectHP;


    public GameObject Fire;

    // Use this for initialization
    void Start () {
        if (this.gameObject.CompareTag("Easy"))
        {
            ObjectHP = 120;
        }
        if (this.gameObject.CompareTag("Normal"))
        {
            ObjectHP = 180;
        }
        if (this.gameObject.CompareTag("Hard"))
        {
            ObjectHP = 300;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            this.StayEnemy = 1;
        }
        if (other.gameObject.CompareTag("Burn")){
            this.StayEnemy = 1;
        }
    }

    // Update is called once per frame
    void Update () {
        if (StayEnemy == 1)
        {
            if (this.ObjectHP > 0)
            {
                Timer += Time.deltaTime;
                if (Timer >= TimeOut)
                {
                    Timer = 0.0f;
                    this.ObjectHP -= 30;
                    Debug.Log(ObjectHP);
                }
            }
            else
            {
                this.gameObject.tag = "Burn";
                GetComponent<Renderer>().material.color = Color.black;
                Fire.SetActive(true);
            }
        }
	}
}
