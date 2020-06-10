using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Destroy : MonoBehaviour {

    GameObject BossD;
    public int FBHP = 3;
    private void Start()
    {
        Invoke("Destroy", 10);
        BossD = GameObject.Find("MainChar");//タイムの情報を取得する
    }

    void Update()
    {
        if (BossD == null)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Map")
        {
            Destroy(this.gameObject);
        }


    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
