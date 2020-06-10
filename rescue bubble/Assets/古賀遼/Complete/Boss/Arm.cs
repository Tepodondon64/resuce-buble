using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour {
    private Vector3 kaiten = new Vector3(1, 0, 0);
    private KeyCode keycode;

    public int S = 0;
    public int K = 0;

        void Update()
    {
        Invoke("yobi", 5);
        Vector3 tmp = GameObject.Find("Righthand").transform.position;
        //GameObject.Find("Righthand").transform.position = new Vector3(tmp.x + 100, tmp.y, tmp.z);
        //transform.rotation = transform.rotation ;
        
    }

    void yobi()
    {
        if (S < 18)
        {
            transform.rotation = transform.rotation * Quaternion.Euler(5, 0, 0);
            Debug.Log(gameObject.transform.localEulerAngles);
            S++;
            //K = 0;            
        }

        if(S>18)
        {
            transform.rotation = transform.rotation * Quaternion.Euler(-5, 0, 0);
            Debug.Log(gameObject.transform.localEulerAngles);
            S++;
        }
        
        if(S == 18)
        {
            if (K == 1)
            {
                Invoke("FBB", 1);
                K++;
                //yield return new WaitForSeconds(2);
            }
            if (K == 2)
            {
                Invoke("FBB", 1);
                K++;
                //yield return new WaitForSeconds(2);
            }

            if (K == 3)
            {
                Invoke("FBB", 1);
                K++;
                //yield return new WaitForSeconds(2);
            }

            if (K == 4)
            {
                Invoke("FBB", 1);
                K++;
                //yield return new WaitForSeconds(2);
            }

            if (K == 5)
            {
                Invoke("FBB", 1);
                K++;
                //yield return new WaitForSeconds(2);
            }

        }

    }

    //void yobi2()
    //{
    //    if (K < 18)
    //    {
    //        transform.rotation = transform.rotation * Quaternion.Euler(-5, 0, 0);
    //        K++;
    //        //S = 0;
    //    }

    //    if(K >= 18)
    //    {
    //        Invoke("yobi",1);

    //        S = 0;
    //    }
    //}

    //void FBB()
    //{
    //    Vector3 tmp = GameObject.Find("Righthand").transform.position;
    //    //GameObject.Find("Righthand").transform.position = new Vector3(tmp.x + 100, tmp.y, tmp.z);
    //    //transform.rotation = transform.rotation ;
    //    GameObject obj = (GameObject)Resources.Load("Sphere");
    //    GameObject instance = (GameObject)Instantiate(obj, new Vector3(tmp.x, tmp.y, tmp.z - 10), Quaternion.identity);
        
    //}
}
