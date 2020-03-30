using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Destroy : MonoBehaviour {

    private float losttime = 60;//出現して1秒後に消える
    //[SerializeField] private GameObject player; //オブジェクトを入れる変数名
    private GameObject player; //オブジェクトを入れる変数名

    Shooting script; //スプリクトを入れる変数名
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player"); //プレイヤーの中に入っている、
        script = player.GetComponent<Shooting>();//Shootingスクリプトを読み込む。
        script.bullet_Count++;//弾が出たらカウントを1追加する
	}
	
	// Update is called once per frame
	void Update () {
        
        losttime -= 1;
        if(losttime <= 0){
            losttime = 0;
            Destroy(gameObject,losttime);
            script.bullet_Count--;//弾が消えたらカウントを1減らす
         //   script2.bullet_Count--;//弾が消えたらカウントを1減らす
        }
        //if (GetComponent<SphereCollider>().isTrigger == true)
        //{
        //    GetComponent<SphereCollider>().isTrigger = false;
        //}

	}
    //void OnCollisionEnter(Collision collision)//他のcollider/rigidbodyに触れたとき
    //{
    //    if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "ChargeBullet"
    //        || collision.gameObject.tag == "Player")//玉が玉に当たったら(チャージ弾も含む)または、玉がプレイヤーに当たったら
    //    {

    //        GetComponent<SphereCollider>().isTrigger = true;//すり抜けるようにする

    //    }
    //    if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "ChargeBullet"
    //        && collision.gameObject.tag != "Player")//玉(チャージ弾も含む)が玉とプレイヤー以外に当たったら
    //    {
    //        GetComponent<SphereCollider>().isTrigger = false;//ぶつかるようにする
    //        //Destroy(this.gameObject);
    //        Destroy(gameObject);
    //        script.bullet_Count--;//弾が消えたらカウントを1減らす
    //      //  script2.bullet_Count--;//弾が消えたらカウントを1減らす
    //    }
    //}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            script.bullet_Count--;//弾が消えたらカウントを1減らす
            Debug.Log("君は今、壁に攻撃した");//
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            script.bullet_Count--;//弾が消えたらカウントを1減らす
            //script.SP_power = 4;
            Debug.Log("君は今、敵に攻撃した");//
        }

        if (collision.gameObject.tag == "move obj")
        {
            Destroy(gameObject);
            script.bullet_Count--;//弾が消えたらカウントを1減らす
            Debug.Log("君は今、動くオブジェクトに攻撃した");//       
        }

        // Destroy(gameObject);
    }
}
