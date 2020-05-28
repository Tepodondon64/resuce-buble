using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Destroy : MonoBehaviour {

    public int FBHP = 3;
    private void Start()
    {
        Invoke("Destroy", 10);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Map")
        {
            Destroy(this.gameObject);
        }


    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
