using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour {
    //プレイヤーを格納する変数
    public GameObject player;

    //プレイヤーとの距離を調整する変数
    public float offsetx;
    public float offsety;
    public float offsetz;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //プレイヤーのポジション
        Vector3 pos = player.transform.position;

        //カメラのポジション
        transform.position = new Vector3(pos.x + offsetx, pos.y + offsety, pos.z + offsetz);
    }
}
