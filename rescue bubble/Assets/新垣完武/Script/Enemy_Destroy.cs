using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Destroy : MonoBehaviour {


    //GameObject enemy; //オブジェクトを入れる変数名

    EnemyStatus script; //スプリクトを入れる変数名


    //エフェクト
    public Syouka syouka;

    private float BeforeDestroy2 = 1.0f;
    private float DestroyTime = 1.1f;
    private float currentTime = 0.0f;
    bool BeforeDestroy =false;
    bool EnemyDestroy = false;

    //エネミーが目標サイズに達するまでの秒数
    [SerializeField] private float EnemyTime;

    [SerializeField] private float maxSpeed;        //エネミーが大きくなる速さ
    [SerializeField] private Vector3 EnemyScale;    //目標の大きさ
    //[SerializeField] private Vector3 EnemyLine;
    //[SerializeField] private Vector3 EnemyShootScale = new Vector3(1.0f, 1.0f, 1.0f);

    private Vector3 EnemyVelocity;

    // Use this for initialization
    void Start () {

        //enemy = GameObject.Find("Enemy"); //
        script = GetComponent<EnemyStatus>();
        

    }
	
	// Update is called once per frame
	void Update () {

        

        if(BeforeDestroy == true)
        {
            currentTime += Time.deltaTime;
            //Debug.Log("oh my god");
            //var Scale = Vector3.SmoothDamp(gameObject.transform.localScale, EnemyScale, ref EnemyVelocity, EnemyTime, maxSpeed);
            //gameObject.transform.localScale = Scale;
            var Scale_x = Mathf.SmoothDamp(gameObject.transform.localScale.x, EnemyScale.x, ref EnemyVelocity.x, EnemyTime, maxSpeed);
            var Scale_y = Mathf.SmoothDamp(gameObject.transform.localScale.y, EnemyScale.y, ref EnemyVelocity.y, EnemyTime, maxSpeed);
            var Scale_z = Mathf.SmoothDamp(gameObject.transform.localScale.z, EnemyScale.z, ref EnemyVelocity.z, EnemyTime, maxSpeed);
            var Scale = new Vector3(Scale_x, Scale_y, Scale_z);

            this.gameObject.transform.localScale = Scale;

            Debug.Log(gameObject.transform.localScale);
            //Debug.Log(currentTime);

            if (BeforeDestroy2 < currentTime)
            {
                this.gameObject.transform.localScale = new Vector3(100, 100, 100);
                Debug.Log("aa");
                EnemyDestroy = true;
            }
            if(DestroyTime <currentTime)
            {
                
                Destroy(gameObject);
                Instantiate(syouka, this.transform.position, Quaternion.identity);
            }
        }

        //currentTime += Time.deltaTime;
        if (script.enemy_hp <= 0)
        {
            BeforeDestroy = true;
            //Destroy(gameObject);
          
        }

        
	}
}
