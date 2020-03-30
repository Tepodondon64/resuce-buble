using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rt_Bullet_Destroy : MonoBehaviour
{

    private float losttime = 300;//出現して5秒後に消える = 300

    private  int ShootTime = 60;
    private int EndTime;

    Transform tf;
    Transform StartTf;

   // [SerializeField] private GameObject player; //オブジェクトを入れる変数名
    GameObject player; //オブジェクトを入れる変数名

    Rotation_Shooting script; //スプリクトを入れる変数名
    // Use this for initialization
    void Start()
    {
        StartTf = GetComponent<Transform>();//元の座標を登録する
        player = GameObject.Find("Player"); //プレイヤーの中に入っている、
        script = player.GetComponent<Rotation_Shooting>();//Rotation_Shootingスクリプトを読み込む。

        EndTime = ShootTime;
        ShootTime = 0;

       // script.bullet_Count++;//弾が出たらカウントを1追加する
    }

    // Update is called once per frame
    void Update()
    {
        tf = GetComponent<Transform>();//今の座標を登録する
         Vector3 force;
         force =script.Muzzle.forward * script.tama_speed;//forward
        // force = this.gameObject.transform.forward * script.tama_speed;//forward

         Shot();

        // Rigidbodyに力を加えて発射
        // GetComponent<Rigidbody>().AddForce(force);


        losttime -= 1;
        if (losttime <= 0)
        {
            losttime = 0;
            Destroy(gameObject, losttime);
           // script.bullet_Count--;//弾が消えたらカウントを1減らす
        }
    }

    void Shot() 
    {
        //if (++ShootTime > EndTime)
        //{

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;//固定全解除
          //  ShootTime = 0;
       // }
        if (script.Rt_Shoot_flg == false )
        {
         //   GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;//固定全解除
        }

        if (script.Rt_Shoot_flg == true /*&& StartTf == tf*/)
        {
         //  GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;//XとZのポジションを固定
        }
    }

    void OnCollisionEnter(Collision collision)//他のcollider/rigidbodyに触れたとき
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "ChargeBullet"
            || collision.gameObject.tag == "Player")//玉が玉に当たったら(チャージ弾も含む)または、玉がプレイヤーに当たったら
        {

            GetComponent<SphereCollider>().isTrigger = true;//すり抜けるようにする

        }
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "ChargeBullet"
            && collision.gameObject.tag != "Player")//玉(チャージ弾も含む)が玉とプレイヤー以外に当たったら
        {
            GetComponent<SphereCollider>().isTrigger = false;//ぶつかるようにする
            //Destroy(this.gameObject);
            Destroy(gameObject);
           // script.bullet_Count--;//弾が消えたらカウントを1減らす
        }
    }

}
