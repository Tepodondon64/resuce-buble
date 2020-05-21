using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireBall : MonoBehaviour {

    

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {

            Destroy(gameObject);
            Debug.Log("当たった");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("当たった");
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Burn")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Easy")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "rebble")
        {
            Destroy(gameObject);
        }

    }
}
