using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tossin : MonoBehaviour
{

    //Vector3 tmpE;                        //プレイヤーの位置情報をここに入れる 
    //Vector3 t;
    //public Transform hogeEne;
    //int Ecnt = 0;                       //フラグ立てに使う
    //float calcZ = 0;                    //敵とプレイヤーの距離を測るのに使う
    GameObject Player;
    private float targetTime = 6.0f;
    private float currentTime = 0;
    //public Material material;
    public Transform _target;
    private AttackMotion AM;
    private Animator animator;

    //public GameObject Enemy;
    public float speed;
    private Vector3 vec;
    private Vector3 pos;
    private Rigidbody rb;

    //効果音の設定
    AudioSource audioSource;                //オーディオを取得するための変数
    //public AudioClip TossinSE;              //突進時に再生させるための変数
    
    void Start()
    {
        Player = GameObject.Find("Player");
        //vec = Player.transform.position;
        AM = gameObject.GetComponent<AttackMotion>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();      //AudioのComponentの取得
    }

    void Update()
    {
        
        currentTime += Time.deltaTime;
        if (targetTime < currentTime)
        {
            animator.SetBool("tossin", true);

            //敵（イノシシ）の座標を変数posに保存
            pos = this.gameObject.transform.position;

            //プレイヤーの方を向く
            Vector3 target = _target.position;
            target.y = this.transform.position.y;
            this.transform.LookAt(target);

            AM.enabled = false;
            //Vector3 force = new Vector3(0.0f, target.y, target.z-2.0f);

            //現在の速度をログに表示
            //Debug.Log(rb.velocity.magnitude);

            //this.GetComponent<Renderer>().material.color = Color.white;


            //currentTime = 0;

            //敵からプレイヤーに向かうベクトルをつくる
            //プレイヤーの位置から敵の位置（弾の位置）を引く
            //this.calcZ = pos.z - Player.transform.position;
            Vector3 vec = Player.transform.position - pos;

            //弾のRigidBodyコンポネントのvelocityに先程求めたベクトルを入れて力を加える
            gameObject.GetComponent<Rigidbody>().velocity = vec;
            //GetComponent<Rigidbody>().AddForce(Player.transform.position * speed, ForceMode.Force);

            //突進時に音を再生する
            //audioSource.PlayOneShot(TossinSE);

            //float step = speed * Time.deltaTime;

            //Invoke("Attack", 1.0f);

            //Vector3 playerpos = this.Player.transform.position;                 //player位置情報取得する
            //this.calcZ = this.transform.position.z - playerpos.z;               //敵のZ座標からボールのZ座標を引く。これで距離が出る

            //tmpE = hogeEne.transform.position;                                  //プレイヤーの位置情報をvector3でtmpに格納
            //this.transform.position = t;

        }
    }
    void Attack()
    {
        //transform.position = Vector3.MoveTowards(pos, Player.transform.position, speed);
    }
}