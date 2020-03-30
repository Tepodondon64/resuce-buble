using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2 : MonoBehaviour {

    //弾のプレハブをセット
    public GameObject bullet;//通常弾
    public GameObject charge_bullet;//チャージ弾

    private GameObject ChargeObject; //パーティクルを入れるための変数
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


    //一度に存在できる通常弾の数とそのカウントするための変数
    private int bullet_Max = 5;//ゲーム内に弾(泡)は5つまで存在できる
    public int bullet_Count = 0;//Bullet_Destroyのスクリプトとつながってますよ

    //Use this for initialization
    void Start()
    {
        ChargeObject = transform.Find("ChargeParticle").gameObject;//子オブジェクトのパーティクルを入れる
        ChargeObject.SetActive(false);//子オブジェクトを非表示にして無理やりパーティクルを消すぜ
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
        Target();
    }

    void Target()
    {
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
            if (bullet_Count < bullet_Max)
            {
                reload_time_flg = true;    //玉が発射されたら起動する
                //bullet_Count++;

/*******************************
**********弾丸の複製************
*******************************/


                //(弾丸の複製上方向の前、右、左
                GameObject UP_C_bullets = Instantiate(bullet) as GameObject;



                //弾丸の複製　前、右、左
                GameObject C_bullets = Instantiate(bullet) as GameObject;
                GameObject R_bullets = Instantiate(bullet) as GameObject;
                GameObject L_bullets = Instantiate(bullet) as GameObject;

/*******************************
*****弾丸の発射方向の制御*******
*******************************/


                //上
                Vector3 UP_C_force;//上前
                UP_C_force = (this.gameObject.transform.up + this.gameObject.transform.forward).normalized * tama_speed;//上前



                //中
                Vector3 C_force;//前
                C_force = (this.gameObject.transform.forward) * tama_speed;//forward//前
                Vector3 R_force;//右
                R_force = (this.gameObject.transform.forward + this.gameObject.transform.right).normalized * tama_speed;//右
                Vector3 L_force;//左
                L_force = (this.gameObject.transform.forward - this.gameObject.transform.right).normalized * tama_speed;//左
                

/*******************************
****発射と発射位置の制御********
*******************************/
                

                // 正面の上方向

                UP_C_bullets.GetComponent<Rigidbody>().AddForce(UP_C_force);// Rigidbodyに力を加えて発射  前方向
                UP_C_bullets.transform.localPosition = Muzzle.position;// 弾丸の位置


                // 正面の水平方向
                C_bullets.GetComponent<Rigidbody>().AddForce(C_force);// Rigidbodyに力を加えて発射  前方向
                C_bullets.transform.localPosition = Muzzle.position;// 弾丸の位置

                R_bullets.GetComponent<Rigidbody>().AddForce(R_force);// Rigidbodyに力を加えて発射  右方向
                R_bullets.transform.localPosition = Muzzle.position;// 弾丸の位置

                L_bullets.GetComponent<Rigidbody>().AddForce(L_force);// Rigidbodyに力を加えて発射  左方向
                L_bullets.transform.localPosition = Muzzle.position;// 弾丸の位置

            }
        }

///////////ここからチャージショット/////////

        //  スペースキーが押され続けた時(チャージスタート)
        if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && reload_time_flg == false)
        {
            charge_time -= 1;
            if (charge_time <= 0)
            {
                charge_time_flg = true;    //
                ChargeObject.SetActive(true);//子オブジェクトを表示にして無理やりパーティクルを表示するぜ
                //CHParticle.Play;
                //charge_time = Charge_Time;
                // charge_time_flg = false;
            }
        }

        ///スペースキーが押され続けて離された時(チャージ失敗時)
        if ((Input.GetButtonUp("Fire1") || Input.GetKeyUp(KeyCode.Space)) && charge_time_flg == false)
        {
            if (charge_time <= Charge_Time / 2)//チャージショットに必要な時間の半分を過ぎた場合に発動
            {
                //reload_time_flg = true;    //玉が発射されたら起動する
                ////bullet_Count++;
                //// 弾丸の複製
                //GameObject bullets = Instantiate(bullet) as GameObject;

                //Vector3 force;

                //force = this.gameObject.transform.forward * tama_speed;//forward

                //// Rigidbodyに力を加えて発射
                //bullets.GetComponent<Rigidbody>().AddForce(force);

                //// 弾丸の位置を調整transform.localPosition
                //bullets.transform.localPosition = Muzzle.position;
            }
            charge_time = Charge_Time;//チャージ時間をリセット
        }

        ///スペースキーが押され続けて離された時(チャージ成功時)
        if ((Input.GetButtonUp("Fire1") || Input.GetKeyUp(KeyCode.Space)) && charge_time_flg == true)
        {
            ChargeObject.SetActive(false);//子オブジェクトを非表示にして無理やりパーティクルを消すぜ
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
