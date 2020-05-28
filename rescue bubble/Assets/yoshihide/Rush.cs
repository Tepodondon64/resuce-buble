using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//突進エフェクトを制御するコンポーネント
public class Rush : MonoBehaviour {

    //突進エフェクトが生成されたときに呼び出される関数
    void Start ()
    {
        //演出が完了したら削除する
        var particleSystem = GetComponent<ParticleSystem>();
        Destroy(gameObject, particleSystem.main.duration);
	}	
}
