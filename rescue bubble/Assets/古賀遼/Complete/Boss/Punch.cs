using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {

    public float speed = 0.05f;//移動スピード
    public Transform target;

    // Use this for initialization
    void Start () {
        target = GameObject.Find("Player ").transform;
        //this.transform.LookAt(target.transform);
        
    }
	
	// Update is called once per frame
	void Update () {
        //this.transform.LookAt(target.transform);
        Invoke("shoot", 3);
    }

    void shoot()
    {
        this.transform.LookAt(target.transform);

        Transform myTransform = this.transform;
        Vector3 Pos = myTransform.position;

        //Pos.x += 0.50f;
        //Pos.y -= 0.50f;
        //Pos.z += 0.50f;

        transform.position += transform.forward * speed;
        //myTransform.position = Pos;

    }
}
