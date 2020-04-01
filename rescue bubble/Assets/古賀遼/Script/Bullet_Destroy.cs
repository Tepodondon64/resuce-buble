using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Destroy : MonoBehaviour {

    private float losttime = 120;//出現して2秒後に消える

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        losttime -= 1;
        if(losttime <= 0){
            losttime = 0;
            Destroy(gameObject,losttime);
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
        }
    }
}
