using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_collision : MonoBehaviour {

    public bool backTrigger;    //false:後ろの壁に当たって無い。 true:後ろの壁に当たっている。
	// Use this for initialization
	void Start () {
        backTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            backTrigger = true;
             Debug.Log("君は今、壁に当たった！");//
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            backTrigger = true;
            Debug.Log("君は今、壁に当たっている！");//
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            backTrigger = false;
            Debug.Log("離れた!");
        }
    }

}
