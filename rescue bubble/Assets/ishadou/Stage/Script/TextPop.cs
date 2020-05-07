using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPop : MonoBehaviour
{

    public GameObject Push;
    public GameObject Fire;

    void Start()
    {

    }

    void Update()
    {
        if (Push == null)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Push.SetActive(true);
        }
    }
}
