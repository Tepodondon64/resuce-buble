using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {

    public GameObject Enemy;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Wall;
    public GameObject Wall2;

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            Enemy.SetActive(true);
            Enemy1.SetActive(true);
            Enemy2.SetActive(true);
            Wall.SetActive(true);
            Wall2.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;

        }
    }
}
