using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIコンポーネントの使用

public class GameOver_Menu : MonoBehaviour {

    Button Hajimari;

    Button End;

    // Use this for initialization
    void Start()
    {
        Hajimari = GameObject.Find("/GameOverWindow/Continue_Button").GetComponent<Button>();

        End = GameObject.Find("/GameOverWindow/Title_Button").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        Hajimari.Select();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
