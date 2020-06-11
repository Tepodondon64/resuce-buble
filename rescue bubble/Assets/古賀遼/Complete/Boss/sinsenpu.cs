using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinsenpu : MonoBehaviour {

    //public float speed = 1f;

    private float  count = 0;
    private int speed = 5;
    private int som = 0;
    // Use this for initialization
    void Start () {
        //Invoke("guru", 7);
        //InvokeRepeating("guru", 7, 1);
        StartCoroutine("sen1");
    }
	
	// Update is called once per frame
	void Update () {

        // transformを取得
        Transform myTransform = this.transform;

        //// transformを取得
        //Transform myTransform = this.transform;

        Vector3 loc = myTransform.localEulerAngles;

        loc.x = 0.0f;
        loc.y += 8.0f;
        loc.z = 0.0f;

        myTransform.localEulerAngles = loc;

    }

    IEnumerator sen1()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine("sen2");
    }

    IEnumerator sen2()
    {
        yield return new WaitForSeconds(0);

        Transform myTransform = this.transform;

        Vector3 hiro = myTransform.localScale;
        Vector3 pos = myTransform.position;

            hiro.x += 0.1f * speed + count;
            hiro.z += 0.1f * speed + count;

            myTransform.localScale = hiro;
            myTransform.localScale = hiro;

            yield return new WaitForSeconds(0.001f);

        if(som < 8)
        {
            StartCoroutine("sen2");
            som++;
        }

        //StartCoroutine("sen1");
        Invoke("weeei", 2);
        Invoke("owa", 4);
    }

    void weeei()
    {
        GameObject kabe1 = GameObject.Find("safety_block1");
        GameObject kabe2 = GameObject.Find("safety_block2");
        GameObject kabe3 = GameObject.Find("safety_block3");
        GameObject kabe4 = GameObject.Find("safety_block4");
        GameObject kabe5 = GameObject.Find("safety_block5");

        Destroy(kabe1);
        Destroy(kabe2);
        Destroy(kabe3);
        Destroy(kabe4);
        Destroy(kabe5);

    }

    void owa()
    {
        Destroy(this.gameObject);
    }

}
