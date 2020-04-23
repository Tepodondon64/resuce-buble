using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAreaWall : MonoBehaviour {

    void Update()
    {
        //EnemyというTagを持つオブジェクトの個数をcountに保存する
        int count = GameObject.FindGameObjectsWithTag("Enemy").Length;

        //オブジェクトの個数(count)が0になった時
        if(count == 0)
        {
            Destroy(gameObject);
        }
        
    }
}
