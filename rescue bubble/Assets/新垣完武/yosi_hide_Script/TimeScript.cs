using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour {

    private float time = 30;

	void Start () {

        //初期値60を表示
        //float型からint型へCastし、String型に変換して表示
        GetComponent<Text>().text = ((int)time).ToString();

	}
	
	void Update () {
        //1秒に1ずつ減らしていく
        time -= Time.deltaTime;

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
