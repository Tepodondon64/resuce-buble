using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Controller : MonoBehaviour {

    //どのステージにコンティニュー(復帰)するのかを決めるためのトリガー。
   public bool Stage1;  //Stage1にコンティニューする
   public bool Stage2;  //Stage2にコンティニューする
   public bool Stage3;  //Stage3にコンティニューする
   public bool BossStage;   //Colosseumにコンティニューする
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.Space)))
        {
            if (Stage1 == true && Stage2 == false && Stage3 == false && BossStage == false)
            {
                SceneManager.LoadScene("Stage01");
            }
           else if (Stage1 == false && Stage2 == true && Stage3 == false && BossStage == false)
            {
                SceneManager.LoadScene("Stage02");
            }
           else if (Stage1 == false && Stage2 == false && Stage3 == true && BossStage == false)
            {
                SceneManager.LoadScene("Stage03");
            }
           else if (Stage1 == false && Stage2 == false && Stage3 == false && BossStage == true)
            {
                SceneManager.LoadScene("Colosseum");
            }
            else
            {
                Debug.LogError("正しいトリガーの入力ではありません。複数のトリガーが設定さている又は、トリガーが設定されていません");
            }
        }
	}
}
