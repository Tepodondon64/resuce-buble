using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller_6 : MonoBehaviour {

    //インスペクターで設定する
    public float speedX;
    //public float speedY;
    public float speedZ;
    //プライベート変数
    // private Animator anim = null;
    private Rigidbody rb = null;

    private Transform tf = null;
    //追加した変数↓
    public float rotAngle = 0f;
    //private BoxCollider2D // = null;
    //追加した変数↑

    // Use this for initialization
    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        // anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        //bc = GetComponent<BoxCollider2D>();
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);//画像の傾き
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localRotation = Quaternion.Euler(0f, 0f, rotAngle-4f);//画像の傾き
        Sayuu();
        Jouge();
    }


    void Sayuu()
    {
        //左右キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        //if (horizontalKey == 0) rotAngle = 0f;
        if (horizontalKey > 0)
        {
            //rotAngle -= 4f;
            transform.localRotation = Quaternion.Euler(0, 90, 0);//画像が右向きに傾き
            xSpeed = speedX;
        }
        else if (horizontalKey < 0)
        {
            //rotAngle += 4f;

            transform.localRotation = Quaternion.Euler(0, -90, 0);//画像が左向きに傾き
            xSpeed = -speedX;
        }
        else
        {
            //  anim.SetBool("run", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector3(xSpeed, rb.velocity.y, rb.velocity.z);
    }

    void Jouge()
    {
        //Transform target;
       // Quaternion q = Quaternion.LookRotation(target.position);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotAngle * Time.deltaTime); 

        //上下キー入力されたら行動する
        float verticalKey = Input.GetAxis("Vertical");
        float zSpeed = 0.0f;
        if (verticalKey > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);//画像が前向きに傾き//ポジティブっていいよね
            //.offset = new Vector3(0, +2);

            //  anim.SetBool("run", true);
            zSpeed = speedZ;
        }
        else if (verticalKey < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);//画像が後向きに傾き//ネガティブにならないで
            //.offset = new Vector3(0, +2);

            //  anim.SetBool("run", true);
            zSpeed = -speedZ;
        }
        else
        {
            //  anim.SetBool("run", false);
            zSpeed = 0.0f;
        }

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, zSpeed);
    }
}
