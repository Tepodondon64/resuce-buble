using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchEnemy_2 : MonoBehaviour {

    public Transform target;
    private GameObject Enemy;
	// Use this for initialization
	void Start () {
        //GetComponent<SphereCollider>().isTrigger = false;
       // Enemy = transform.root.gameObject; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //void OnTriggerStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")//敵に当たったら
    //    {
    //        target = gameObject.transform;
    //        //target = collision.gameObject;
    //        // GetComponent<SphereCollider>().isTrigger = true;
    //        //gameObject.SetActive(false);
    //    }
    //}
}
