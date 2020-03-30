using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Destroy2 : MonoBehaviour {
    private float losttime = 60;//出現して1秒後に消える
    //[SerializeField] private GameObject player; //オブジェクトを入れる変数名
    private GameObject player; //オブジェクトを入れる変数名

    Shooting2 script; //スプリクトを入れる変数名
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player"); //プレイヤーの中に入っている、
        script = player.GetComponent<Shooting2>();//Shooting2スクリプトを読み込む。
       // script.bullet_Count++;//弾が出たらカウントを1追加する
    }

    // Update is called once per frame
    void Update()
    {

        losttime -= 1;
        if (losttime <= 0)
        {
            losttime = 0;
            Destroy(gameObject, losttime);
            //script.bullet_Count--;//弾が消えたらカウントを1減らす
            //   script2.bullet_Count--;//弾が消えたらカウントを1減らす
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
           // script.bullet_Count--;//弾が消えたらカウントを1減らす
            Debug.Log("君は今、壁に攻撃した");//
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
          //  script.bullet_Count--;//弾が消えたらカウントを1減らす
            //script.SP_power = 4;
            Debug.Log("君は今、敵に攻撃した");//
        }

        if (collision.gameObject.tag == "move obj")
        {
            Destroy(gameObject);
           // script.bullet_Count--;//弾が消えたらカウントを1減らす
            Debug.Log("君は今、動くオブジェクトに攻撃した");//       
        }

        // Destroy(gameObject);
    }
}
