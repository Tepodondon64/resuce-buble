using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    public Transform target;
    public int BOSSHP = 10;
    
    bool witch = false;

    int eCount;

    public EnemyStatus enemystatus;

    //public float speed = 1000;
    // 初期化
    void Start()
    {
        //ボスのHPをいれる変数
        
        //EnemyStatusの数値を取得
        eCount = enemystatus.enemy_hp;
        Debug.Log(eCount); //5
        target = GameObject.Find("Player").transform;
        //Vector3 MSPO = GameObject.Find("MS").transform.position;
        StartCoroutine ("ChangeColor1");
    }

    IEnumerator ChangeColor1()
    {
        yield return new WaitForSeconds(0);

        //// プレハブを元にオブジェクトを生成する 火炎放射
        //GameObject obj = (GameObject)Resources.Load("Flameradiation");
        //GameObject instance = (GameObject)Instantiate(obj,new Vector3(-6.36f, 9.01f, -4f), Quaternion.identity);

        // プレハブを元にオブジェクトを生成する
        Invoke("Call", 5f);
        Debug.Log("これはできてる");

        //5秒停止
        yield return new WaitForSeconds(10);

        Debug.Log(eCount); //5
        //もう一つのコルーチンを実行する
        StartCoroutine("ChangeColor2");
    }

    IEnumerator ChangeColor2()
    {

        // プレハブを元にオブジェクトを生成する
        Invoke("Call", 5f);

        //5秒停止
        yield return new WaitForSeconds(10);

        //もう一つのコルーチンを実行する
        StartCoroutine("ChangeColor1");
        Debug.Log(eCount); //5
    }

    IEnumerator ChangeColor3()
    {

        // プレハブを元にオブジェクトを生成する
        Invoke("Call", 1f);

        //10秒停止
        yield return new WaitForSeconds(4);

        //もう一つのコルーチンを実行する
        StartCoroutine("ChangeColor1");

    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        // プレハブを元にオブジェクトを生成する
    //        GameObject obj = (GameObject)Resources.Load("Flameradiation");
    //        GameObject instance = (GameObject)Instantiate(obj, new Vector3(-5.18f, 45.5f, -4f), Quaternion.identity);
    //    }

    //    if (Input.GetKeyDown(KeyCode.B))
    //    {
    //        // プレハブを元にオブジェクトを生成する
    //        Invoke("Call", 1f);
    //    }




    ////if (target.transform.position.z < 10f)
    ////{
    ////    InvokeRepeating("Call", 1, 5);
    ////    enabled = false;
    ////}

    ////if(target.transform.position.z > -10f)
    ////{
    ////    InvokeRepeating("Call2", 1, 5);
    ////    enabled = false;
    ////}

    ////if (target.transform.position.z < -20f)
    ////{
    ////    //InvokeRepeating("Firing", 1, 5);

    ////    GameObject obj2 = (GameObject)Resources.Load("Flameradiation");
    ////    GameObject instance = (GameObject)Instantiate(obj2, new Vector3(-6.9499f, 6.3128f, -3.09f), Quaternion.identity);
    ////    enabled = false;
    ////    Invoke("FD", 4);
    ////}
    ////}

    void Call()
    {
        //if (target.transform.position.z > 0f)
        //{
        if (BOSSHP >= 7)
        {

            Invoke("FB1", 2f);
            Invoke("FB1", 3f);
            Invoke("FB1", 4f);
            Invoke("FB1", 5f);
            Invoke("FB1", 6f);
            //witch = true;
            //enabled = false;
        }
        //}

    }

    void FB1()
    {
        Vector3 tmp = GameObject.Find("Righthand").transform.position;
        GameObject obj = (GameObject)Resources.Load("SFB");
        GameObject instance = (GameObject)Instantiate(obj,tmp, Quaternion.identity);
    }
    //void FB2()
    //{
    //    GameObject obj = (GameObject)Resources.Load("SFB");
    //    GameObject instance = (GameObject)Instantiate(obj, new Vector3(10.0f, 30.0f, -11.3f), Quaternion.identity);
    //}

    //void FB3()
    //{
    //    GameObject obj = (GameObject)Resources.Load("SFB");
    //    GameObject instance = (GameObject)Instantiate(obj, new Vector3(0.0f, 30.0f, -11.3f), Quaternion.identity);
    //}

    //void FB4()
    //{
    //    GameObject obj = (GameObject)Resources.Load("SFB");
    //    GameObject instance = (GameObject)Instantiate(obj, new Vector3(-10.0f, 30.0f, -11.3f), Quaternion.identity);
    //}

    //void FB5()
    //{
    //    GameObject obj = (GameObject)Resources.Load("SFB");
    //    GameObject instance = (GameObject)Instantiate(obj, new Vector3(-20.0f, 30.0f, -11.3f), Quaternion.identity);
    //    //witch = false;
    //}

    void FD()
    {
        Destroy(this.gameObject);

    }

    //void Call2()
    //{
    //    if (target.transform.position.z > -10f)
    //    {
    //        Invoke("FI", 0.8f);
    //    }
    //}

    //void FI()
    //{
    //    GameObject obj = (GameObject)Resources.Load("Flameradiation");
    //    GameObject instance = (GameObject)Instantiate(obj, new Vector3(0.0f, 5.0f, 10.0f), Quaternion.identity);

    //}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Untagged")
        {
            Debug.Log("Hit"); // ログを表示する
            BOSSHP--;
        }

        if (BOSSHP == 0)
        {
            Destroy(this.gameObject);
        }
    }


}
