using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour, hidame//←hidameの解説は↓
{
    //MonoBehaviorのあとに「、」を付けて
    //hidame(自分で作ったインターフェースの名前ファイル名
    //これをやるとインターフェースの中のやつが使える
    public int enemy_hp = 100;                   //敵の体力

    void hidame.hidame_01(int damage)    //hidameというファイルの中の
    {                                  //hidame_01という機能を使うぞって意味です
        enemy_hp -= damage;
    }
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("のこりHPは" + enemy_hp);//成功しているか調べるためにつけたよ
        if(enemy_hp <= 0)
        {
            //Destroy(gameObject);
        }
    }
}//敵キャラ（はこ（cube)）にアタッチします。
