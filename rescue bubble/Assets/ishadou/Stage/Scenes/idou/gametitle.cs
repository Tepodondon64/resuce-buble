using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gametitle : MonoBehaviour {

    //　スタートボタンを押したら実行する
    //public void StartGame(){
    //    SceneManager.LoadScene("Stage01");
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Stage01");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("gameend");
        }

    }
}
