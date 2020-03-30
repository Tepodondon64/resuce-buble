using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    void Update()
    {


        // y軸を軸にして5度、x軸を軸にして5度、回転させるQuaternionを作成（変数をrotとする）
        Quaternion rot = Quaternion.Euler(0, 3, 3);
        // 現在の自信の回転の情報を取得する。
        Quaternion q = this.transform.rotation;
        // 合成して、自身に設定
        this.transform.rotation = q * rot;

        //左に移動
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-0.2f, 0.0f, -0.2f);

           rot = Quaternion.Euler(0, -45f, 0);//画像が右向きに傾き   (MAX:-90)

            //transform.rotation = Quaternion.FromToRotation(transform.position, transform.position);
            //transform.rotation = Quaternion.LookRotation(transform.position);  //ベクトルの情報をQuaternion.LookRotationに引き渡し回転量を取得しプレイヤーを回転させる
            //transform.rotation = Quaternion.LookRotation(向きたい方向,頭上方向（省略可） );
            //transform.rotation = Quaternion.FromToRotation(スタート, ゴール);
        }
        //右に移動
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(0.2f, 0.0f, 0.0f);
           // transform.localRotation = Quaternion.Euler(0, 45f, 0);//画像が右向きに傾き   (MAX:-90)
        }
        //前に移動
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0.0f, 0.0f, 0.2f);
           // transform.localRotation = Quaternion.Euler(0, 0, 0);//画像が右向きに傾き   (MAX:-90)
         
        }
        //後ろに移動
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, 0.0f, -0.2f);
           // transform.localRotation = Quaternion.Euler(0, 180f, 0);//画像が右向きに傾き   (MAX:-90)
        }
    }
}
