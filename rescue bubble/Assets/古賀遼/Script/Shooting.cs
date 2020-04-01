using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //弾のプレハブをセット
    public GameObject bullet;//通常弾
    public GameObject charge_bullet;//チャージ弾

    // private　GameObject ChargeObject; //パーティクルを入れるための変数
    //弾丸発射点
    public Transform Muzzle;

    //弾丸の速度
    public float tama_speed = 1000;//通常弾の速度
    public float charge_tama_speed = 1500;//チャージ弾の速度
    //発射間隔の設定
    public float reload_time = 30;
    float Reload_Time;   ///パブリックの発射間隔をここに格納する(初期化用の変数)
    //玉が撃てる状態か？
    bool reload_time_flg;//false:今撃てるよ。  true:今撃てないよ。

    //チャージに必要な時間
    public float charge_time = 30;
    float Charge_Time;///パブリックのチャージに必要な時間をここに格納する(初期化用の変数)
    //チャージ中かどうか？
    bool charge_time_flg;//false:まだチャージ終わってないよ。  true:チャージ終了だよ。


    //Use this for initialization
    void Start()
    {
        // ChargeObject = transform.Find("ChargeParticle").gameObject;//子オブジェクトのパーティクルを入れる
        //  ChargeObject.SetActive(false);//子オブジェクトを非表示にして無理やりパーティクルを消すぜ
        //CHParticle.Play(false); 
        reload_time_flg = false;
        reload_time = reload_time * 60;//フレームでは無く、秒数になる
        Reload_Time = reload_time;//初期化用に格納する

        charge_time_flg = false;
        charge_time = charge_time * 60;//フレームでは無く、秒数になる
        Charge_Time = charge_time;//初期化用に格納する。
    }

    //Update is called once per frame
    void Update()
    {
        ShootTime();
        Shoot();
    }

    void ShootTime()//通常弾の発射間隔のタイマーを設定
    {
        if (reload_time_flg == true)
        {
            reload_time -= 1;
            if (reload_time <= 0)
            {
                reload_time = Reload_Time;
                reload_time_flg = false;
            }
        }
    }


    void Shoot()
    {
        //  スペースキーが押された時//"Fire1"により右クリックでもおｋ
        if ((Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) && reload_time_flg == false)//GetButtonDown//GetKeyDown
        {
            reload_time_flg = true;    //玉が発射されたら起動する
            // 弾丸の複製
            GameObject bullets = Instantiate(bullet) as GameObject;

            Vector3 force;

            force = this.gameObject.transform.forward * tama_speed;//forward

            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);

            // 弾丸の位置を調整transform.localPosition
            bullets.transform.localPosition = Muzzle.position;
        }

        ////ここからチャージショット////
        //  スペースキーが押され続けた時(チャージスタート)
        if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && reload_time_flg == false)
        {
            charge_time -= 1;
            if (charge_time <= 0)
            {
                charge_time_flg = true;    //
                //ChargeObject.SetActive(true);//子オブジェクトを表示にして無理やりパーティクルを表示するぜ
                //CHParticle.Play;
                //charge_time = Charge_Time;
                // charge_time_flg = false;
            }
        }

        ///スペースキーが押され続けて離された時(チャージ失敗時)
        if ((Input.GetButtonUp("Fire1") || Input.GetKeyUp(KeyCode.Space)) && charge_time_flg == false)
        {
            charge_time = Charge_Time;//チャージ時間をリセット
        }

        ///スペースキーが押され続けて離された時(チャージ成功時)
        if ((Input.GetButtonUp("Fire1") || Input.GetKeyUp(KeyCode.Space)) && charge_time_flg == true)
        {
            //  ChargeObject.SetActive(false);//子オブジェクトを非表示にして無理やりパーティクルを消すぜ
            reload_time_flg = true;    //玉が発射されたら起動する
            charge_time_flg = false;
            charge_time = Charge_Time;//チャージ時間をリセット
            // 弾丸の複製
            GameObject bullets = Instantiate(charge_bullet) as GameObject;

            Vector3 force;

            force = this.gameObject.transform.forward * charge_tama_speed;//

            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);

            // 弾丸の位置を調整transform.localPosition
            bullets.transform.localPosition = Muzzle.position;
        }

    }
}
