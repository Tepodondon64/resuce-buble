using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireBall : MonoBehaviour {

    public AudioClip FireBallHitSE;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {

            Destroy(gameObject);
            Debug.Log("当たった");
        }
        if (collision.gameObject.tag == "ChargeBullet")
        {

            Destroy(gameObject);
            Debug.Log("当たった");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //FBがヒットした時に音を再生する
            //AudioSource.PlayClipAtPoint(FireBallHitSE, this.transform.position);
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Wall")
        {
            //FBがヒットした時に音を再生する
            AudioSource.PlayClipAtPoint(FireBallHitSE, this.transform.position);
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Burn")
        {
            //FBがヒットした時に音を再生する
            AudioSource.PlayClipAtPoint(FireBallHitSE, this.transform.position);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Easy")
        {
            //FBがヒットした時に音を再生する
            AudioSource.PlayClipAtPoint(FireBallHitSE, this.transform.position);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "rebble")
        {
            //FBがヒットした時に音を再生する
            AudioSource.PlayClipAtPoint(FireBallHitSE, this.transform.position);
            Destroy(gameObject);
        }

    }
}
