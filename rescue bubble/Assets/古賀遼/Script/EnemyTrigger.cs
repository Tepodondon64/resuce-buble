using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {


    public GameObject Enemy;


    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            Enemy.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;

        }
    }
}
