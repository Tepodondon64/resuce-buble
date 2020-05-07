using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Ghost_Object : MonoBehaviour {
    //Color color;
   public  byte Alpha;          //透明度の度合い   0 ～ 255     透明度ではない ～ 完全に透明
   private bool AlphaTrigger;   //false:透明度を戻す  true:透明度を与える
   MeshRenderer mr;            //このオブジェクトのMeshRendererを取得するための変更
	// Use this for initialization
	void Start () {
        mr = GetComponent<MeshRenderer>();
       // mr.material.color = mr.material.color - new Color32(0, 0, 0, Alpha);
       // AlphaTrigger = true;
         AlphaTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {

        /*Cキーで透明度のONとOFF*/

        if (Input.GetKeyDown(KeyCode.C) && AlphaTrigger == true)
        {
            AlphaTrigger = false;
            mr.material.color = mr.material.color + new Color32(0, 0, 0, Alpha);
        }

       else if (Input.GetKeyDown(KeyCode.C) && AlphaTrigger == false)
        {
            AlphaTrigger = true;
            mr.material.color = mr.material.color - new Color32(0, 0, 0, Alpha);
        }
	}
}
