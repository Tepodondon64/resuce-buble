using UnityEngine;
using System.Collections;

public class RotateCubeeeeee : MonoBehaviour
{

    public float speed = 100;
    public int SizeXZ = 0;
    public int SizeY = 0;
    public int Count = 0;

    void Start()
    {
    }
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;
        Vector3 loc = myTransform.localScale;

        //transform.Rotate(new Vector3(0, 5, 0)*speed);
       
        //火炎のサイズ関係の呼び出し
        //InvokeRepeating("speeeeed", 1, 5);
        Invoke("speeeeed", 0);
        //Invoke("Destroy", 10);
    }

    void speeeeed()
    {
        // transformを取得
        Transform myTransform = this.transform;

        Vector3 loc = myTransform.localScale;
        //if (SizeY<500)
        if(loc.y<50f)
        {
            //loc.x += 0.1f;
            loc.y += 0.5f;
            //loc.z += 0.1f;

            SizeY += 1;
        }
        Invoke("wide", 5);
        myTransform.localScale = loc;  // 座標を設定

        //speed += 0.5f;
    }

    void wide()
    {
        Transform myTransform = this.transform;
        Vector3 loc = myTransform.localScale;
        if (SizeXZ < 4)
        {
            loc.x += 0.1f*speed;
            loc.z += 0.1f*speed;
            SizeXZ += 1;
        }
        myTransform.localScale = loc;  // 座標を設定
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}