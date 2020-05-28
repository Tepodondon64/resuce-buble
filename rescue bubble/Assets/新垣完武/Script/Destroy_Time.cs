using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Time : MonoBehaviour {
    public float time;
	// Use this for initialization
	void Start () {
        time = time * 60; //普通の秒数に直す
	}
	
	// Update is called once per frame
	void Update () {
		time -= 1;

        if (time <= 0)
        {
            time = 0;
            Destroy(gameObject, time);
        }
	}
}
