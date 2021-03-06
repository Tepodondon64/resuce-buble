﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP_2 : MonoBehaviour {
    public int HP;  //プレイヤーのHP
    public bool DebugLog_ON = false;//これがtrueだとデバッグログが表示される
    private bool deslog = false;//デバッグログ用
    private int InvincibleTime;//無敵時間↓↓
    private int Time = 120;//無敵時間の値、初期化するために使う変数
    private bool Invincibleflg; //無敵フラグ

    private double g_time = 0.4;
    ////効果音の設定
    AudioSource audioSource;    //オーディオを所得するための変数
    public AudioClip DamageSE;         //プレイヤーがダメージを受けた時のSE

    //↓どのゲームオーバーに行くかを判別させるためのトリガー↓
    public bool Stage1; //Stage1のゲームオーバーに行く
    public bool Stage2; //Stage2のゲームオーバーに行く
    public bool Stage3; //Stage3のゲームオーバーに行く
    public bool BossStage;  //BossStageのゲームオーバーに行く

    private int MAX = -90;
    private int Prx = -5;

    private bool NoUpdateflg;
    private bool NoUseFadeOutflg;   //ゲームオブジェクトの「fadeOutImage」がシーン内に存在しない場合にtrueになる


    Transform player;   //プレイヤーのトランスフォーム取得
    //bool knock_back;   //←こちら、Playerの子オブジェクトのBack_collisionのスクリプトのbackTriggerを入れるための変数です。

    MeshRenderer PlayerMr;//マテリアルの情報を入れるための変数
    MeshRenderer OriginMr;//元々のマテリアルの情報を入れるための変数

    float alpha_Sin;    //新しいalpha値を入れるための変数


    //スクリプトの取得//
    Shooting2 shooting2;
    PlayerContoller_8 playerContoller_8;
    TimeScript timeScript;
    FadeOutImage fadeOutImage;

    //外部のオブジェクトを取得//
    GameObject time;
    GameObject FloorImage;
    private GameObject DamageObject; //パーティクルを入れるための変数(無敵時間の間だけ表示させる)
    //Animator を入れる変数
    private Animator animator;

    void Start()
    {
        DamageObject = transform.Find("Damage_effects").gameObject;//ダメージのパーティクルを入れる
        DamageObject.SetActive(false);//ダメージのオブジェクトを非表示にする

        //外部のスクリプトの情報を取得
        shooting2 = GetComponent<Shooting2>();//Shooting2スクリプトの取得
        playerContoller_8 = GetComponent<PlayerContoller_8>();//PlayerContoller_7スクリプトの取得

        time = GameObject.Find("Time");//タイムの情報を取得する
        timeScript = time.GetComponent<TimeScript>();//TimeScriptスクリプトの取得

        if (GameObject.Find("Image") != null)//シーン内に"Image"があれば通る
        {
        FloorImage = GameObject.Find("Image");//FloorNameの子要素にあるイメージの情報を取得する
            fadeOutImage = FloorImage.GetComponent<FadeOutImage>();//FadeOutImageスクリプトの取得
            NoUseFadeOutflg = false;
            NoUpdateflg = false;
        }
        else //シーン内に"Image"が無かったらnullなので通る
        {
            NoUseFadeOutflg = true;
            NoUpdateflg = true;
        }

        //Componentを取得
        audioSource = GetComponent<AudioSource>();//AudioのComponentを取得
        player = this.gameObject.GetComponent<Transform>(); //playerのTransformを取得
        Invincibleflg = false;
        InvincibleTime = Time;

        PlayerMr = GetComponent<MeshRenderer>();//プレイヤーのMeshRendererを取得
        OriginMr = PlayerMr;
        //PlayerMr.material.color = PlayerMr.material.color - new Color32(0, 0, 0, 100);

        //Playerの Animator にアクセスする
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        DebugLog();
        Invincible();
        GameOver();
        if (NoUseFadeOutflg == false)
        {
            PlayerStop();
        }
        //if (Input.GetMouseButtonDown(1))
        //{
        //    SceneManager.LoadScene(3);
        //}
    }

    void DebugLog() //デバッグログを確認する用の関数
    {
        if (DebugLog_ON == true)    //DebugLog_ONがtrueになっていたら表示される。
        {
            if (HP > 0 && Invincibleflg == true)
            {
                Debug.Log("無敵時間終了までのこり<color=red><size=20>" + InvincibleTime + "</size></color>秒");
            }
            if (HP <= 0 && deslog == false)
            {
                deslog = true;
                Debug.Log("<color=red><size=30>おまえ</size></color>" + "<size=20>はもう</size>" + "<color=red><size=30>死</size></color>" + "<size=20>んでいる....</size>");
            }
        }
    }


    //IEnumerator ColorCoroutine()//ここでは点滅処理を行っている。それだけはわかる。
    //{
    //    while (true)
    //    {
    //        yield return new WaitForEndOfFrame();//多分、この処理を中断するタイミングを決めている。

    //        Color _color = PlayerMr.material.color;//ここでプレイヤーのマテリアル(色)情報を渡している

    //        _color.a = alpha_Sin;//colorのalpha値にalpha_Sinを入れている。

    //        PlayerMr.material.color = _color;   //受け取った_colorのマテリアル(色)情報をプレイヤーに逆輸入する。
    //    }
    //}


    void Invincible()
    {
        //点滅するためにalphaをいじる必要がある。正直難しくて一部しか理解できなかった↓
        alpha_Sin = Mathf.Sin(InvincibleTime) / 2 + 0.5f;

        //後ろが壁かどうか確認するために情報を手に入れる
      //  knock_back = transform.GetChild(0).gameObject.GetComponent<Back_collision>().backTrigger;

        if (Invincibleflg == true)  //敵に当たったら反応する
        {
          //  StartCoroutine("ColorCoroutine");
            if (--InvincibleTime < 0)   //この時間が無くなったら無敵時間は終了する
            {
                // PlayerMr.material.color = PlayerMr.material.color + new Color32(0, 0, 0, 100);
                Invincibleflg = false;
                InvincibleTime = Time;
                DamageObject.SetActive(false);//ダメージのオブジェクトを非表示にする
            }
        }
        if (Invincibleflg == false)  //敵には当たってなければ
        {
        }
        ///////敵に当たったら反応する奴↓↓
        if (NoUpdateflg == true)
        {

            if (shooting2.Stopflg == true && timeScript.timeEndflg == false)
            {
                //ExitStopShootを0.6秒後に呼び出す//ちなみにノックバックは0.4秒で終わります。
                Invoke("ExitStopShoot", 0.6f);

            }

            if (playerContoller_8.Stopflg == true && timeScript.timeEndflg == false)
            {
                //ExitStopMoveを0.6秒後に呼び出す//ちなみにノックバックは0.4秒で終わります。
                Invoke("ExitStopMove", 0.6f);
            }
        }

    }


    void PlayerStop()
    {
        if (NoUpdateflg == false)
        {
            if (fadeOutImage.FadeEndflg == false)//ゲームスタートするまでは動けない
            {
                shooting2.Stopflg = true;   //泡の発射を止める
                playerContoller_8.Stopflg = true;   //プレイヤーの動きを止める
            }
            else if (fadeOutImage.FadeEndflg == true)//ゲームスタートしたら動ける
            {
                shooting2.Stopflg = false;   //泡が撃てるようにする
                playerContoller_8.Stopflg = false;   //プレイヤーが動けるようにする
                NoUpdateflg = true;
            }
        }
    }


    void GameOver()
    {
       //int MAX = -90;
       // int Prx = -5;
        if (HP <= 0 || timeScript.timeEndflg == true)
        {
            shooting2.Stopflg = true;   //泡の発射を止める
            playerContoller_8.Stopflg = true;   //プレイヤーの動きを止める
            //HPが0になったときのアニメーションを再生
            animator.SetBool("CanDie", true);
            Invoke("GoToGameOver", 3.0f);
        }
    }

    void OnCollisionEnter(Collision other)//当たった瞬間
    {

        Vector3 _Rotation = player.transform.localEulerAngles;

        if (HP > 0 && timeScript.timeEndflg == false) //HPが0よりも多ければ通る
        {

            //もしもぶつかった相手のTagが"Enemy"であったならば（条件） 
            if (other.gameObject.CompareTag("Enemy") && Invincibleflg == false)
            {
                //被ダメージのアニメーションを再生
                animator.SetBool("Damageing", true);
                //HPを１ずつ減少させる
                HP -= 2;
                OnDamageEffect();//この関数に移動
                Invincibleflg = true;//無敵時間になるフラグオン

                //ダメージを受けた時にSEを鳴らす
                audioSource.PlayOneShot(DamageSE);
                
            }


            //もしもぶつかった相手のTagが"Burn"であったならば（条件） 
            if (other.gameObject.CompareTag("Burn") && Invincibleflg == false)
            {
                //被ダメージのアニメーションを再生
                animator.SetBool("Damageing", true);
                //HPを１ずつ減少させる
                HP -= 1;
                OnDamageEffect();//この関数に移動
                Invincibleflg = true;//無敵時間になるフラグオン

                //ダメージを受けた時にSEを鳴らす
                audioSource.PlayOneShot(DamageSE);
               
            }

            //もしもぶつかったFBのTagが"FB"であったならば（条件）
            if (other.gameObject.tag == "FB" && Invincibleflg == false)
            {
                //被ダメージのアニメーションを再生
                animator.SetBool("Damageing", true);
                //HPを1ずつ減少させる
                HP -= 2;
                OnDamageEffect();//この関数に移動
                Invincibleflg = true;//無敵時間になるフラグオン

                //ダメージを受けた時にSEを鳴らす
                audioSource.PlayOneShot(DamageSE);
               
            }

        }
    }

    void OnCollisionStay(Collision other)//当たっている間(体当たりしてくるエネミーにぶつかり続けてもダメージが食らうように作ったもの)
    {

        if (HP > 0 && timeScript.timeEndflg == false) //HPが0よりも多ければ通る
        {

            //もしもぶつかった相手のTagが"Enemy"であったならば（条件） 
            if (other.gameObject.CompareTag("Enemy") && Invincibleflg == false)
            {
                //被ダメージのアニメーションを再生
                animator.SetBool("Damageing", true);
                //HPを１ずつ減少させる
                HP -= 2;
                OnDamageEffect();//この関数に移動
                Invincibleflg = true;//無敵時間になるフラグオン

                //ダメージを受けた時にSEを鳴らす
                audioSource.PlayOneShot(DamageSE);

                
            }

            //もしもぶつかった相手のTagが"Burn"であったならば（条件） 
            if (other.gameObject.CompareTag("Burn") && Invincibleflg == false)
            {
                //被ダメージのアニメーションを再生
                animator.SetBool("Damageing", true);
                //HPを１ずつ減少させる
                HP -= 1;
                OnDamageEffect();//この関数に移動
                Invincibleflg = true;//無敵時間になるフラグオン

                //ダメージを受けた時にSEを鳴らす
                audioSource.PlayOneShot(DamageSE);
                
            }
        }
    }

    void OnTriggerEnter(Collider t)//FB
    {
        //もしもぶつかったFBのTagが"FB"であったならば（条件）
        if (t.gameObject.tag == "FB" && Invincibleflg == false)
        {
            //被ダメージのアニメーションを再生
            animator.SetBool("Damageing", true);
            //HPを1ずつ減少させる
            HP -= 2;
            OnDamageEffect();//この関数に移動
            Invincibleflg = true;//無敵時間になるフラグオン

            //ダメージを受けた時にSEを鳴らす
            audioSource.PlayOneShot(DamageSE);
           
        }

        //もしもぶつかった火災旋風のTagが"FS"であったならば（条件）
        if (t.gameObject.tag == "FS" && Invincibleflg == false)
        {
            //被ダメージのアニメーションを再生
            animator.SetBool("Damageing", true);
            //HPを8ずつ減少させる
            HP -= 8;
            OnDamageEffect();//この関数に移動
            Invincibleflg = true;//無敵時間になるフラグオン
            //ダメージを受けた時にSEを鳴らす
            audioSource.PlayOneShot(DamageSE);
            
        }
        //もしもぶつかった火災旋風のTagが"FS"であったならば（条件）
        if (t.gameObject.tag == "SW" && Invincibleflg == false)
        {
            //被ダメージのアニメーションを再生
            animator.SetBool("Damageing", true);
            //HPを2ずつ減少させる
            HP -= 2;
            OnDamageEffect();//この関数に移動
            Invincibleflg = true;//無敵時間になるフラグオン
            //ダメージを受けた時にSEを鳴らす
            audioSource.PlayOneShot(DamageSE);
            
        }


    }



    void OnDamageEffect()   //ダメージエフェクト関係
    {
        shooting2.Stopflg = true;   //泡の発射を止める
        playerContoller_8.Stopflg = true;   //プレイヤーの動きを止める
        //if (HP > 0) //HPが0よりも多ければ通る
        //{
        //    DamageObject.SetActive(true);//ダメージのオブジェクトを表示する
        //}
        //else if (HP <= 0) //HPが0よりも多ければ通る
        //{
        //    DamageObject.SetActive(false);//ダメージのオブジェクトを表示する
        //}
//        iTween.MoveTo(gameObject, iTween.Hash(
//"position", transform.position - (transform.forward * 1.2f - transform.up * 0f),
//                "time", g_time,
//"easetype", iTween.EaseType.linear,
//"oncomplete", "onInvincibleState",
//"oncompletetarget", gameObject
//                //"oncompleteparams", GameConstants.DAMAGE_INVINCIBLE_TIME

//));
       // }
        //ExitDamageEffect();
    }

    void ExitStopShoot()   //撃てない状態から
    {
        if (HP > 0 && timeScript.timeEndflg == false) //HPが0よりも多ければ通る
        {
            shooting2.Stopflg = false;  //泡が撃てるようにする
        }
        if (HP > 0) //HPが0よりも多ければ通る
        {
            DamageObject.SetActive(true);//ダメージのオブジェクトを表示する
        }
        //if (NoUseFadeOutflg == false)
        //{
        //    if (fadeOutImage.FadeEndflg == true)    //FadeOutが終われば通る
        //    {
        //        shooting2.Stopflg = false;  //泡が撃てるようにする
        //    }
        //}
       //被ダメージのアニメーションをオフ
       animator.SetBool("Damageing", false);
    }

    void ExitStopMove()   //動けない状態から
    {
        if (HP > 0 && timeScript.timeEndflg == false) //HPが0よりも多ければ通る
        {
            playerContoller_8.Stopflg = false;  //プレイヤーが動けるようにする
        }

        //if (NoUseFadeOutflg == false)
        //{
        //    if (fadeOutImage.FadeEndflg == true)    //FadeOutが終われば通る
        //    {
        //        playerContoller_8.Stopflg = false;  //プレイヤーが動けるようにする
        //    }
        //}
    }

    void GoToGameOver()
    {
        if (Stage1 == true && Stage2 == false && Stage3 == false && BossStage == false)
        {
            SceneManager.LoadScene("GameOver");
        }
       else if (Stage1 == false && Stage2 == true && Stage3 == false && BossStage == false)
        {
            SceneManager.LoadScene("GameOver2");
        }
       else if (Stage1 == false && Stage2 == false && Stage3 == true && BossStage == false)
        {
            SceneManager.LoadScene("GameOver3");
        }
       else if (Stage1 == false && Stage2 == false && Stage3 == false && BossStage == true)
        {
            SceneManager.LoadScene("GameOverBoss");
        }
        else
        {
            Debug.LogError("正しくトリガーが入力されていないので、ゲームオーバー出来ません。");
        }

       // SceneManager.LoadScene("GameOver");

    }
}
