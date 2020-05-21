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

    private int P = 0;
    public int S = 0;
    public int K = 0;

    public EnemyStatus enemystatus;

    //public float speed = 1000;
    // 初期化
    void Start()
    {
        
        target = GameObject.Find("Player").transform;
        StartCoroutine ("ChangeColor1");
    }

    void Update()
    {
        //ボスのHPを毎回取る
        eCount = enemystatus.enemy_hp;

    }

    IEnumerator ChangeColor1()
    {
        yield return new WaitForSeconds(0);

        // プレハブを元にオブジェクトを生成する
        Invoke("Call", 2f);
        Invoke("kaenud", 1f);
        
        Debug.Log("これはできてる");
        Debug.Log(eCount); //5

        //5秒停止
        yield return new WaitForSeconds(10);
        Debug.Log(eCount); //5

        if (eCount < 500)
        {
            if(P == 0)
            {
                StartCoroutine("ChangeColor4");
                P++;
            }

        }else{
            //もう一つのコルーチンを実行する
            //StartCoroutine("ChangeColor2");
            StartCoroutine("ChangeColor3");
        }
    }

    IEnumerator ChangeColor2()
    {

        // プレハブを元にオブジェクトを生成する
        Invoke("Call", 5f);

        //5秒停止
        yield return new WaitForSeconds(10);

        //もう一つのコルーチンを実行する
        StartCoroutine("ChangeColor3");
        Debug.Log(eCount); //5
    }

    IEnumerator ChangeColor3()
    {

        // プレハブを元にオブジェクトを生成する
        Invoke("yobi", 5f);

        //5秒停止
        yield return new WaitForSeconds(15);

        //もう一つのコルーチンを実行する
        StartCoroutine("ChangeColor1");
        Debug.Log(eCount); //5
    }

    IEnumerator ChangeColor4()
    {
        Debug.Log("よくここまで来たね");

        Invoke("SENP", 0);
        Invoke("mark", 0);

        yield return new WaitForSeconds(10);
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

    void SENP()
    {
        //火災旋風の呼び出し
        GameObject obj9 = (GameObject)Resources.Load("senpu");
        GameObject instance9 = (GameObject)Instantiate(obj9, new Vector3(0, -0.5f, 0), Quaternion.identity);

        Destroy(instance9, 10f);
        Invoke("mark", 5);
    }

    void mark()
    {
        //予測呼び出し（四角）
        GameObject yotyou1 = (GameObject)Resources.Load("yosokusikaku");
        GameObject yoyo1 = (GameObject)Instantiate(yotyou1, new Vector3(0, 1f, 0), Quaternion.identity);

        //予測呼び出し（丸）
        //GameObject yotyou2 = (GameObject)Resources.Load("yosokumaru");
        //GameObject yoyo2 = (GameObject)Instantiate(yotyou2, new Vector3(0, 1f, 0), Quaternion.identity);

        //Destroy(yoyo1,5f);
        Destroy(yoyo1, 5f);
    }

    void kaenud()
    {
        //右肩
        Transform RTATransform1 = GameObject.Find("Rightshoulder").transform;

        Vector3 Rotation33 = GameObject.Find("Rightshoulder").transform.localEulerAngles;
        Rotation33.x = 90.0f;
        Rotation33.y = 0.0f;
        Rotation33.z = 0.0f;
        S++;

        RTATransform1.localEulerAngles = Rotation33;

        Invoke("kaend", 10);
    }

    void kaend()
    {
        Transform RTATransform1 = GameObject.Find("Rightshoulder").transform;

        Vector3 Rotation33 = GameObject.Find("Rightshoulder").transform.localEulerAngles;
        Rotation33.x = 0.0f;
        Rotation33.y = 0.0f;
        Rotation33.z = 0.0f;

        RTATransform1.localEulerAngles = Rotation33;

    }
    void yobi()
    {
        //if (S < 18)
        //{
        //    transform.rotation = transform.rotation * Quaternion.Euler(5, 0, 0);
        //    Debug.Log(gameObject.transform.localEulerAngles);
        //    S++;
        //    //K = 0;            
        //}

        //if()

        //右肩
        Transform RTATransform1 = GameObject.Find("Rightshoulder").transform;

        Vector3 Rotation33 = GameObject.Find("Rightshoulder").transform.localEulerAngles;
        //if (Rotation33.x <90.0f)
        //if(S<18)
        //
            Rotation33.x = 75.0f;
            Rotation33.y = 50.0f;
            Rotation33.z = 0.0f;
            
        //}

        RTATransform1.localEulerAngles = Rotation33;

        //右腕
        Transform RTATransform2 = GameObject.Find("Rightarm").transform;
        Vector3 Rotation44 = GameObject.Find("Rightarm").transform.localEulerAngles;
        //if (Rotation33.x <90.0f)
        //if (S < 18)
        //{
            Rotation44.x = 0.0f;
            Rotation44.y = 0.0f;
            Rotation44.z = 50.0f;
            
        //}

        RTATransform2.localEulerAngles = Rotation44;

        //体をひねる
        Transform RTATransform3 = GameObject.Find("Body").transform;
        Vector3 Rotation55 = GameObject.Find("Body").transform.localEulerAngles;
        //if (Rotation33.x <90.0f)
        //if (S < 18)
        //{
        Rotation55.x = 0.0f;
        Rotation55.y = 12.0f;
        Rotation55.z = 0.0f;
        
        //}

        RTATransform3.localEulerAngles = Rotation55;

        Invoke("PaPa", 5);
    }

    void PaPa()
    {
        //右肩
        Transform RTATransform1 = GameObject.Find("Rightshoulder").transform;
        Vector3 trans1 = RTATransform1.position;
        Vector3 Rotation33 = GameObject.Find("Rightshoulder").transform.localEulerAngles;
        //if (Rotation33.x <90.0f)
        //if(S<18)
        //trans1.x += 0.0f;
        trans1.y = 9.0f;
        trans1.z = -2.0f;

        RTATransform1.localPosition = trans1;

        Rotation33.x = 40.0f;
        Rotation33.y = 0.0f;
        Rotation33.z = 0.0f;
        S++;
    
        RTATransform1.localEulerAngles = Rotation33;

        //右腕
        Transform RTATransform2 = GameObject.Find("Rightarm").transform;
        Vector3 Rotation44 = GameObject.Find("Rightarm").transform.localEulerAngles;
        //if (Rotation33.x <90.0f)
        //if (S < 18)
        //{
        Rotation44.x = 0.0f;
        Rotation44.y = 0.0f;
        Rotation44.z = 0.0f;
        S++;
        //}

        RTATransform2.localEulerAngles = Rotation44;

        Invoke("modos", 5);

        //体をひねる
        Transform RTATransform3 = GameObject.Find("Body").transform;
        Vector3 Rotation55 = GameObject.Find("Body").transform.localEulerAngles;
        //if (Rotation33.x <90.0f)
        //if (S < 18)
        //{
        Rotation55.x = 0.0f;
        Rotation55.y = -12.0f;
        Rotation55.z = 0.0f;

        RTATransform3.localEulerAngles = Rotation55;
    }

    void modos()
    {
        //右肩
        Transform RTATransform1 = GameObject.Find("Rightshoulder").transform;
        Vector3 trans1 = RTATransform1.position;
        Vector3 Rotation33 = GameObject.Find("Rightshoulder").transform.localEulerAngles;
        //if (Rotation33.x <90.0f)
        //if(S<18)
        trans1.x = -6.443245f;
        trans1.y = 12.20356f;
        trans1.z = 0.5219421f;

        RTATransform1.localPosition = trans1;

        Rotation33.x = 0.0f;
        Rotation33.y = 0.0f;
        Rotation33.z = 0.0f;
        S++;
        //}

        RTATransform1.localEulerAngles = Rotation33;

        //体をひねる
        Transform RTATransform3 = GameObject.Find("Body").transform;
        Vector3 Rotation55 = GameObject.Find("Body").transform.localEulerAngles;
        //if (Rotation33.x <90.0f)
        //if (S < 18)
        //{
        Rotation55.x = 0.0f;
        Rotation55.y = 0.0f;
        Rotation55.z = 0.0f;
        S++;
        //}

        RTATransform3.localEulerAngles = Rotation55;
    }



    //void FD()
    //{
    //    Destroy(this.gameObject);

    //}

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

}
