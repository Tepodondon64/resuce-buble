﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inosisi : MonoBehaviour {

    GameObject Player;
    public Transform ttarget;

    private float targetTime = 6.0f;
    private float currentTime = 0;
    //public Material material;
    public Transform _target;
    private AttackMotion AM;
    private Animator animator;

    public float second;

    bool tosinnn = false;

    //public GameObject Enemy;
    public float speed;
    private Vector3 vec;
    private Vector3 pos;
    private Rigidbody rb;

    //効果音の設定
    AudioSource audioSource;                //オーディオを取得するための変数
    public AudioClip TossinSE2;              //突進時に再生させるための変数
    public float volume;

    // Use this for initialization
    void Start () {
        ttarget = GameObject.Find("Player").transform; ;
        StartCoroutine("tosin1");
        AM = gameObject.GetComponent<AttackMotion>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();      //AudioのComponentの取得

        tosinnn = true;

        //足音呼び出し
        //InvokeRepeating("SEsan", 6, 2);
       // audioSource.volume = volume;

    }

    // Update is called once per frame
    void Update () {
        Transform myTransform = this.transform;
    }

    IEnumerator tosin1()
    {
        yield return new WaitForSeconds(0);

        ////敵（イノシシ）の座標を変数posに保存
        //pos = this.gameObject.transform.position;

        Debug.Log("よお");
        ////プレイヤーの方を向く
        //Vector3 target = _target.position;
        //target.y = this.transform.position.y;
        this.transform.LookAt(ttarget.transform);

        //AM.enabled = false;

        ////弾のRigidBodyコンポネントのvelocityに先程求めたベクトルを入れて力を加える
        //gameObject.GetComponent<Rigidbody>().velocity = vec;

        second = 200;
        animator.SetBool("tossin", false);
        yield return new WaitForSeconds(1);
        StartCoroutine("tosin2");

        
    }

    IEnumerator tosin2()
    {

        

        // ループ
        while (true)
        {
            //弾のRigidBodyコンポネントのvelocityに先程求めたベクトルを入れて力を加える
            //Vector3 vec = Player.transform.position - pos;
            //gameObject.GetComponent<Rigidbody>().velocity = vec;
            yield return new WaitForSeconds(0.0001f);
            animator.SetBool("tossin", true);
            transform.position += transform.forward * speed;
            Debug.Log("loop");
            second--;

            if(second < 0)
            {
                break;
            }
                    //tosinnn = false;
        }

        yield return new WaitForSeconds(1);
        StartCoroutine("tosin1");
    }
}
