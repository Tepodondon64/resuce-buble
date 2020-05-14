using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBShot : MonoBehaviour {

    //プレイヤーオブジェクト
    GameObject Player;

    public Transform _target;
    //弾のプレハブオブジェクト
    public GameObject FireBall;

    //一秒ごとに弾を発射するためのもの
    private float targetTime = 2.0f;
    private float currentTime = 0;

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = _target.position;
        target.y = this.transform.position.y;
        this.transform.LookAt(target);
        //一秒経つごとに弾を発射する
        currentTime += Time.deltaTime;
        if (targetTime < currentTime)
        {
            currentTime = 0;
            //敵の座標を変数posに保存
            var pos = this.gameObject.transform.position;
            //弾のプレハブを作成
            var t = Instantiate(FireBall) as GameObject;
            //弾のプレハブの位置を敵の位置にする
            t.transform.position = pos;
            //敵からプレイヤーに向かうベクトルをつくる
            //プレイヤーの位置から敵の位置（弾の位置）を引く
            Vector3 vec = Player.transform.position - pos;
            //弾のRigidBody2Dコンポネントのvelocityに先程求めたベクトルを入れて力を加える
            t.GetComponent<Rigidbody>().velocity = vec;
            //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Player.transform.position, Time.deltaTime);
        }
    }
    //public GameObject enemyShellPrefab;
    //public float shotSpeed;
    ////public AudioClip shotSound;
    //private int shotIntarval;
    //GameObject Player;
    //public Transform _target;

    //void Start()
    //{
    //    Player = GameObject.Find("Player");
    //}

    //void Update()
    //{
    //    shotIntarval += 1;

    //    //プレイヤーの方向を向く
    //    Vector3 target = _target.position;
    //    target.y = this.transform.position.y;
    //    this.transform.LookAt(Player.transform.position);

    //    if (shotIntarval % 60 == 0)
    //    {
    //        //弾の生成
    //        GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

    //        Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

    //        //プレイヤーの方向に弾を発射する・・・＞この方向に力を加える。
    //        enemyShellRb.AddForce(Player.transform.position * shotSpeed);

    //        //AudioSource.PlayClipAtPoint(shotSound, transform.position);

    //        Destroy(enemyShell, 3.0f);
    //    }
    //}
}
