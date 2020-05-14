using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireBall : MonoBehaviour {

    

    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
           
        }

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            
        }

        if(collision.gameObject.tag == "Burn")
        { 
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Easy")
        {
            Destroy(gameObject);
        }

        
    }
}
