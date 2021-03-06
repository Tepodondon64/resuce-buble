﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class EnemyHpBarCtrl : MonoBehaviour
{


    private EnemyStatus enemystatus;  //EnemyStatus(前に作った敵キャラのスクリプトです
    //たぶんこうやって宣言したらそこにある変数を使える？
    private Slider hpslider;       //スライダーを動かすための宣言　hpsliderというものを作りました

    //public Broken broken;
   //public Broken broken;
    

    //private Slider hp_slider;


  //  public float enemyhp_1;  //受け皿
   // public float nowenemyhp = 5;


    void Start()
    {
        //Debug.Log("StartOK");
        //敵のHPの値を参照するための儀式です
        //EnemyStatus(敵のステータス管理用に作ったスクリプトです)
        //tranform.root　これをやるとヒエラルキー上での親子かんでやりとりができるらしいです
        //それを指定しそこにあるEnemyStatusをゲットコンポーネントします
        enemystatus = transform.root.GetComponent<EnemyStatus>();

        //transform.Find("")でスライダーの名前指定で探します
        //たぶんtransform.Find  transform.root はオブジェクトが親子関係の時使えるものです
        //上で宣言したスライダー用の箱（hpslider)にSliderの機能をゲットコンポーネントします
        //今回スライダーの名前は、いじってないのでSliderのままです、必要に応じて名前かえてもいいかも
        hpslider = transform.Find("Slider").GetComponent<Slider>();

        hpslider.maxValue = enemystatus.enemy_hp; //enemystatusスクリプトのenemy_hpの値をmaxValueの値に入れてからスタートする。
    }
    void Update()
    {
       // Debug.Log("UpdateOK");
        //　カメラと同じ向きに設定
        transform.rotation = Camera.main.transform.rotation;//EnemyCanvas(HPゲージ)をMain Cameraに向かせる
        hpslider.value = enemystatus.enemy_hp;//現在のHPゲージを描画する。
    }
}
