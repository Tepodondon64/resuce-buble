using UnityEngine;
using System.Collections;

public class RotateCubeeeeee : MonoBehaviour
{

    public float speed = 100;
    public int SizeXZ = 0;
    public int SizeY = 0;
    public int Count = 0;

    AudioSource audioSource;

    public AudioClip senp;

    public float volume;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("kasaion", 5);
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
        Vector3 pos = myTransform.position;

        //if (SizeY<500)
        if (loc.y<50f)
        {
            //loc.x += 0.1f;
            loc.y += 0.5f;
            pos.y += 0.25f;
            //loc.z += 0.1f;

            SizeY += 1;
        }
        Invoke("wide", 7);
        myTransform.localScale = loc;  // 座標を設定
        myTransform.position = pos;

        //speed += 0.5f;
    }

    void wide()
    {
        Transform myTransform = this.transform;

        Vector3 loc = myTransform.localScale;
        Vector3 pos = myTransform.position;

        if(loc.x < 80)
        {
            loc.x += 0.1f * speed;
            
        }

        if(loc.z < 60)
        {
            loc.z += 0.1f * speed;
            pos.z -= 0.05f * speed;
        }

        

        Invoke("weeei",2);
        myTransform.localScale = loc;  // 座標を設定
        myTransform.position = pos;

        
    }

    void weeei()
    {
        GameObject kabe1 = GameObject.Find("safety_block1");
        GameObject kabe2 = GameObject.Find("safety_block2");
        GameObject kabe3 = GameObject.Find("safety_block3");
        GameObject kabe4 = GameObject.Find("safety_block4");
        GameObject kabe5 = GameObject.Find("safety_block5");

        Destroy(kabe1);
        Destroy(kabe2);
        Destroy(kabe3);
        Destroy(kabe4);
        Destroy(kabe5);

    }

    void kasaion()
    {
        audioSource.PlayOneShot(senp);
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }

}