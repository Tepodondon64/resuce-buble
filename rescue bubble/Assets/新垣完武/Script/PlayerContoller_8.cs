using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller_8 : MonoBehaviour {

    //インスペクターで設定する
    public float speedX;
    public float speedZ;

    //プライベート変数
    private Rigidbody rb = null;
    private int horizontalKeyflg = 0;//右:1、左:-1 無:0
    private int verticalKeyflg = 0;//上:1、下:-1   無:0(前、後ろ)

    private bool MukiDebug_flg = false; //傾きのデバッグ文字を表示するのか？(false:非表示    true:表示)

    //他のスクリプトでいじれるやつ
    public bool Stopflg; //ノックバック中にtrueになる



    //Animator を入れる変数
    private Animator animator;


	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);//画像の傾き
        Stopflg = false;//falseのときは特になにもないが、trueになるとボタン操作を受付なくなる



        //ユニティちゃんの Animator にアクセスする
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        KeyMove();
	}

    void KeyMove()
    {
        Muki();
        //左右キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        //上下キー入力されたら行動する
        float verticalKey = Input.GetAxis("Vertical");
        float zSpeed = 0.0f;

        if (horizontalKeyflg != 0 || verticalKeyflg != 0)//右→
        {
            //走るアニメーションを再生
            animator.SetBool("Running", true);
        }
        else
        {
            //走るアニメーションはオフ
            animator.SetBool("Running", false);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("Shooting");
        }


        if (horizontalKey > 0 && Stopflg == false)//右
        {
            //動いた時に動くSEを鳴らす
            // audioSource.PlayOneShot(MoveSE);
            horizontalKeyflg = 1;//右判定
            xSpeed = speedX;
        }



        else if (horizontalKey < 0 && Stopflg == false)//左
        {
            //動いた時に動くSEを鳴らす
            //  audioSource.PlayOneShot(MoveSE);
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
            //動いた時に動くSEを鳴らす
            // audioSource.PlayOneShot(MoveSE);
            verticalKeyflg = 1;//上(前方向)
            //  anim.SetBool("run", true);
            zSpeed = speedZ;
        }
        else if (verticalKey < 0 && Stopflg == false)//下
        {
            //動いた時に動くSEを鳴らす
            // audioSource.PlayOneShot(MoveSE);
            verticalKeyflg = -1;//下(後ろ方向)
            //  anim.SetBool("run", true);
            zSpeed = -speedZ;
        }
        else
        {
            //  anim.SetBool("run", false);
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
