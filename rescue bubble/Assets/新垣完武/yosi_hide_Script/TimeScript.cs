using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour {

    private float time = 60;
    private bool stoptime_flg;//時間を止める

	void Start () {

        //初期値60を表示
        //float型からint型へCastし、String型に変換して表示
        GetComponent<Text>().text = ((int)time).ToString();

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
        if (time < 0){
            // 1.5秒後に「GoToGameOver()」メソッドを実行する。
            Invoke("GoToGameOver", 1.5f);
        }
        //マイナスは表示しない
        if (time < 0) time = 0;
        GetComponent<Text>().text = ((int)time).ToString();
	}
    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
