using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXdir : MonoBehaviour {

    public float length = 4.0f;    //移動する振幅
    public float speed = 2.0f;      //移動するスピード　大きくすると早くなる
    private Vector3 startPos;   //ゲーム開始時のポジションを入れる変数
    public bool negarive = false;   //空のチェックボックスが表示されます

   // private Rigidbody rB;
	// Use this for initialization
	void Start () {
        startPos = this.transform.position; //ゲーム開始時の位置

       // rB = GetComponent<Rigidbody>();
        if (negarive == true)
        {
            speed = -speed;
        }
	}

    void FixedUpdate()
    {
        transform.position = new Vector3((Mathf.Sin((Time.time) * speed) * length + startPos.x), startPos.y, startPos.z);
      // rB.MovePosition (new Vector3((Mathf.Sin((Time.time) * speed) * length + startPos.x), startPos.y, startPos.z));
        //Mathf.Sin()でフレーム毎の角度変化による値を出します。それに振幅をかけた値をstartPosのx座標に足します。
    }

	// Update is called once per frame
	void Update () {
		
	}
}
