using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn_2 : MonoBehaviour {


    //GameObject enemy; //オブジェクトを入れる変数名

   // SearchEnemy script; //スプリクトを入れる変数名
    //　敵サーチスクリプト
    private SearchEnemy searchEnemy;
    // ターゲットオブジェクトの Transformコンポーネントを格納する変数
    public Transform target;

    public int m = 0;

    void Start() {
       // enemy = GameObject.Find("Player"); //
        //script = enemy.GetComponent<SearchEnemy>(); 
        searchEnemy = GetComponentInChildren<SearchEnemy>();
    }


    // ゲーム実行中に毎フレーム実行する処理
    void Update()
    {
       // target = script.GetNowTarget;
       // gameObject.SetActive(false);
        if (target)
        {
        // 変数 targetPos を作成してターゲットオブジェクトの座標を格納
        Vector3 targetPos = target.position;
        // 自分自身のY座標を変数 target のY座標に格納
        //（ターゲットオブジェクトのX、Z座標のみ参照）
        targetPos.y = transform.position.y;
        // オブジェクトを変数 targetPos の座標方向に向かせる
        transform.LookAt(targetPos);
        }

        if (target == null)
        {
            target = null;
            m = 1;
        }
    }
}
