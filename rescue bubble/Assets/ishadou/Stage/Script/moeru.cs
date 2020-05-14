using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moeru : MonoBehaviour {

    private int StayEnemy = 0;
    private float TimeOut = 1.0f;
    private float Timer = 0.0f;
    private int ObjectHP;
    private int FireHP = 5;


    public GameObject Fire;
    private Vector3 scale;

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
        scale.x = 0.5f;
        scale.y = 0.5f;
        scale.z = 0.5f;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            this.StayEnemy = 1;
        }
        if (other.gameObject.tag == "Burn"){
            this.StayEnemy = 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "Burn")
        {
            if (other.gameObject.tag == "Bullet")
            {
                Debug.Log(FireHP);
                FireHP -= 1;
                if (FireHP > 0)
                {
                    Fire.transform.localScale = new Vector3(scale.x -= 0.1f, scale.y -= 0.1f, scale.z -= 0.1f);
                }
                else if(FireHP<=0)
                {
                    Fire.SetActive(false);
                    this.gameObject.tag = "lost";
                }
            }
            if (other.gameObject.tag == "ChargeBullet")
            {
                FireHP -= 10;
                Fire.SetActive(false);
                this.gameObject.tag = "lost";
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (this.gameObject.tag == "lost")
        {
            this.StayEnemy = 0;
        }
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
                GetComponent<CapsuleCollider>().enabled = false;
                this.gameObject.tag = "Burn";
                GetComponent<Renderer>().material.color = Color.black;
                Fire.SetActive(true);
            }
            this.StayEnemy = 0;
        }
    }
}
