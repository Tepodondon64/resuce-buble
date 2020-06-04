using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう

public class Flaming_Meter : MonoBehaviour {

    [SerializeField]
    private int flaming_num; // 炎上度の変数
    private float Fnum;
    ////
    Image image;
    [SerializeField]
    private Sprite No0, No1, No2, No3, No4, No5, No6, No7, No8, No9;

    [SerializeField]
    private bool Tensplace, Hundredplace; //１０の位の数字/１００の位の数字

    TimeScript timeScript;
    GameObject time;
    // 初期化
    void Start()
    {
        time = GameObject.Find("Time");//プレイヤーの情報を取得する
        //外部のスクリプトの情報を取得
        timeScript = time.GetComponent<TimeScript>();//TimeScriptスクリプトの取得
        image = this.GetComponent<Image>();

        flaming_num = ((int)timeScript.time);
        //flaming_num = timeScript.a;
    }

    // 更新
    void Update()
    {
        flaming_num = ((int)timeScript.time);
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    flaming_num += 1;
        //}
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    flaming_num -= 1;
        //}

        if (Tensplace == false && Hundredplace == false)    //1の位を取る
        {

            if (flaming_num % 10 == 0)
            {
                image.sprite = No0;
            }

            if (flaming_num % 10 == 1)
            {
                //image.material = No111111;
                image.sprite = No1;
            }

            if (flaming_num % 10 == 2)
            {
                image.sprite = No2;
            }
            if (flaming_num % 10 == 3)
            {
                image.sprite = No3;
            }
            if (flaming_num % 10 == 4)
            {
                image.sprite = No4;
            }
            if (flaming_num % 10 == 5)
            {
                image.sprite = No5;
            }
            if (flaming_num % 10 == 6)
            {
                image.sprite = No6;
            }
            if (flaming_num % 10 == 7)
            {
                image.sprite = No7;
            }
            if (flaming_num % 10 == 8)
            {
                image.sprite = No8;
            }
            if (flaming_num % 10 == 9)
            {
                image.sprite = No9;
            }
        }

        else if (Tensplace == true && Hundredplace == false)    //１０の位のみのフラグがtrueなら
        {

            if (flaming_num % 100 >= 0 && flaming_num % 100 <= 9)//(flaming_num / 10) % 10 
            {
                image.sprite = No0;
            }

           else if (flaming_num % 100 >= 10 && flaming_num % 100 <= 19)
            {
                image.sprite = No1;
            }

           else if (flaming_num % 100 >= 20 && flaming_num % 100 <= 29)
            {
                image.sprite = No2;
            }
           else if (flaming_num % 100 >= 30 && flaming_num % 100 <= 39)
            {
                image.sprite = No3;
            }
           else if (flaming_num % 100 >= 40 && flaming_num % 100 <= 49)
            {
                image.sprite = No4;
            }
           else if (flaming_num % 100 >= 50 && flaming_num % 100 <= 59)
            {
                image.sprite = No5;
            }
           else if (flaming_num % 100 >= 60 && flaming_num % 100 <= 69)
            {
                image.sprite = No6;
            }
           else if (flaming_num % 100 >= 70 && flaming_num % 100 <= 79)
            {
                image.sprite = No7;
            }
           else if (flaming_num % 100 >= 80 && flaming_num % 100 <= 89)
            {
                image.sprite = No8;
            }
           else if (flaming_num % 100 >= 90 && flaming_num % 100 <= 99)
            {
                image.sprite = No9;
            }
        }

        else if (Tensplace == false && Hundredplace == true)    //１００の位のみのフラグがtrueなら
        {

            if (flaming_num % 1000 >= 0 && flaming_num % 1000 <= 99)
            {
                image.sprite = No0;
            }

           else if (flaming_num % 1000 >= 100 && flaming_num % 1000 <= 199)
            {
                image.sprite = No1;
            }

           else if (flaming_num % 1000 >= 200 && flaming_num % 1000 <= 299)
            {
                image.sprite = No2;
            }
           else if (flaming_num % 1000 >= 300 && flaming_num % 1000 <= 399)
            {
                image.sprite = No3;
            }
           else if (flaming_num % 1000 >= 400 && flaming_num % 1000 <= 499)
            {
                image.sprite = No4;
            }
           else if (flaming_num % 1000 >= 500 && flaming_num % 1000 <= 599)
            {
                image.sprite = No5;
            }
           else if (flaming_num % 1000 >= 600 && flaming_num % 1000 <= 699)
            {
                image.sprite = No6;
            }
           else if (flaming_num % 1000 >= 700 && flaming_num % 1000 <= 799)
            {
                image.sprite = No7;
            }
           else if (flaming_num % 1000 >= 800 && flaming_num % 1000 <= 899)
            {
                image.sprite = No8;
            }
           else if (flaming_num % 1000 >= 900 && flaming_num % 1000 <= 999)
            {
                image.sprite = No9;
            }
        }
    }
}
