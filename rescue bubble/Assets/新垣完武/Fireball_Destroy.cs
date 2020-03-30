using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Destroy : MonoBehaviour {

    public int FBHP = 3;
    private void Start()
    {
        //Invoke("Destroy", 1);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Map")
        {
            Destroy(this.gameObject);
            //Destroy(gameObject);
            
        }

        if (collision.gameObject.tag == "Bullet") 
        {
            FBHP--;
            if (FBHP == 0)
            {
                Destroy(this.gameObject);
                FBHP = 3;
            }
        }

        if (collision.gameObject.tag == "ChargeBullet")
        {
            Destroy(this.gameObject);
        }

        
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
