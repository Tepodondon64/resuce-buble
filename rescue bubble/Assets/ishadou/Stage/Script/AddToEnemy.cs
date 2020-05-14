using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToEnemy : MonoBehaviour {

    public GameObject Enemy;
    public GameObject Enemy1;
    public GameObject Enemy2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Enemy.SetActive(true);
            Enemy1.SetActive(true);
            Enemy2.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;

        }
    }
}
