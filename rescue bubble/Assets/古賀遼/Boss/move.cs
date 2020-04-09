using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    private Vector3 vec;
    public Transform target;
    public float speed = 0.05f;//移動スピード

    private int a = 0;
    private int b = 0;
    // Use this for initialization
    void Start () {
        //Vector3 vec = transform.position;
        target = GameObject.Find("Player").transform;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            InvokeRepeating("massugu", 1, 0.01f);
        }
    }

    void massugu()
    {
        if (transform.position.z >= -10f) { 
        this.transform.position += new Vector3(0f, 0f, -1f);
            //this.transform.Translate(Vector3.right * Time.deltaTime);
            //transform.position += transform.forward * speed;
            a++;
            this.transform.LookAt(target.transform);
        }

        if (a == 10)
        {
            InvokeRepeating("modoru", 1,0.01f);
            CancelInvoke("massugu");
        }
    }

    void modoru()
    {
        if (transform.position.z <= 0f)
        {
            this.transform.position += new Vector3(0f, 0f, 1f);
            //this.transform.Translate(Vector3.right * Time.deltaTime);
            
            b++;
        }

        if(b == 10)
        {
            transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 0));
            CancelInvoke("modoru");
            a = 0;
            b = 0;
        }

    }
}
