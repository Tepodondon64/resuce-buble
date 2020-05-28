using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour {

    private float time = 120;   //制限時間
    private bool stoptime_flg;//時間を止める
    private GameObject player;  //プレイヤーのオブジェクトを入れる変数。

    PlayerHP_2 playerHP_2;//スクリプトの取得//

    public bool timeEndflg; //制限時間が0になったらtrueになる。PlayerHP_2スクリプトと繋げる

    //public GameObject player; //

	void Start () {
        //timeの初期値120を表示
        //float型からint型へCastし、String型に変換して表示
        GetComponent<Text>().text = ((int)time).ToString();
        player = GameObject.Find("Player");//プレイヤーの情報を取得する
        //外部のスクリプトの情報を取得
        playerHP_2 = player.GetComponent<PlayerHP_2>();//PlayerHP_2スクリプトの取得
        timeEndflg = false; 
	}
	
	void Update () {
        if ((/*Input.GetButtonDown("Fire3") ||*/ Input.GetKeyDown(KeyCode.T)))//キーボードのTキーを押すと時間を操れる
        { 

            if(stoptime_flg == false)
            {
                stoptime_flg = true;//時間を止める
            }
            else if (stoptime_flg == true)
            {
                stoptime_flg = false;//時間が動きだす
            }
        }

        if (stoptime_flg == false)
        {
            //1秒に1ずつ減らしていく
            time -= Time.deltaTime;
        }
        if (time < 0){  //制限時間が0になったら通る
            timeEndflg = true;  //trueになったら
            // 2.0秒後に「GoToGameOver()」メソッドを実行する。
            Invoke("GoToGameOver", 3.0f);
        }

        if ((/*Input.GetButtonDown("Fire3") ||*/ Input.GetKeyDown(KeyCode.K)))//キーボードのKキーを押すと時間を操れる
        {
            time = 5;
        }

        //マイナスは表示しない
        if (time < 0) time = 0;
        GetComponent<Text>().text = ((int)time).ToString();
	}
    void GoToGameOver()
    {

        if (playerHP_2.Stage1 == true && playerHP_2.Stage2 == false && playerHP_2.Stage3 == false && playerHP_2.BossStage == false)
        {
            SceneManager.LoadScene("GameOver");
        }
        else if (playerHP_2.Stage1 == false && playerHP_2.Stage2 == true && playerHP_2.Stage3 == false && playerHP_2.BossStage == false)
        {
            SceneManager.LoadScene("GameOver2");
        }
        else if (playerHP_2.Stage1 == false && playerHP_2.Stage2 == false && playerHP_2.Stage3 == true && playerHP_2.BossStage == false)
        {
            SceneManager.LoadScene("GameOver3");
        }
        else if (playerHP_2.Stage1 == false && playerHP_2.Stage2 == false && playerHP_2.Stage3 == false && playerHP_2.BossStage == true)
        {
            SceneManager.LoadScene("GameOverBoss");
        }
        else
        {
            //Debug.LogError("正しくトリガーが入力されていないので、ゲームオーバー出来ません。");
        }

       // SceneManager.LoadScene("GameOver");
    }
}
