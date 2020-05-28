using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller_8 : MonoBehaviour {

    //インスペクターで設定する
    public float speedX;
    public float speedZ;

    //プライベート変数
    private Rigidbody rb = null;
    public int horizontalKeyflg = 0;//右:1、左:-1 無:0
    public int verticalKeyflg = 0;//上:1、下:-1   無:0(前、後ろ)

    private bool MukiDebug_flg = false; //傾きのデバッグ文字を表示するのか？(false:非表示    true:表示)

    //他のスクリプトでいじれるやつ
    public bool Stopflg; //ノックバック中にtrueになる

    //Animator を入れる変数
    private Animator animator;

    //効果音の設定
    private GameObject MoveSE_Object; //足音を入れるための変数


	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);//画像の傾き
       // Stopflg = false;//falseのときは特になにもないが、trueになるとボタン操作を受付なくなる

        //Playerの Animator にアクセスする
        animator = GetComponent<Animator>();

        MoveSE_Object = transform.Find("MoveSE_Object").gameObject;//子オブジェクトのMoveSE_Objectを入れる
        MoveSE_Object.SetActive(false);//子オブジェクトを非表示にして無理やり足音を消すぜ

	}
	
	// Update is called once per frame
	void Update () {
        KeyMove();
	}

    void KeyMove()
    {
        Muki();
        //左右キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal")/* * Time.deltaTime * speedX */;
        float xSpeed = 0.0f;

        //上下キー入力されたら行動する
        float verticalKey = Input.GetAxis("Vertical")/* * Time.deltaTime * speedZ */;
        float zSpeed = 0.0f;


        if (horizontalKeyflg != 0 || verticalKeyflg != 0)//上下右左をいずれか押してなければ
        {
            //走るアニメーションを再生
            animator.SetBool("Running", true);
            //発射アニメーションをオフ
            animator.SetBool("Shooting", false);

            //発射時にショットSEを鳴らす
            //audioSource.PlayOneShot(MoveSE);
            MoveSE_Object.SetActive(true);//子オブジェクトを表示させて足音を起動させる。
        }
        else//上下右左をいずれか押していれば
        {
            //走るアニメーションはオフ
            animator.SetBool("Running", false);
            MoveSE_Object.SetActive(false);//子オブジェクトを非表示にして足音を起動させる。
        }

        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    animator.SetTrigger("Shooting");
        //}


        if (horizontalKey > 0 && Stopflg == false)//右
        {
            horizontalKeyflg = 1;//右判定
            xSpeed = speedX;
        }



        else if (horizontalKey < 0 && Stopflg == false)//左
        {
            horizontalKeyflg = -1;//左判定     
            xSpeed = -speedX;
        }


        else
        {
            //  anim.SetBool("run", false);
            horizontalKeyflg = 0;//右、左押してない
            xSpeed = 0.0f;
        }


        if (verticalKey > 0 && Stopflg == false)//上
        {

            verticalKeyflg = 1;//上(前方向)
            //  anim.SetBool("run", true);
            zSpeed = speedZ;
        }
        else if (verticalKey < 0 && Stopflg == false)//下
        {

            verticalKeyflg = -1;//下(後ろ方向)
            zSpeed = -speedZ;
        }
        else
        {
            verticalKeyflg = 0;//上、下押してない
            zSpeed = 0.0f;
        }

        rb.velocity = new Vector3(xSpeed, rb.velocity.y, zSpeed);
    }

    void Muki()
    {

        //十字方向→←↑↓
        if (horizontalKeyflg == 1 && verticalKeyflg == 0)//右→
        {
            if (MukiDebug_flg == true) Debug.Log("右が入力されてるよ");

            transform.localRotation = Quaternion.Euler(0, 90, 0);//画像が右向きに傾き
        }

        if (horizontalKeyflg == -1 && verticalKeyflg == 0)//左←
        {
            if (MukiDebug_flg == true) Debug.Log("左が入力されてるよ");
            transform.localRotation = Quaternion.Euler(0, -90, 0);//画像が左向きに傾き
        }

        if (verticalKeyflg == 1 && horizontalKeyflg == 0)//上↑
        {
            if (MukiDebug_flg == true) Debug.Log("上が入力されてるよ");
            transform.localRotation = Quaternion.Euler(0, 0, 0);//画像が前向きに傾き//ポジティブっていいよね
        }

        if (verticalKeyflg == -1 && horizontalKeyflg == 0)//下↓
        {
            if (MukiDebug_flg == true) Debug.Log("下が入力されてるよ");
            transform.localRotation = Quaternion.Euler(0, 180, 0);//画像が後ろ向きに傾き//ネガティブにならないで
        }

        ////斜め方向↗↖↘↙
        if (horizontalKeyflg == 1 && verticalKeyflg == 1)//右上→↑
        {
            if (MukiDebug_flg == true) Debug.Log("右上が入力されてるよ");
            transform.localRotation = Quaternion.Euler(0, 45, 0);//画像が右上向きに傾き
        }

        if (horizontalKeyflg == -1 && verticalKeyflg == 1)//左上←↑
        {
            if (MukiDebug_flg == true) Debug.Log("左上が入力されてるよ");
            transform.localRotation = Quaternion.Euler(0, -45, 0);//画像が左上向きに傾き
        }

        if (horizontalKeyflg == 1 && verticalKeyflg == -1)//右下→↑
        {
            if (MukiDebug_flg == true) Debug.Log("右下が入力されてるよ");
            transform.localRotation = Quaternion.Euler(0, 135, 0);//画像が右下向きに傾き
        }

        if (horizontalKeyflg == -1 && verticalKeyflg == -1)//左下←↓
        {
            if (MukiDebug_flg == true) Debug.Log("左下が入力されてるよ");
            transform.localRotation = Quaternion.Euler(0, -135, 0);//画像が左下向きに傾き
        }

    }
}
