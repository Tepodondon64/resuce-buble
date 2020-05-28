using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Independence : MonoBehaviour {
    public float timer;
    public float parent_timer;

    private bool parentflg; //false:まだ、親子   true:親離れした


    private GameObject player;
    //スクリプトの取得//
    PlayerContoller_8 playerContoller_8;

    //public int count;
	// Use this for initialization
	void Start () {

        //timer = 0.7f;
        //parent_timer = 0.1f;
        parentflg = false;//最初は親子です。
        //gameObject.transform.parent = null; //親離れをする
        timer = timer * 60; //普通の秒数に直す

        parent_timer = parent_timer * 60; //普通の秒数に直す



        player = GameObject.Find("Player"); //プレイヤーをオブジェクトの名前から取得して変数に格納する

        //外部のスクリプトの情報を取得
        playerContoller_8 = player.GetComponent<PlayerContoller_8>();//PlayerContoller_8スクリプトの取得

        if (playerContoller_8.horizontalKeyflg != 0 || playerContoller_8.verticalKeyflg != 0)//プレイヤーに動きがあるか?
        {
            //動きがあったら、このパーティクルを削除
            gameObject.transform.parent = null; //親離れをする
            Destroy(gameObject);
        }
        else
        {
            //動きが無かったら特に何もない

        }

        
	}
	
	// Update is called once per frame
	void Update () {
        Time();

	}

    void Time()
    {
        if (parentflg == false) //親子関係が続いているとき
        {
            parent_timer -= 1;
            if (parent_timer <= 0)
            {
                parent_timer = 0;
                parentflg = true;
                gameObject.transform.parent = null; //親離れをする
            }
        }


        if (parentflg == true)  //親子が離れたときにtimerは動き始める
        {
            timer -= 1;
            //  Destroy(gameObject);
        }
        if (timer <= 0)
        {
            timer = 0;
            Destroy(gameObject, timer);
        }
    }
}
