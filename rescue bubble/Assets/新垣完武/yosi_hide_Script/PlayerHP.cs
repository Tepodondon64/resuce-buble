using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour {

    public int HP;
    private int InvincibleTime;//無敵時間
    private int Time = 120;//無敵時間の値、初期化するために使う変数
    private bool Invincibleflg; //無敵フラグ

    private Rigidbody rb;
    private Transform tf;
    const float GameConstants = 10;
    double  DAMAGE_RESET_TIME = 0.4;
   // public GameObject Enemy;

    ////効果音の設定
    AudioSource audioSource;    //オーディオを所得するための変数
    public AudioClip DamageSE;         //プレイヤーがダメージを受けた時のSE


    Transform player;
    bool knock_back;   //←こちら、Playerの子オブジェクトのBack_collisionのスクリプトのbackTriggerを入れるための変数です。
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        


        //Componentを取得
        audioSource = GetComponent<AudioSource>();//AudioのComponentを取得
        player =this.gameObject.GetComponent<Transform>(); //playerのTransformを取得
        Invincibleflg = false;
        InvincibleTime = Time;

        //knock_back = transform.GetChild(0).gameObject.GetComponent<Back_collision>().backTrigger;

        

    }

    void Update()
    {
        //Debug.Log(InvincibleTime);
        Invincible();
        GameOver();
        knock_back = transform.GetChild(0).gameObject.GetComponent<Back_collision>().backTrigger;

        // ２秒後にFadeIn()を、５秒後にFadeOut()を呼び出す
        Invoke("FadeIn", 2f);
        Invoke("FadeOut", 5f);

    }

    void Invincible()
    {
        if (Invincibleflg == true)  //敵に当たったら反応する
        {
            //iTween.ValueTo(gameObject, iTween.Hash("from", 1f, "to", 0f, "time", 1f, "onupdate", "SetValue"));
            //iTween.ColorTo(gameObject, iTween.Hash("a", 0.5f, "time", 1.0, "loopType", "pingpong"));
            //iTween.ColorTo(gameObject, iTween.Hash("a", 1.0f, "time", 0.5f, "loopType", "pingpong"));
            //iTween.ColorTo(gameObject, iTween.Hash("r", 0.7f, "g", 0.7f, "b", 0.7f, "time", 0.5f, "loopType", "pingpong"));
           // Debug.Log(InvincibleTime);
            if (--InvincibleTime < 0)   //この時間が無くなったら無敵時間は終了する
            {
                Invincibleflg = false;
                InvincibleTime = Time;
            }
        }
        if (Invincibleflg == true)  //敵に当たったら反応する
        {
        }
        ///////

        ///////
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
                if (knock_back == true)//後ろ側が壁だったら
                {
                    iTween.MoveTo(gameObject, iTween.Hash(
          "position", transform.position + (transform.up * 2f),
                          "time", 0.4,
          "easetype", iTween.EaseType.linear,
          "oncomplete", "onInvincibleState",
          "oncompletetarget", gameObject
                        //"oncompleteparams", GameConstants.DAMAGE_INVINCIBLE_TIME

      ));  
                }
                else//後ろ側に壁が無かったら
                {
                    iTween.MoveTo(gameObject, iTween.Hash(
        "position", transform.position - (transform.forward * 2f - transform.up * 2f),
                        "time", 0.4,
        "easetype", iTween.EaseType.linear,
        "oncomplete", "onInvincibleState",
        "oncompletetarget", gameObject
                        //"oncompleteparams", GameConstants.DAMAGE_INVINCIBLE_TIME

    ));
                }

                //foreach (ContactPoint contact in other.contacts)
                //{
                //   // Debug.Log(contact.point);
                //}
                //Debug.Log(_Rotation);
                Invincibleflg = true;

                //ダメージを受けた時にSEを鳴らす
                audioSource.PlayOneShot(DamageSE);
                //HPを１ずつ減少させる
                HP -= 1;

                //Transform player.position - (transform.forward * 10f);
                // player.position = player.position;
            }
            
    }

    void OnCollisionStay(Collision other)//当たっている間
    {

        //もしもぶつかった相手のTagが"Enemy"であったならば（条件） 
        if (other.gameObject.CompareTag("Enemy") && Invincibleflg == false)
        {
            if (knock_back == true)//後ろ側が壁だったら
            {
                iTween.MoveTo(gameObject, iTween.Hash(
      "position", transform.position + (transform.up * 2f),
                      "time", 0.4,
      "easetype", iTween.EaseType.linear,
      "oncomplete", "onInvincibleState",
      "oncompletetarget", gameObject
                    //"oncompleteparams", GameConstants.DAMAGE_INVINCIBLE_TIME

  ));
            }
            else//後ろ側に壁が無かったら
            {
                iTween.MoveTo(gameObject, iTween.Hash(
    "position", transform.position - (transform.forward * 2f - transform.up * 2f),
                    "time", 0.4,
    "easetype", iTween.EaseType.linear,
    "oncomplete", "onInvincibleState",
    "oncompletetarget", gameObject
                    //"oncompleteparams", GameConstants.DAMAGE_INVINCIBLE_TIME

));
            }

            //foreach (ContactPoint contact in other.contacts)
            //{
            //   // Debug.Log(contact.point);
            //}
            //Debug.Log(_Rotation);
            Invincibleflg = true;

            //ダメージを受けた時にSEを鳴らす
            audioSource.PlayOneShot(DamageSE);
            //HPを１ずつ減少させる
            HP -= 1;

            //Transform player.position - (transform.forward * 10f);
            // player.position = player.position;
        }

       // Debug.Log("当たっている");
    }

    void GoToGameOver()
    {
            SceneManager.LoadScene("GameOver");
        
    }

    //protected IEnumerator onInvincibleState(float time)
    //{
    //    iTween.FadeTo(gameObject, iTween.Hash(
    //        "name", "invincible",
    //        "alpha", 0.1f,
    //        "time", 0.1f,
    //        "looptype", iTween.LoopType.loop
    //    ));

    //    yield return new WaitForSeconds(time);

    //    Invincibleflg = false;
    //    //iTween.StopByName("invincible");

    //    iTween.FadeTo(gameObject, iTween.Hash(
    //        "alpha", 1f,
    //        "time", 0f
    //    ));
    //}
    //void FadeIn()
    //{
    //    // SetValue()を毎フレーム呼び出して、１秒間に０から１までの値の中間値を渡す
    //    iTween.FadeTo(gameObject, iTween.Hash("from", 0f, "to", 1f, "time", 1f, "onupdate", "SetValue"));
    //}
    //void FadeOut()
    //{
    //    // SetValue()を毎フレーム呼び出して、１秒間に１から０までの値の中間値を渡す
    //    iTween.FadeTo(gameObject, iTween.Hash("from", 1f, "to", 0f, "time", 1f, "onupdate", "SetValue"));
    //}
    //void SetValue(float alpha)
    //{
    //    // iTweenで呼ばれたら、受け取った値をImageのアルファ値にセット
    //    gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, alpha);
    //}
}
