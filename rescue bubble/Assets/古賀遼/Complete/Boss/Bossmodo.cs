using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmodo : MonoBehaviour
{

    //アニメーション
    private Animator animator;
    private Animator aniani;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("ChangeColor1");

        animator = GetComponent<Animator>();
        aniani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //パンチ
    IEnumerator ChangeColor1()
    {
        yield return new WaitForSeconds(3);

        Invoke("ugomemo", 1);
        Invoke("soku", 3.5f);

        yield return new WaitForSeconds(7);

        StartCoroutine("ChangeColor1");
    }

    IEnumerator ChangeColor2()
    {
        yield return new WaitForSeconds(3);

        Invoke("ugomemo2", 1);

        yield return new WaitForSeconds(7);

        StartCoroutine("ChangeColor1");
    }

    void ugomemo()
    {
        animator.SetTrigger("anipan");
    }

    void ugomemo2()
    {
        aniani.SetTrigger("anifb");
    }

    void soku()
    {
        Vector3 sss = GameObject.Find("pasted__pasted__pCube7").transform.position;
        Vector3 ssss = new Vector3(sss.x, sss.y = 1, sss.z);

        GameObject syoyu = (GameObject)Resources.Load("ShockWave2");
        GameObject syosyo = (GameObject)Instantiate(syoyu, ssss, Quaternion.identity);

    }

    void OnTriggerEnter(Collider t)//FB
    {
        Debug.Log("aaaaa");
        //もしもぶつかったFBのTagが"FB"であったならば（条件）
        if (t.gameObject.tag == "Map")
        {
            Vector3 sss = GameObject.Find("pasted__pasted__pCube7").transform.position;
            Vector3 ssss = new Vector3(sss.x, sss.y, sss.z);

            GameObject syoyu = (GameObject)Resources.Load("ShockWave2");
            GameObject syosyo = (GameObject)Instantiate(syoyu, ssss, Quaternion.identity);

        }

    }
}
