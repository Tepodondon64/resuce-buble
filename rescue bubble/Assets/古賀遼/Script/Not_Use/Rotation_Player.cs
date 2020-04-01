using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Player : MonoBehaviour {

    private GameObject lookTarget;

    void Start()
    {
        lookTarget = GameObject.CreatePrimitive(PrimitiveType.Sphere);//
        lookTarget.transform.localPosition = new Vector3(0, 2f, 4.5f);
    }

    void Update()
    {
        if (lookTarget)
        {
            Quaternion lockRotation = Quaternion.LookRotation(lookTarget.transform.position - transform.position, Vector3.up);

            lockRotation.z = 0;
            lockRotation.x = 0;

            transform.rotation = Quaternion.Lerp(transform.rotation, lockRotation, 0.1f);
        }
    }
}
