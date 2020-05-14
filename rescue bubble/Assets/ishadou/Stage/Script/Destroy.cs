using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public float enemyhp = 10;

    private float bullet_power = 1;//通常弾の攻撃力

    public float SP_power = 0;//
    int count = 0;
    int count2 = 0;
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)//当たった瞬間 isTriggerあり
    {
        //Debug.Log(enemyhp);//
        Debug.Log(other.gameObject.tag);//弾タグ確認する用

        if (other.gameObject.tag == "Bullet")//通常弾に当たったとき
        {
            enemyhp = enemyhp - bullet_power;
        }

        if (other.gameObject.tag == "ChargeBullet")//チャージ弾に当たったとき
        {
            enemyhp = 0;
            if (enemyhp <= 0)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    void Update()
    {
        this.transform.localScale = new Vector3(3 + (enemyhp/2), 1+(enemyhp / 10), 3 + (enemyhp/2));

        if (enemyhp <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}