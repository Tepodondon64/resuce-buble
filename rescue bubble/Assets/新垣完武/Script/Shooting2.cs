using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2 : MonoBehaviour {

    //弾のプレハブをセット
    public GameObject bullet;//通常弾
    public GameObject charge_bullet;//チャージ弾

    private GameObject ChargeObject; //パーティクルを入れるための変数
    //弾丸発射点
    public Transform Muzzle;//正面
    public Transform LMuzzle;//正面左
    public Transform RMuzzle;//正面右

    //弾丸の速度
    public float tama_speed = 1000;//通常弾の速度
    public float LRtama_speed = 1000;//通常弾の速度(右と左)
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
    private int bullet_Max = 3 * 3;//ゲーム内に弾(泡)は3つまで存在できる　弾は一度に３発発射されるのでカウントが×３倍に設定する
    public int bullet_Count = 0;//Bullet_Destroyのスクリプトとつながってますよ

    //効果音の設定
    AudioSource audioSource;    //オーディオを所得するための変数
    public AudioClip ShootSE;         //ショット発射時
    public AudioClip Charge_ShootSE;  //チャージショット発射時


    //無理矢理ロックオンで3方向ショット作ってやろう
   public GameObject Ltarget;   //左側のターゲットを入れる
   public GameObject Rtarget;   //右側のターゲットを入れる

   //public GameObject Shoot_ParticlePrefabs; //ショットのパーティクルを入れる
   public bool Stopflg; //ノックバック中にtrueになる

   public bool Charge_Limit; //チャージ泡を禁止にするかどうか　false:制限無し true:制限あり(撃てない)

   //スクリプトの取得//
   PlayerContoller_8 playerContoller_8;

   //Animator を入れる変数
   private Animator animator;

    //Use this for initialization
    void Start()
    {
        //外部のスクリプトの情報を取得
        playerContoller_8 = GetComponent<PlayerContoller_8>();//PlayerContoller_8スクリプトの取得

        ChargeObject = transform.Find("charge_effects").gameObject;//子オブジェクトのパーティクルを入れる
        ChargeObject.SetActive(false);//子オブジェクトを非表示にして無理やりパーティクルを消すぜ

        //Componentを取得
        audioSource = GetComponent<AudioSource>();//AudioのComponentを取得


        reload_time_flg = false;
        reload_time = reload_time * 60;//フレームでは無く、秒数になる
        Reload_Time = reload_time;//初期化用に格納する

        charge_time_flg = false;
        charge_time = charge_time * 60;//フレームでは無く、秒数になる
        Charge_Time = charge_time;//初期化用に格納する。

        //Stopflg = false;//falseのときは特になにもないが、trueになるとボタン操作を受付なくなる

        //ユニティちゃんの Animator にアクセスする
        animator = GetComponent<Animator>();
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
        //ずっとこの方向に向いてもらおう
        LMuzzle.LookAt(Ltarget.transform);
        RMuzzle.LookAt(Rtarget.transform);
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
                //animator.SetBool("Shooting2", false);
            }
        }
    }


    void Shoot()
    {
        if (bullet_Count <= 0)   //万が一bullet_Countがマイナスになったときに０に戻す
        {
            //発射アニメーションを終了
            animator.SetBool("Shooting", false);
            animator.SetBool("Run_Shooting", false);

            //待機アニメーションを再生
           // animator.SetBool("Idling", true);

            bullet_Count = 0;
        }

        if (Stopflg == true)//チャージが中断される系の処理
        {
            charge_time = Charge_Time;//チャージ時間をリセット
            ChargeObject.SetActive(false);//子オブジェクトを非表示にして無理やりパーティクルを消すぜ
            charge_time_flg = false ;   //チャージ中断

        }

        //  スペースキーが押された時//"Fire1"により右クリックでもおｋ
        if ((Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.Space)) && reload_time_flg == false && Stopflg == false)//GetButtonDown//GetKeyDown
        {

            if (bullet_Count < bullet_Max && (bullet_Count % 3 == 0 || bullet_Count == 5 || bullet_Count == 4))
            {
                if (playerContoller_8.horizontalKeyflg != 0 || playerContoller_8.verticalKeyflg != 0)//右→
                {
                    //(走りながらの)発射アニメーションを再生
                    animator.SetBool("Run_Shooting", true);
                    animator.SetBool("Shooting", false);

                    //待機アニメーションをオフ
                  //  animator.SetBool("Idling", false);

                    //GameObject particle = Instantiate(Shoot_ParticlePrefabs) as GameObject;//通常泡の発射パーティクルのプレハブのクローンを生成している
                    //Vector3 shootPos = (Muzzle.position);//通常泡の発射地点を取得している。
                    //particle.transform.position = shootPos;//通常泡の発射パーティクルの発生地点を入れている



                }
                else
                {
                    //発射アニメーションを再生
                    animator.SetBool("Shooting", true);
                    animator.SetBool("Run_Shooting", false);

                    //GameObject particle = Instantiate(Shoot_ParticlePrefabs) as GameObject;//通常泡の発射パーティクルのプレハブのクローンを生成している
                    //Vector3 shootPos = (Muzzle.position);//通常泡の発射地点を取得している。
                    //particle.transform.position = shootPos;//通常泡の発射パーティクルの発生地点を入れている

                    //待機アニメーションをオフ
                 //   animator.SetBool("Idling", false);
                }

               
                reload_time_flg = true;    //玉が発射されたら起動する
                //bullet_Count++;

/*******************************
**********弾丸の複製************
*******************************/


                ////(弾丸の複製上方向の前、右、左
                //GameObject UP_C_bullets = Instantiate(bullet) as GameObject;
                //GameObject UP_R_bullets = Instantiate(bullet) as GameObject;
                //GameObject UP_L_bullets = Instantiate(bullet) as GameObject;


                //弾丸の複製　前、右、左
                GameObject C_bullets = Instantiate(bullet) as GameObject;
                GameObject R_bullets = Instantiate(bullet) as GameObject;
                GameObject L_bullets = Instantiate(bullet) as GameObject;

/*******************************
*****弾丸の発射方向の制御*******
*******************************/


                //上
                //Vector3 UP_C_force;//上前
                //UP_C_force = (this.gameObject.transform.up + this.gameObject.transform.forward).normalized * tama_speed;//上前
                //Vector3 UP_R_force;//右前
                //UP_R_force = (this.gameObject.transform.up + this.gameObject.transform.forward + this.gameObject.transform.right).normalized * tama_speed;//右前
                //Vector3 UP_L_force;//左前
                //UP_L_force = (this.gameObject.transform.up + this.gameObject.transform.forward - this.gameObject.transform.right).normalized * tama_speed;//上前

                
                //中
                Vector3 C_force;//前
                C_force = (this.gameObject.transform.forward) * tama_speed;//forward//前

                Vector3 R_force;//右
                Vector3 L_force;//左
                R_force = (RMuzzle.forward) * tama_speed;//右
                L_force = (LMuzzle.forward) * tama_speed;//左 


/*******************************
****発射と発射位置の制御********
*******************************/
                

                //// 正面の上方向
                //UP_C_bullets.GetComponent<Rigidbody>().AddForce(UP_C_force);// Rigidbodyに力を加えて発射  上前方向
                //UP_C_bullets.transform.localPosition = Muzzle.position;// 弾丸の発射位置

                //UP_R_bullets.GetComponent<Rigidbody>().AddForce(UP_R_force);// Rigidbodyに力を加えて発射  上右方向
                //UP_R_bullets.transform.localPosition = Muzzle.position;// 弾丸の発射位置

                //UP_L_bullets.GetComponent<Rigidbody>().AddForce(UP_L_force);// Rigidbodyに力を加えて発射  上左方向
                //UP_L_bullets.transform.localPosition = Muzzle.position;// 弾丸の発射位置


                // 正面の水平方向
                C_bullets.GetComponent<Rigidbody>().AddForce(C_force);// Rigidbodyに力を加えて発射  前方向
                C_bullets.transform.localPosition = Muzzle.position;// 弾丸の発射位置

                R_bullets.GetComponent<Rigidbody>().AddForce(R_force);// Rigidbodyに力を加えて発射  右方向
                R_bullets.transform.localPosition = RMuzzle.position;// 弾丸の発射位置

                L_bullets.GetComponent<Rigidbody>().AddForce(L_force);// Rigidbodyに力を加えて発射  左方向
                L_bullets.transform.localPosition = LMuzzle.position;// 弾丸の発射位置

                //発射時にショットSEを鳴らす
                audioSource.PlayOneShot(ShootSE);
            }
        }

