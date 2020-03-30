using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public GameObject mainCamera;
    public float rotate_speed;

    void Start()
    {
        mainCamera = Camera.main.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = player.transform.position;
    }
}
