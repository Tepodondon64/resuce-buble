using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syouka : MonoBehaviour {

    private float Destroy_Time = 0.0f;

    //private  particleSystem;

    //煙のエフェクトが生成されたときに呼び出される関数
    void Start()
    {
        //演出が完了したら削除する
        var particleSystem = GetComponent<ParticleSystem>();
        //Destroy(gameObject, particleSystem.main.duration);
    }

    //void Update()
    //{
    //    Destroy_Time += Time.deltaTime;
    //    if(Destroy_Time ==3.0f)
    //    {
    //        Destroy(gameObject, particleSystem.main.duration);
    //    }
    //}
}
