using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Independence : MonoBehaviour {
    public float timer;
	// Use this for initialization
	void Start () {
        gameObject.transform.parent = null; //親離れをする
        timer = timer * 60; //普通の秒数に直す
	}
	
	// Update is called once per frame
	void Update () {

        timer -= 1;
        if (timer <= 0)
        {
            timer = 0;
            Destroy(gameObject, timer);
        }

	}
}
