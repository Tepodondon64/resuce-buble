using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireshoot : MonoBehaviour {

    public Transform target;//追いかける対象-オブジェクトをインスペクタから登録できるように
    public float speed = 0.05f;//移動スピード
    private Vector3 vec;
    int Time = 0;

    bool isCalledOnce = false;

    void Start()
    {
        target = GameObject.Find("Player").transform; //インスペクタから登録するのでいらない
        //this.transform.LookAt(target.transform);
    }

    void Update()
    {
        Invoke("Shoot", 2f);
        ////targetに向かって進む
        //transform.position += transform.forward * speed;
    }

    void Shoot()
    {
        if (Time <2) { 
        this.transform.LookAt(target.transform);
            isCalledOnce = true;
            Time++;
        }
        //targetに向かって進む
        transform.position += transform.forward * speed;

    }
}
