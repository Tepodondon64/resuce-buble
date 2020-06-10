using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionS01 : MonoBehaviour {

    private int Goal = 0;

    private int NextStage = 0;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NextStage = 1;
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update () {

        if (NextStage == 1)
        {
           // SceneManager.LoadScene("Stage02");
            SceneManager.LoadScene("Colosseum");//1ステージからいきなりラスボスステージに行くよ。
            //SceneManager.UnloadScene("Stage01");
        }

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    SceneManager.LoadScene("Stage02");
        ////    SceneManager.UnloadScene("Stage01");
        //}
    }
}
