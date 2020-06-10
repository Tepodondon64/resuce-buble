using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sin : MonoBehaviour {

    GameObject Boss;
	// Use this for initialization
	void Start () {
        Boss = GameObject.Find("MainChar");//タイムの情報を取得する
    }
	
	// Update is called once per frame
	void Update () {
        if(Boss == null)
        {
            Invoke("GE", 0.5f);
        }
	}
    void GE()
    {
        SceneManager.LoadScene("gameclear");
    }
}
