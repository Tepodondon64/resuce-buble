using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chairblack : MonoBehaviour {


    private GameObject parent;

    // Use this for initialization
    void Start () {
        parent = transform.parent.gameObject;
    }

	
	// Update is called once per frame
	void Update () {
        if (parent.tag == "Burn")
        {
            Debug.Log("burn");
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        }
	}
}
