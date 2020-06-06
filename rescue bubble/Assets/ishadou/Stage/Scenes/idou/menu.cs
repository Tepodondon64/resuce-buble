using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UIコンポーネントの使用


public class menu : MonoBehaviour {

    Button Hajimari;

    Button End;

	// Use this for initialization
	void Start () {
        Hajimari = GameObject.Find("/TitleWindow/Start").GetComponent<Button>();

        End = GameObject.Find("/TitleWindow/End").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        Hajimari.Select();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
