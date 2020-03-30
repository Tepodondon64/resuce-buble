using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBullet_Destroy : MonoBehaviour {

    private float losttime = 60 * 10;//出現して2秒後に消える　60 * １　＝　１秒
    //[SerializeField] private GameObject player; //オブジェクトを入れる変数名
    private GameObject player; //オブジェクトを入れる変数名

    private CapsuleCollider bullet;
    private int test1 ;
    private int test2 ;

    private const float avaoid_time = 1f;  //すり抜ける時間
    private float avoid_time;  //すり抜ける時間

    Broken script;//スプリクトを入れる変数名

    // Use this for initialization
    void Start()
    {
        //bullet.isTrigger = false;
        player = GameObject.Find("Player"); //プレイヤーの中に入っている、
       // script = player.GetComponent<Broken>();//Shootingスクリプトを読み込む。
        bullet = GetComponent<CapsuleCollider>();
      //  script.bullet_Count++;//弾が出たらカウントを1追加する

        test1 = LayerMask.NameToLayer("Avoid_ChargeBullet");
         test2 = LayerMask.NameToLayer("Enemy");

       // Physics.IgnoreLayerCollision(test1, test2);
        // gameObject.layer = LayerMask.NameToLayer("ChargeBullet");
        // gameObject.layer = LayerMask.NameToLayer("Avoid_ChargeBullet");
    }

    void Action()
    {
    }

    // Update is called once per frame
    void Update()
    {

        losttime -= 1;
        if (losttime <= 0)
        {
            losttime = 0;
            Destroy(gameObject, losttime);
           // script.bullet_Count--;//弾が消えたらカウントを1減らす
        }

       // gameObject.layer =  LayerName.ActionPlayerLayer;
        //_actionTime = ACTION_TIME;

    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("君は今、壁に貫通攻撃した");//
        }

        if (collision.gameObject.tag == "Enemy")
        {
            //script.SP_power = 4;
            Debug.Log("君は今、敵に貫通攻撃した");//
        }

        if (collision.gameObject.tag == "move obj")
        {
            Debug.Log("君は今、動くオブジェクトに貫通攻撃した");//       
        }

       // Destroy(gameObject);
    }
}
