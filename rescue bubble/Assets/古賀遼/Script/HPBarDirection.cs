using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UI使うときは忘れずに。

public class HPBarDirection : MonoBehaviour {

    public Canvas canvas;

	// Use this for initialization
	void Start () {
		
	}

    

    void Update()
    {
        //EnemyCanvasをMain Cameraに向かせる
        canvas.transform.rotation =
            Camera.main.transform.rotation;
    }
}
