using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameKai : MonoBehaviour {

    public Transform target;

    // Use this for initialization
    void Start () {

        target = GameObject.Find("Player").transform;
        this.transform.LookAt(target.transform);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
