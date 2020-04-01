using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Throw_Shooting : MonoBehaviour
{
    //弾のプレハブをセット
    public GameObject bullet;
    //弾丸発射点
    public Transform Muzzle;
    //弾丸の速度
    public float tama_speed = 1000;
    //発射間隔の設定
    public float reload_time = 30;
    float Reload_Time;   ///パブリックの発射間隔をここに格納する(初期化用の変数)
    //玉が撃てる状態か？
    bool reload_time_flg;   //false:今撃てるよ。  true:今撃てないよ。

    ////オブジェクトを入れる変数名
    //GameObject player;
    ////スプリクトを入れる変数名
    //PlayerContoller_7 script; 

    //Use this for initialization
    void Start()
    {
        reload_time_flg = false;
        reload_time = reload_time * 60;//フレームでは無く、秒数になる
        Reload_Time = reload_time;

        //player = GameObject.Find("Player"); //
        //script = player.GetComponent<PlayerContoller_7>(); 
    }

    //Update is called once per frame
    void Update()
    {
        ShootTime();
        Shoot();
    }

    void ShootTime()
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
        //  KキーかJキーか右クリック押された時
        if ((Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.J))
            && reload_time_flg == false)//GetButtonDown//GetKeyDown
        {
            reload_time_flg = true;    //玉が発射されたら起動する
            // 弾丸の複製
            GameObject bullets = Instantiate(bullet) as GameObject;
            Vector3 force;
            force = (this.gameObject.transform.up + this.gameObject.transform.forward) * tama_speed;//発射角度を無理やり設定
            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);

            // 弾丸の位置を調整transform.localPosition
            bullets.transform.localPosition = Muzzle.position;
        }
    }
   
}
