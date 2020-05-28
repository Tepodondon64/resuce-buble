using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBurn : MonoBehaviour {

    public GameObject OBJ01;
    public GameObject OBJ02;
    public GameObject OBJ03;
    public GameObject OBJ04;
    public GameObject Right;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ( OBJ01.tag == "Burn"||
            OBJ02.tag == "Burn" ||
            OBJ03.tag == "Burn" ||
            OBJ04.tag == "Burn")
        {
            Right.SetActive(true);
        }else if (OBJ01.tag != "Burn" &&
            OBJ02.tag != "Burn" &&
            OBJ03.tag != "Burn" &&
            OBJ04.tag != "Burn")
        {
            Right.SetActive(false);
        }
    }
}
