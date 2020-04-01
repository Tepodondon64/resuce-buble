using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{

    public Transform target;
    public int BOSSHP = 10;
    bool witch = false;

    //public float speed = 1000;
    // 初期化
    void Start()
    {
        target = GameObject.Find("Player").transform;


    }
    void Update()
    {
        // ResourcesフォルダからSphereプレハブのオブジェクトを取得
        GameObject obj = (GameObject)Resources.Load("Sphere");
        //if (Input.GetKeyDown(KeyCode.Z))
            if (BOSSHP >= 7)
            {
            // プレハブを元にオブジェクトを生成する
            //Invoke("Call",5f);
            if (transform.position.z > 0)
            {
                InvokeRepeating("Call", 1, 5);
                enabled = false;
            }
            //Vector3 force;
            //force = this.gameObject.transform.forward * speed;
            //instance.GetComponent<Rigidbody>().AddForce(force);
            //Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
            //Vector3 force = new Vector3(10.0f, 0.0f, 0.0f);    // 力を設定
            //rb.AddForce(force);  // 力を加える
        }

    }

    void Call()
    {
        
        Invoke("FB1", 0.8f);
        Invoke("FB2", 1f);
        Invoke("FB3", 1.2f);
        Invoke("FB4", 1.4f);
        Invoke("FB5", 1.6f);
        //witch = true;
        //enabled = false;
       
    }

    void FB1()
    {
        GameObject obj = (GameObject)Resources.Load("Sphere");
        GameObject instance = (GameObject)Instantiate(obj, new Vector3(20.0f, 10.0f, 10.0f), Quaternion.identity);
    }
    void FB2()
    {
        GameObject obj = (GameObject)Resources.Load("Sphere");
        GameObject instance = (GameObject)Instantiate(obj, new Vector3(10.0f, 10.0f, 10.0f),Quaternion.identity);
    }

    void FB3()
    {
        GameObject obj = (GameObject)Resources.Load("Sphere");
        GameObject instance = (GameObject)Instantiate(obj, new Vector3(0.0f, 10.0f, 10.0f), Quaternion.identity);
    }

    void FB4()
    {
        GameObject obj = (GameObject)Resources.Load("Sphere");
        GameObject instance = (GameObject)Instantiate(obj, new Vector3(-10.0f, 10.0f, 10.0f), Quaternion.identity);
    }

    void FB5()
    {
        GameObject obj = (GameObject)Resources.Load("Sphere");
        GameObject instance = (GameObject)Instantiate(obj, new Vector3(-20.0f, 10.0f, 10.0f), Quaternion.identity);
        //witch = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet") {
            Debug.Log("Hit"); // ログを表示する
            BOSSHP--;
        }
    }
}