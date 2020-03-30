using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Destroy : MonoBehaviour {


    GameObject enemy; //オブジェクトを入れる変数名

    Broken script; //スプリクトを入れる変数名

	// Use this for initialization
	void Start () {

        enemy = GameObject.Find("Enemy"); //
        script = enemy.GetComponent<Broken>(); 

	}
	
	// Update is called once per frame
	void Update () {
        if (script.enemyhp <= 0)
        {
            Destroy(gameObject);

        }
	}
}
