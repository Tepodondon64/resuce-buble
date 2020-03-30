using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Broken : MonoBehaviour
{
    //体力
    //private int enemyhp;

    //体力//float型に変更
    // private float enemyhp = 10;

    public float enemyhp = 10;

    private float bullet_power;//通常弾の攻撃力
    private float chargebullet_power = 2;//チャージショットの攻撃力//現状Enemyだと多段ヒット扱いで4ダメージ ？　＊　２　＝　ダメージ

    public float SP_power = 0;//

    //public float EnemyHp//別のスクリプトと変数を連携出来るようになる
    //{
    //    get { return this.enemyhp; }  //取得用
    //    private set { this.enemyhp = value; }　//値入力用
    //}

    //Debug.Log("チャージショットをエネミーが食らいました");//
    int count = 0;
    int count2 = 0;
    void Start()
    {
        // enemyhp = 1;
        Debug.Log(enemyhp);//10
    }
    void OnCollisionEnter(Collision other)//当たった瞬間
    {
        Debug.Log(other.gameObject.tag);//
        if (other.gameObject.tag == "Bullet")//通常弾に当たったとき
        {
            bullet_power = 1;
            //Destroy(gameObject, 0.2f);
            enemyhp = enemyhp - bullet_power;
            if (enemyhp <= 0)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                this.tag = "Bubble";

            }
        }

        //if (other.gameObject.tag == "ChargeBullet")//チャージ弾に当たったとき
        //{
        //    //Destroy(gameObject, 0.2f);
        //    enemyhp = enemyhp - chargebullet_power;
        //    if (enemyhp <= 0)
        //    {
        //        gameObject.GetComponent<Renderer>().material.color = Color.red;
        //        this.tag = "Bubble";

        //    }
        //}

    }

    void OnTriggerEnter(Collider other)//当たった瞬間 isTriggerあり
    {
        //Debug.Log(enemyhp);//
        Debug.Log(other.gameObject.tag);//弾タグ確認する用

        if (other.gameObject.tag == "Bullet")//通常弾に当たったとき
        {
            bullet_power = 1f;
            //Destroy(gameObject, 0.2f);
            enemyhp = enemyhp - bullet_power;
            if (enemyhp <= 0)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                this.tag = "Bubble";

            }
        }

        if (other.gameObject.tag == "ChargeBullet")//チャージ弾に当たったとき
        {
            //Destroy(gameObject, 0.2f);
            enemyhp = enemyhp - chargebullet_power;
            if (enemyhp <= 0)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                this.tag = "Bubble";

            }
        }
    }

    void Update()
    {

        //Debug.Log(enemyhp);//
        //Debug.Log(enemyhp);//
        Transform myTransform = this.transform;


        // 座標を取得
        Vector3 pos = myTransform.position;


        if (enemyhp <= 0)
        {
            if (count <= 5)
            {
                //if (pos.y <= -2)
                //{
                pos.y += 2f;    // y座標へ2加算
                //}

                //InvokeRepeating("Objectdown", 5,1);
                Invoke("Objectdown", 5);
                myTransform.position = pos;  // 座標を設定
                count++;

            }
        }

    }


    void Objectdown()
    {
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        if (enemyhp <= 0)
        {
            if (count2 <= 5)
            {

                pos.y -= 2.0f;    // y座標へ2加算

                myTransform.position = pos;  // 座標を設定
                //InvokeRepeating("CountReset", 5, 1);
                count2++;

            }
            myTransform.position = pos;  // 座標を設定
            Invoke("CountReset", 1);
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
            //Invoke("cancel", 5);
        }
    }
    void CountReset()
    {
        enemyhp = 1;
        count = 0;
        count2 = 0;
        this.tag = "Enemy";
        this.tag = "move obj";
    }

    //void cancel()
    //{
    //    CancelInvoke("CountReset");
    //}
}
