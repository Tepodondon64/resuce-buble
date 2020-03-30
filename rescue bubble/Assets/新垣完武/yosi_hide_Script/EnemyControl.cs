using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent使うときに必要
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour {

    private NavMeshAgent agent;

    public GameObject target;
    Vector3 playerPos;
    GameObject player;
    private float searchTime = 0;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //追跡したいオブジェクトの名前を入れる
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //経過時間を取得
        this.searchTime += Time.deltaTime;

        if(this.searchTime >= 1.0f)
        {
            //プレイヤーのオブジェクトを取得
            player = GameObject.Find("Player");
            //経過時間を初期化
            this.searchTime = 0;

            //1秒おきに移動
            //対象の方向を向く
            this.changeDirection(this.player);

            //自分自身の位置から相対的に移動する
            this.transform.Translate(Vector3.forward * 1.00f);
        }

    }

    //playerの座標に応じて向きを変える
    void changeDirection(GameObject Player)
    {
        //playerとenemyの座標差分を取得する
        int xDistance = Mathf.RoundToInt(this.transform.position.x - player.transform.position.x);
        int zDistance = Mathf.RoundToInt(this.transform.position.z - player.transform.position.z);

        //向きたい角度
        int rotateDir = 0;

        ////x座標,z座標の差分から向きたい角度を取得する
        //playerとenemyに距離がある場合
        if (xDistance == 0)
        {
            //x座標が同じ場合z座標のみ向き取得
            rotateDir = this.getDirection(zDistance, "z");
        }
        else if (zDistance == 0)
        {
            //z座標が同じ場合x座標のみ向き取得
            rotateDir = this.getDirection(xDistance, "x");
        }
        else
        {
            //どちらも差がある場合、ランダムで進む向き取得
            int rand = UnityEngine.Random.Range(0, 2);
            if (rand == 0)
            {
                //z座標向き取得
                rotateDir = this.getDirection(zDistance, "z");
            }
            else
            {
                //x座標向き取得
                rotateDir = this.getDirection(xDistance, "x");
            }

        }
        //取得した方向にオブジェクトの向きを変える
        this.transform.rotation = Quaternion.Euler(0, rotateDir, 0);
    }

    //向きの角度を取得する
    int getDirection(int distance, string axis)
    {
        //距離がプラスかマイナスかを取得
        int flag = distance > 0 ? 1 : 0;

        //角度を返却
        if (axis == "x")
        {
            return flag == 1 ? 270 : 90;
        }
        else
        {
            return flag == 1 ? 180 : 0;
        }
    }

}

