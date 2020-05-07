using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour {
    //プレイヤーを格納する変数
    public GameObject player;
    [SerializeField]
    Vector3 cameraVec;  //プレイヤーとの距離を調整する変数
    //プレイヤーとの距離を調整する変数
    //public float offsetx;
    //public float offsety;
    //public float offsetz;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        //プレイヤーのポジション
        Vector3 pos = player.transform.position;
        //cameraTrans.position = Vector3.Lerp(cameraTrans.position, playerTrans.position + cameraVec, 2.0f * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, pos + cameraVec, 2.0f * Time.deltaTime);
       // transform.position = Vector3.Lerp(transform.position + offsetx, player.transform.position + offsety, pos.z + offsetz);
        //カメラのポジション
      //  transform.position = new Vector3(pos.x + offsetx, pos.y + offsety, pos.z + offsetz);
    }
}
