using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("owariyo", 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void owariyo()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
        #endif
    }
}
