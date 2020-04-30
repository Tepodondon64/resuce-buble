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
    private float targetTime = 2.0f;
    private float currentTime = 0;
    //public Material material;

    public GameObject Enemy;
    float speed = 1.0f;
    private Vector3 vec;

    void Start()
    {
         Player = GameObject.Find("Player");

        //gameObject.GetComponent<Renderer>().material = this.material;
        //Vector3 playerpos = this.Player.transform.position;
        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
    }

    void Update()
    {
       
        currentTime += Time.deltaTime;
        if (targetTime < currentTime)
        {
            //Rigidbody取得
            Rigidbody rb = this.GetComponent<Rigidbody>();

            //Vector3 vec = Player.transform.position;
            //rb.AddForce(vec);
            
            //現在の速度をログに表示
            Debug.Log(rb.velocity.magnitude);

            this.GetComponent<Renderer>().material.color = Color.white;

            //プレイヤーの方を向く
            this.transform.LookAt(Player.transform);

            //敵の座標を変数posに保存
            var pos = this.gameObject.transform.position;

            //敵の位置をプレイヤーの位置にする
            this.transform.position = pos;

            currentTime = 0;

            //敵からプレイヤーに向かうベクトルをつくる
            //プレイヤーの位置から敵の位置（弾の位置）を引く
            //this.calcZ = pos.z - Player.transform.position;
            Vector3 vec = Player.transform.position - pos;

            //弾のRigidBodyコンポネントのvelocityに先程求めたベクトルを入れて力を加える
            gameObject.GetComponent<Rigidbody>().velocity = vec;
            //float step = speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(pos, Player.transform.position, 0.8f);


            //Vector3 playerpos = this.Player.transform.position;                 //player位置情報取得する
            //this.calcZ = this.transform.position.z - playerpos.z;               //敵のZ座標からボールのZ座標を引く。これで距離が出る

            //tmpE = hogeEne.transform.position;                                  //プレイヤーの位置情報をvector3でtmpに格納
            //this.transform.position = t;

        }


        //Vector3 playerpos = this.Player.transform.position;
        //InvokeRepeating("Attack", 2, 4);
        //Invoke("Cancel", 5);
    }
}
    //void OncollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Player")
    //    {
    //        Debug.Log("ssss");
    //        hogeEne = GameObject.Find("Player").GetComponent<Transform>();
    //        Ecnt = 0;

    //    }
    //}

//    void Attack()
//    {
//        Vector3 playerpos = this.Player.transform.position;                 //player位置情報取得する
//        this.calcZ = this.transform.position.z - playerpos.z;               //敵のZ座標からボールのZ座標を引く。これで距離が出る
//        if(this.calcZ <50)
//        {
//            if(this.Ecnt == 0)
//            {
//                hogeEne = GameObject.Find("Player").GetComponent<Transform>();      //プレイヤーを見つける
//                tmpE = hogeEne.transform.position;                                  //プレイヤーの位置情報をvector3でtmpに格納
//                this.Ecnt = 2;
//            }
//            if (this.Ecnt == 2)
//            {
//                
//                Debug.Log("aa");
//                //this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(tmpE.x, tmpE.y, tmpE.z), 0.2f);
//            }
//        }
//    }       
//}


