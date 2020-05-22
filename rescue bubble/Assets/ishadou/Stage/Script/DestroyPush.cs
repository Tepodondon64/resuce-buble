using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyPush : MonoBehaviour
{

    public float enemyhp = 10;
    public GameObject Push;
    public GameObject Fire;

    private float bullet_power = 1;//通常弾の攻撃力
    private float chargebullet_power = 10;//チャージショットの攻撃力

    private Vector3 FireScale;

    public float SP_power = 0;//
    int count = 0;
    int count2 = 0;
    void Start()
    {
        FireScale.x = 0.5f;
        FireScale.y = 1.0f;
        FireScale.z = 0.5f;
        // enemyhp = 1;
        // Debug.Log(enemyhp);//10
    }

    void OnTriggerEnter(Collider other)//当たった瞬間 isTriggerあり
    {
        //Debug.Log(enemyhp);//
        Debug.Log(other.gameObject.tag);//弾タグ確認する用

        if (other.gameObject.tag == "Bullet")//通常弾に当たったとき
        {
            enemyhp = enemyhp - bullet_power;
            FireScale.x -= 0.05f;
            FireScale.y -= 0.1f;
            FireScale.z -= 0.05f;
            if (enemyhp <= 0)
            {
                this.tag = "Bubble";
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }

        if (other.gameObject.tag == "ChargeBullet")//チャージ弾に当たったとき
        {
            enemyhp = enemyhp - chargebullet_power;
            if (enemyhp <= 0)
            {
                this.tag = "Bubble";
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }

    void Update()
    {
        // Debug.Log(enemyhp);//
        //Transform myTransform = this.transform;
        if (Fire.gameObject != null)
        {
            Fire.transform.localScale = new Vector3(FireScale.x, FireScale.y, FireScale.z);
        }
        if (enemyhp <= 0)
        {
            Destroy(Fire.gameObject);
            Destroy(Push);
        }

    }
}
