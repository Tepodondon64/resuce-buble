using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;     //UIを使用可能にする

public class FadeScript : MonoBehaviour {

    
    public float time = 0;   //制限時間
    private bool stoptime_flg;//時間を止める

    public float speed = 0.01f;  //透明化の速さ
    float alfa;    //A値を操作するための変数
    float red, green, blue;    //RGBを操作するための変数

    void Start()
    {
        //float型からint型へCastし、String型に変換して表示
        //GetComponent<Text>().text = ((int)time).ToString();
        time = (int)time;
        stoptime_flg = false;   

        //Panelの色を取得
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }
	// Update is called once per frame
	void Update () {

        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        if (stoptime_flg == false)
        {
            time -= Time.deltaTime;
        }
            if (time < 0 && stoptime_flg == false)
            {  //制限時間が0になったら通る
            stoptime_flg = true;  //trueになったら
        }
        if (stoptime_flg == true)
        {
            //GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += speed;
        }
	}
}
