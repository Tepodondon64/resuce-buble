using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireshoot : MonoBehaviour
{

    public Transform target;//追いかける対象-オブジェクトをインスペクタから登録できるように
    public float speed = 0.05f;//移動スピード
    private Vector3 vec;
    public int Time = 0;
    public int Size = 0;
    bool isCalledOnce = false;

    public AudioClip sound1;
    AudioSource audioSource;
    public float volume;

    void Start()
    {
        target = GameObject.Find("Player").transform; //インスペクタから登録するのでいらない
        //this.transform.LookAt(target.transform);
        audioSource = GetComponent<AudioSource>();

        //音量調整
        audioSource.volume = volume;

    }

    void Update()
    {
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 loc = myTransform.localScale;

        //if (Size >= 5)
        //{

        //    loc.x += 0.50f;    // x座標へ0.01加算
        //    loc.y += 0.50f;    // y座標へ0.01加算
        //    loc.z += 0.50f;    // z座標へ0.01加算

        //    pos.z -= 0.05f;
        //    myTransform.localScale = loc;  // 座標を設定
        //    myTransform.position = pos;

        //    Size += 1;

        //}
        //玉を発射する関数呼び出し
        Invoke("Shoot", 3f);
        ////targetに向かって進む
        //transform.position += transform.forward * speed;
    }

    void Shoot()
    {
        if (Time < 2)
        {
            //プレイヤーの位置を取る
            this.transform.LookAt(target.transform);
            isCalledOnce = true;
            Time++;
            if (Time == 2)
            {
                audioSource.PlayOneShot(sound1);
            }
        }
        //targetに向かって進む
        transform.position += transform.forward * speed;


    }
}
