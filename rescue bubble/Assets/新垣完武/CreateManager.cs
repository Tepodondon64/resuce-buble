using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{

    public Transform target;

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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // プレハブを元にオブジェクトを生成する
            GameObject instance = (GameObject)Instantiate(obj,new Vector3(20.0f, 10.0f, 10.0f),Quaternion.identity);
            Invoke("FB2", 1f);
            Invoke("FB3", 1.2f);
            Invoke("FB4", 1.4f);
            Invoke("FB5", 1.6f);
            //Vector3 force;
            //force = this.gameObject.transform.forward * speed;
            //instance.GetComponent<Rigidbody>().AddForce(force);
            //Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
            //Vector3 force = new Vector3(10.0f, 0.0f, 0.0f);    // 力を設定
            //rb.AddForce(force);  // 力を加える
        }

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
    }
}