///////////ここからチャージショット/////////

        if (Charge_Limit == false)//チャージ泡が制限が掛かっていなければ通る(falseなら、撃てる。)
        {
            //  スペースキーが押され続けた時(チャージスタート)
            if ((Input.GetButton("Fire2") || Input.GetKey(KeyCode.Space)) && reload_time_flg == false && Stopflg == false)
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
            if ((Input.GetButtonUp("Fire2") || Input.GetKeyUp(KeyCode.Space)) && charge_time_flg == false && Stopflg == false)
            {
                if (charge_time <= Charge_Time / 2)//チャージショットに必要な時間の半分を過ぎた場合に発動
                {
                    if (bullet_Count < bullet_Max && (bullet_Count % 3 == 0 || bullet_Count == 5 || bullet_Count == 4))
                    {
                        if (playerContoller_8.horizontalKeyflg != 0 || playerContoller_8.verticalKeyflg != 0)//右→
                        {

                            //(走りながらの)発射アニメーションを再生
                            animator.SetBool("Run_Shooting", true);
                            animator.SetBool("Shooting", false);

                            //待機アニメーションをオフ
                            //   animator.SetBool("Idling", false);
                        }
                        else
                        {
                            //発射アニメーションを再生
                            animator.SetBool("Shooting", true);
                            animator.SetBool("Run_Shooting", false);

                            //待機アニメーションをオフ
                            //   animator.SetBool("Idling", false);
                        }

                        //弾丸の複製　前、右、左
                        GameObject C_bullets = Instantiate(bullet) as GameObject;
                        GameObject R_bullets = Instantiate(bullet) as GameObject;
                        GameObject L_bullets = Instantiate(bullet) as GameObject;

                        //弾丸の発射方向の制御 正面
                        Vector3 C_force;//前
                        C_force = (this.gameObject.transform.forward) * tama_speed;//forward//前
                        Vector3 R_force;//右
                        Vector3 L_force;//左
                        R_force = (RMuzzle.forward) * tama_speed;//右
                        L_force = (LMuzzle.forward) * tama_speed;//左 

                        // 正面の水平方向
                        C_bullets.GetComponent<Rigidbody>().AddForce(C_force);// Rigidbodyに力を加えて発射  前方向
                        C_bullets.transform.localPosition = Muzzle.position;// 弾丸の発射位置

                        R_bullets.GetComponent<Rigidbody>().AddForce(R_force);// Rigidbodyに力を加えて発射  右方向
                        R_bullets.transform.localPosition = Muzzle.position;// 弾丸の発射位置

                        L_bullets.GetComponent<Rigidbody>().AddForce(L_force);// Rigidbodyに力を加えて発射  左方向
                        L_bullets.transform.localPosition = Muzzle.position;// 弾丸の発射位置

                        //発射時にショットSEを鳴らす
                        audioSource.PlayOneShot(ShootSE);
                    }
                }
                charge_time = Charge_Time;//チャージ時間をリセット
            }

            ///スペースキーが押され続けて離された時(チャージ成功時)
            if ((Input.GetButtonUp("Fire2") || Input.GetKeyUp(KeyCode.Space)) && charge_time_flg == true && Stopflg == false)
            {
                if (playerContoller_8.horizontalKeyflg != 0 || playerContoller_8.verticalKeyflg != 0)//右→
                {
                    //(走りながらの)発射アニメーションを再生
                    animator.SetBool("Run_Shooting", true);
                    animator.SetBool("Shooting", false);

                    //待機アニメーションをオフ
                    // animator.SetBool("Idling", false);
                }
                else
                {
                    //発射アニメーションを再生
                    animator.SetBool("Shooting", true);
                    animator.SetBool("Run_Shooting", false);

                    //待機アニメーションをオフ
                    animator.SetBool("Idling", false);
                }


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

                //発射時にチャージショットのSEを鳴らす
                audioSource.PlayOneShot(Charge_ShootSE);
            }
        }
    }
}
