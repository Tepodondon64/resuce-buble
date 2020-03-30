using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Shooting : MonoBehaviour
{

    //弾のプレハブをセット
    public GameObject bullet;//通常弾
    //弾丸発射点
    public Transform Muzzle;
    public Transform Muzzle2;
    Vector3 StartMuzzlePos;
    Vector3 StartMuzzlePos2;
    //弾丸の速度
    public float tama_speed = 1000;//通常弾の速度
    //発射間隔の設定
    public float reload_time = 30;
    float Reload_Time;   ///パブリックの発射間隔をここに格納する(初期化用の変数)
    //玉が撃てる状態か？
    bool reload_time_flg;//false:今撃てるよ。  true:今撃てないよ。


    public float rotAngle = 4.0f;
    Vector3 PLAYER;
    public Transform player;

    public bool Rt_Shoot_flg;

    private float Mx, My, Mz;

    GameObject bullets;
    GameObject bullets2;

    Rigidbody RB_bullets;

    public bool Startflg;

    public int TimeCount = 0;
    public int EndCount = 120;


   // private GameObject KON_Object; //アレな音楽を入れるための変数
    //効果音の設定
    //AudioSource audioSource;    //オーディオを所得するための変数
  //  public AudioClip ShootBGM;         //ショット発射時のBGM

   // Vector3 force;

            
    //Use this for initialization
    void Start()
    {
      //  KON_Object = transform.Find("KON").gameObject;//子オブジェクトのあれを入れる
      //  KON_Object.SetActive(false);//子オブジェクトを非表示にして無理やあれを消すぜ

        //CHParticle.Play(false); 
        reload_time_flg = false;
        reload_time = reload_time * 60;//フレームでは無く、秒数になる
        Reload_Time = reload_time;//初期化用に格納する

        //Componentを取得
      //  audioSource = GetComponent<AudioSource>();//AudioのComponentを取得

        // ローカル座標を基準に、座標を取得
        StartMuzzlePos = Muzzle.localPosition;
        StartMuzzlePos2 = Muzzle2.localPosition;
        //Mx = StartMuzzlePos.x;    // ローカル座標を基準にした、x座標が入っている変数
        //My = StartMuzzlePos.y;    // ローカル座標を基準にした、y座標が入っている変数
        //Mz = StartMuzzlePos.z;    // ローカル座標を基準にした、z座標が入っている変数



        Rt_Shoot_flg = false;
        Startflg = false;//最初はfalse
        RB_bullets = bullet.GetComponent<Rigidbody>();
    }

    //Update is called once per frame
    void Update()
    {
        ShootTime();
        Shoot();
   
        PLAYER = new Vector3(transform.position.x, transform.position.y, transform.position.z);
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
        //  Bキーが押された時//
        //if ((Input.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.B)) && reload_time_flg == false && Testflg == false)//GetButtonDown//GetKeyDown
        if ((Input.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.B)) && Rt_Shoot_flg == false)//GetButtonDown//GetKeyDown
        {
            Rt_Shoot_flg = true;

            Startflg = true;//一度ボタンを押したら、それ以降はtrue

            reload_time_flg = true;    //玉が発射されたら起動する
        }

        else if ((Input.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.B)) && Rt_Shoot_flg == true)//GetButtonDown//GetKeyDown
        {
            Rt_Shoot_flg = false;


            Muzzle.localPosition = StartMuzzlePos; // ローカル座標での座標を設定
            Muzzle2.localPosition = StartMuzzlePos2;
           // // Rigidbodyに力を加えて発射
           // bullets.GetComponent<Rigidbody>().AddForce(force);
        }


        //altキーかQキーが押されたとき
        if ((Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.Q)) && Rt_Shoot_flg == false)//GetButtonDown//GetKeyDown
        {

        }

        if (Rt_Shoot_flg == true)
        {
            //発射時にショットSEを鳴らす
           // audioSource.PlayOneShot(ShootBGM);
            //KON_Object.SetActive(true);//オブジェクトを鳴らす

            // 弾丸の複製
             bullets = Instantiate(bullet) as GameObject;
             bullets2 = Instantiate(bullet) as GameObject;

            Vector3 force;
            Vector3 force2;

            force = this.gameObject.transform.forward.normalized * tama_speed;//forward
            force2 = (this.gameObject.transform.up ).normalized * tama_speed;//forward

            //player.RotateAround(player.transform.position, Vector3.up, 10);
            //
            //bullets.GetComponent<Rigidbody>().AddForce(force);
            //player.transform.RotateAround(bullets.transform.position, Vector3.up, 10f);
            // player.transform.localPosition = player.position;


            // Rigidbodyに力を加えて発射

            //player.GetComponent<Rigidbody>().AddForce(force);
            //player.GetComponent<Rigidbody>().AddForce(force2);
            // 弾丸の位置を調整transform.localPosition
            bullets.transform.localPosition = Muzzle.position;
            bullets2.transform.localPosition = Muzzle2.position;
            // 原点を中心として、(1,1,1)方向に毎秒100度公転する
            Muzzle.transform.RotateAround(PLAYER,  Vector3.right, 300 * Time.deltaTime);
            Muzzle2.transform.RotateAround(PLAYER, Vector3.up, 200 * Time.deltaTime);
            //if(++TimeCount > EndCount){
            //bullets.GetComponent<Rigidbody>().AddForce(force);
            //}

        }

        if (Rt_Shoot_flg == false /*&& Startflg == true*/)
        {
           // KON_Object.SetActive(false);//オブジェクトを鳴らさない
        }
    }
}
