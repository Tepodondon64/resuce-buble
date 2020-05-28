using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossinYobidasi : MonoBehaviour {

  //  private Tossin tossin;
    private Rigidbody rb;
    private AttackMotion AM;

    void Start()
    {
     //   tossin = gameObject.GetComponent<Tossin>();
        AM = gameObject.GetComponent<AttackMotion>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("ai");
        if(collision.gameObject.tag == "Wall")
        {
            //突進エネミーの動きを止める
         //   tossin.enabled = false;
            
            //Debug.Log("ai");

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            //2秒後にReleaseメソッドを呼び出す
            Invoke("Release", 2.0f);
        }

        if(collision.gameObject.tag == "rebble")
        {
            //突進エネミーの動きを止める
          //  tossin.enabled = false;

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            //2秒後にReleaseメソッドを呼び出す
            Invoke("Release", 2.0f);
        }
    }

    void Release()
    {
        //tossin.enabled = true;
        //AM.enabled = false;
    }
}
