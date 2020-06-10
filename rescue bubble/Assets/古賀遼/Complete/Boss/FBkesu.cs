using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FBkesu : MonoBehaviour
{

    public int WallHP = 12;

    void OnTriggerEnter(Collider t)
    {
        Debug.Log(t.gameObject.name);

        if (t.gameObject.tag == "FB")
        {
            //Destroy(this.gameObject);
            WallHP -= 2;
        }

        if (t.gameObject.tag == "FS")
        {
            WallHP -= 20;
        }

        if (WallHP <= 0)
        {
            Destroy(this.gameObject);
        }


    }
}
