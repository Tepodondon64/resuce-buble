using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_generation : MonoBehaviour {

    /*このスクリプトは泡を当てた場所にパーティクルを発射させるために
     必要なものです。*/

    /*使い方は当てられオブジェクトにこのスクリプトを入れて発生させた
     いパーティクルをParticlePrefabsに入れるだけです。*/

    //コピペなので仕組みに関しては何となくで説明する。

    public GameObject ParticlePrefabs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")   //通常泡が当たったとき
        {
            GameObject particle = Instantiate(ParticlePrefabs) as GameObject;//パーティクルのプレハブのクローンを生成している
            Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);//オブジェクトの当たった場所の状態を取得している
            particle.transform.position = hitPos;//パーティクルの発生地点をオブジェクトが当たった場所にしている。
          //  Destroy(other.gameObject);
        }

        //if (other.gameObject.tag == "ChargeBullet")   //チャージ泡が当たったとき
        //{
        //    GameObject particle = Instantiate(ParticlePrefabs) as GameObject;//パーティクルのプレハブのクローンを生成している
        //    Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);//オブジェクトの当たった場所の状態を取得している
        //    particle.transform.position = hitPos;//パーティクルの発生地点をオブジェクトが当たった場所にしている。
        //    //  Destroy(other.gameObject);
        //}
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
