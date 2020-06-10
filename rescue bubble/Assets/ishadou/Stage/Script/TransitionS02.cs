using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionS02 : MonoBehaviour {

    public int NextStage = 0;

    // Use this for initialization
    void Start()
    {

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
    void Update()
    {

        if (NextStage == 1)
        {
            SceneManager.LoadScene("Stage03");
            //SceneManager.UnloadScene("Stage02");
        }

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    SceneManager.LoadScene("Stage03");
        //    //SceneManager.UnloadScene("Stage02");
        //}
    }
}
