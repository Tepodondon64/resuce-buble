using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour {

    public int HP;
    public GameObject Enemy;

    ////効果音の設定
    AudioSource audioSource;    //オーディオを所得するための変数
    public AudioClip DamageSE;         //プレイヤーがダメージを受けた時のSE

    Transform player;
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();//AudioのComponentを取得
        player =this.gameObject.GetComponent<Transform>(); //playerのTransformを取得
    }

    void OnCollisionEnter(Collision other)
    {
        //もしもぶつかった相手のTagが"Enemy"であったならば（条件） 
        if(other.gameObject.CompareTag("Enemy"))
        {
            //ダメージを受けた時にSEを鳴らす
              audioSource.PlayOneShot(DamageSE);
            //HPを１ずつ減少させる
            HP -= 1;
             //Transform player.position - (transform.forward * 10f);
           // player.position = player.position;
            if(HP <= 0)
            {
                // 1.5秒後に「GoToGameOver()」メソッドを実行する。
                Invoke("GoToGameOver", 1.5f);
            }
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
