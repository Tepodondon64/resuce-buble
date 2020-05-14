using System.Collections;
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


    Transform player;   //プレイヤーのトランスフォーム取得
    //bool knock_back;   //←こちら、Playerの子オブジェクトのBack_collisionのスクリプトのbackTriggerを入れるための変数です。

    MeshRenderer PlayerMr;//マテリアルの情報を入れるための変数
    MeshRenderer OriginMr;//元々のマテリアルの情報を入れるための変数

    float alpha_Sin;    //新しいalpha値を入れるための変数


    //スクリプトの取得//
    Shooting2 shooting2;
    PlayerContoller_8 playerContoller_8;

    //Animator を入れる変数
    private Animator animator;

    void Start()
    {
        //外部のスクリプトの情報を取得
        shooting2 = GetComponent<Shooting2>();//Shooting2スクリプトの取得
        playerContoller_8 = GetComponent<PlayerContoller_8>();//PlayerContoller_7スクリプトの取得

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
            }
        }
        if (Invincibleflg == false)  //敵には当たってなければ
        {
        }
        ///////敵に当たったら反応する奴↓↓

        if (shooting2.Stopflg == true)
        {
            //ExitStopShootを0.6秒後に呼び出す//ちなみにノックバックは0.4秒で終わります。
            Invoke("ExitStopShoot", 0.6f);
            
        }

        if (playerContoller_8.Stopflg == true)
        {
            //ExitStopMoveを0.6秒後に呼び出す//ちなみにノックバックは0.4秒で終わります。
            Invoke("ExitStopMove", 0.6f);
        }

    }

    void GameOver()
    {
        if (HP <= 0)
        {
            // 1.5秒後に「GoToGameOver()」メソッドを実行する。
            Invoke("GoToGameOver", 1.5f);
        }
    }

    void OnCollisionEnter(Collision other)//当たった瞬間
    {

        Vector3 _Rotation = player.transform.localEulerAngles;

        //もしもぶつかった相手のTagが"Enemy"であったならば（条件） 
        if (other.gameObject.CompareTag("Enemy") && Invincibleflg == false)
        {
            //被ダメージのアニメーションを再生
            animator.SetBool("Damageing", true);


            OnDamageEffect();//この関数に移動
            Invincibleflg = true;//無敵時間になるフラグオン

            //ダメージを受けた時にSEを鳴らす
            audioSource.PlayOneShot(DamageSE);
            //HPを１ずつ減少させる
            HP -= 1;
        }

    }

    void OnCollisionStay(Collision other)//当たっている間(体当たりしてくるエネミーにぶつかり続けてもダメージが食らうように作ったもの)
    {

        //もしもぶつかった相手のTagが"Enemy"であったならば（条件） 
        if (other.gameObject.CompareTag("Enemy") && Invincibleflg == false)
        {
            //被ダメージのアニメーションを再生
            animator.SetBool("Damageing", true);


            OnDamageEffect();//この関数に移動
            Invincibleflg = true;//無敵時間になるフラグオン

            //ダメージを受けた時にSEを鳴らす
            audioSource.PlayOneShot(DamageSE);

            //HPを１ずつ減少させる
            HP -= 1;
        }

    }

    void OnTriggerEnter(Collider t)//FB
    {
        //もしもぶつかったFBのTagが"FB"であったならば（条件）
        if (t.gameObject.tag == "FB")
        {
            //被ダメージのアニメーションを再生
            animator.SetBool("Damageing", true);

            OnDamageEffect();//この関数に移動
            Invincibleflg = true;//無敵時間になるフラグオン

            //ダメージを受けた時にSEを鳴らす
            audioSource.PlayOneShot(DamageSE);
            //HPを1ずつ減少させる
            HP -= 1;
        }

    }



    void OnDamageEffect()   //ダメージエフェクト関係
    {
        shooting2.Stopflg = true;   //泡の発射を止める
        playerContoller_8.Stopflg = true;   //プレイヤーの動きを止める
        iTween.MoveTo(gameObject, iTween.Hash(
"position", transform.position - (transform.forward * 1.2f - transform.up * 0f),
                "time", g_time,
"easetype", iTween.EaseType.linear,
"oncomplete", "onInvincibleState",
"oncompletetarget", gameObject
                //"oncompleteparams", GameConstants.DAMAGE_INVINCIBLE_TIME

));
       // }
        //ExitDamageEffect();
    }

    void ExitStopShoot()   //撃てない状態から
    {
       shooting2.Stopflg = false;  //泡が撃てるようにする
       //被ダメージのアニメーションをオフ
       animator.SetBool("Damageing", false);
    }

    void ExitStopMove()   //動けない状態から
    {
       playerContoller_8.Stopflg = false;  //プレイヤーが動けるようにする
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");

    }
}
