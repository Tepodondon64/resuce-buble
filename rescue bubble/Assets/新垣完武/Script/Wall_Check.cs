using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Check : MonoBehaviour {

    GameObject Wall;
  // public GameObject Player;   //ターゲットを入れる(プレイヤーを入れる)

    public byte Alpha;          //透明度の度合い   0 ～ 255     透明度ではない ～ 完全に透明
    private bool AlphaTrigger;   //false:透明度を戻す  true:透明度を与える
    MeshRenderer mr;            //相手のオブジェクトのMeshRendererを取得するための変更

	// Use this for initialization
	void Start () {
        //mr = GetComponent<MeshRenderer>();
        // mr.material.color = mr.material.color - new Color32(0, 0, 0, Alpha);
        // AlphaTrigger = true;
        AlphaTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {

        //ずっとこの方向に向いてもらおう
       // this.gameObject.transform.LookAt(Player.transform);

        /*Cキーで透明度のONとOFF*/

        //if (Input.GetKeyDown(KeyCode.C) && AlphaTrigger == true)
        //{
        //    AlphaTrigger = false;
        //    mr.material.color = mr.material.color + new Color32(0, 0, 0, Alpha);
        //}

        //else if (Input.GetKeyDown(KeyCode.C) && AlphaTrigger == false)
        //{
        //    AlphaTrigger = true;
        //    mr.material.color = mr.material.color - new Color32(0, 0, 0, Alpha);
        //}


	}


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            //mr = GetComponent<MeshRenderer>();
            if (AlphaTrigger == false)
            {
                if (other.gameObject.GetComponent<MeshRenderer>() != null)//壁のオブジェクトにMeshRendererがついていたら通る
                {
                    mr = other.gameObject.GetComponent<MeshRenderer>();
                    mr.material.color = mr.material.color - new Color32(0, 0, 0, Alpha);
                    AlphaTrigger = true;
                }
            }
             Debug.Log("壁をすり抜けている");//
        }
        //Debug.Log("すり抜けている");
    }

    void OnTriggerExit(Collider other)
    {
        if (AlphaTrigger == true)
        {
            if (other.gameObject.GetComponent<MeshRenderer>() != null)
            {
                mr.material.color = mr.material.color + new Color32(0, 0, 0, Alpha);//壁のオブジェクトにMeshRendererがついていたら通る
                AlphaTrigger = false;
            }
        }


        Debug.Log("壁を通り抜け終えた");
    }

}
