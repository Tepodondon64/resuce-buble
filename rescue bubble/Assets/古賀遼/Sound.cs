using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    public AudioClip sound2;
    AudioSource audioSource2;

    // Use this for initialization
    void Start () {
        audioSource2 = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FB")
        {
            audioSource2.PlayOneShot(sound2);
        }
        
    }
}
