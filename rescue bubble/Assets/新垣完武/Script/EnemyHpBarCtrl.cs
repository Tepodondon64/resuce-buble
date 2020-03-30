using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class EnemyHpBarCtrl : MonoBehaviour
{

    //public Broken broken;
   public Broken broken;
    

    private Slider hp_slider;


    public float enemyhp_1;  //受け皿
   // public float nowenemyhp = 5;


    void Start()
    {
        // スライダーを取得する
        hp_slider = GameObject.Find("Slider").GetComponent<Slider>();//

       // hp_slider = GetComponent<Slider>();//起動問題無し

       //broken = hp_slider.GetComponent<Broken>(); //くそ
        enemyhp_1 = broken.enemyhp;


        hp_slider.maxValue = enemyhp_1 ; //Brokenスクリプトのenemyhpの値をmaxValueの値に入れてからスタートする。

    }
    void Update()
    {
      //  Debug.Log(enemyhp_1);//10
        //float enemyhp;
        enemyhp_1 = broken.enemyhp;


        // HPゲージに値を設定
       hp_slider.value = enemyhp_1;
       //hp_slider.value = 10;
    }
}
