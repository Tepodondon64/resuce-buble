using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRange : MonoBehaviour {
   // private Transform Boss_obj;//
    public GameObject Player_obj;//プレイヤーのオブジェクトをここに入れる。
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 Boss_pos = this.gameObject.transform.position; //Bossのオブジェクト(自身のオブジェクト)の位置を取得
        Vector3 Player_pos = Player_obj.transform.position; //Playerのオブジェクトの位置を取得
        float dis = Vector3.Distance(Boss_pos, Player_pos); //PlayerとBossの間の距離を計算して出す
        Debug.Log("Distance : " + dis);//間の距離をデバッグログで出力する
	}
}
