using UnityEngine;

public class Flame : MonoBehaviour
{
    public float speed = 0.05f;//移動スピード
    public Transform target;
    public int Size = 0;
    public int Count = 0;

    void Start()
    {
        //target = GameObject.Find("Flameradiation").transform;
        target = GameObject.Find("Player").transform;
        this.transform.LookAt(target.transform);
        
    }

    void Update()
    {
        if (Size <= 5){ 
        Transform myTransform = this.transform;
       
        //Vector3 pos = myTransform.position;
        //pos.z -= 0.10f;
        // 座標を取得
        Vector3 loc = myTransform.localScale;

            loc.x += 0.50f;    // x座標へ0.01加算
            loc.y += 0.50f;    // y座標へ0.01加算
            loc.z += 0.50f;    // z座標へ0.01加算

            //pos.z -= 0.05f;
            myTransform.localScale = loc;  // 座標を設定
                                       //myTransform.position = pos;

            Size += 1;
        }

        if (Size >= 5)
        {
            Invoke("Firing",1);
        }
    }

    void Firing()
    {

        Transform myTransform = this.transform;

        Vector3 loc = myTransform.localScale;
        if (Count < 2)
        {
            this.transform.LookAt(target.transform);
            Count++;
        }
        //loc.x += 0.00f;    // x座標へ0.01加算
        //loc.y += 0.00f;    // y座標へ0.01加算
        loc.z += 0.60f;    // z座標へ0.01加算

        Invoke("Firing2", 3);
        transform.position += transform.forward * speed;
        myTransform.localScale = loc;  // 座標を設定
    }

    void Firing2()
    {
        Transform myTransform = this.transform;
        Vector3 loc = myTransform.localScale;

        loc.z -= 0.60f;

        transform.position += transform.forward * speed;
        myTransform.localScale = loc;  // 座標を設定

    }
}