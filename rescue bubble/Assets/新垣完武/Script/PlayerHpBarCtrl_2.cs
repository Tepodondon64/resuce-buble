using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class PlayerHpBarCtrl_2 : MonoBehaviour {
    private PlayerHP_2 playerhp_2;  //PlayerHP
    private Shooting2 shooting2;  //Shooting2
    //たぶんこうやって宣言したらそこにある変数を使える？
    private Slider hpslider;       //スライダーを動かすための宣言　hpsliderというものを作りました
    private Slider chargeSlider;    //チャージスライダーを動かす

    private float Charge_Time;//チャージに必要な時間をここに格納する(初期化用の変数)

    //GameObject PlayerObject;

    void Start()
    {
        //敵のHPの値を参照するための儀式です
        //EnemyStatus(敵のステータス管理用に作ったスクリプトです)
        //tranform.root　これをやるとヒエラルキー上での親子かんでやりとりができるらしいです
        //それを指定しそこにあるEnemyStatusをゲットコンポーネントします

        //PlayerObject = GameObject.Find("Player");//プレイヤーのオブジェクトを入れる


        //shooting2 = PlayerObject.GetComponent<Shooting2>();//
        shooting2 = transform.root.GetComponent<Shooting2>();
        playerhp_2 = transform.root.GetComponent<PlayerHP_2>();


        //shooting2 = transform.root.GetComponent<Shooting2>();
        //


        //transform.Find("")でスライダーの名前指定で探します
        //たぶんtransform.Find  transform.root はオブジェクトが親子関係の時使えるものです
        //上で宣言したスライダー用の箱（hpslider)にSliderの機能をゲットコンポーネントします
        //今回スライダーの名前は、いじってないのでSliderのままです、必要に応じて名前かえてもいいかも
        hpslider = transform.Find("Slider").GetComponent<Slider>();
        //chargeSlider
        chargeSlider = transform.Find("Charge_Slider").GetComponent<Slider>();

        //hpslider.maxValue = playerhp_2.HP; //enemystatusスクリプトのenemy_hpの値をmaxValueの値に入れてからスタートする。
        ////chargeSlider.maxValue = shooting2.charge_time * 60;
        
        //chargeSlider.maxValue = shooting2.Charge_Time;

        //Charge_Time = shooting2.Charge_Time;


        hpslider.maxValue = playerhp_2.HP; //enemystatusスクリプトのenemy_hpの値をmaxValueの値に入れてからスタートする。
        //chargeSlider.maxValue = shooting2.charge_time * 60;

        //Charge_Time = shooting2.charge_time * 60;

        chargeSlider.maxValue = 60;

        Charge_Time = 60;

    }
    void Update()
    {
        //Charge_Time = shooting2.Charge_Time;
        //　カメラと同じ向きに設定
        transform.rotation = Camera.main.transform.rotation;//EnemyCanvas(HPゲージ)をMain Cameraに向かせる
        hpslider.value = playerhp_2.HP;//現在のHPゲージを描画する。
        chargeSlider.value =  Charge_Time - shooting2.charge_time;//現在のチャージゲージを描画する。
    }
}
