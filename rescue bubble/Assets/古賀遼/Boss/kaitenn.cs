using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaitenn : MonoBehaviour {

    private GameObject rightarm;
    private GameObject righthand;
    public int M = 0;
    private int J = 0;
    private int T = 0;
    // Use this for initialization
    void Start () {
        rightarm = GameObject.Find("Rightarm");
        righthand = GameObject.Find("Righthand");

        
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine("Hoge");


    }

    IEnumerator Hoge()
    {
        Transform myTransform = this.transform;
        Vector3 localAngle = myTransform.localEulerAngles;

        //enabled = true;
        //if (localAngle.z > -70.0f)
        if (M < 7)
        {
            localAngle.x = 0; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
            localAngle.y = 0; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
            localAngle.z -= 10.0f; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
            myTransform.localEulerAngles = localAngle; // 回転角度を設定
            M++;
        }

        Transform myTransform2 = rightarm.transform;
        Vector3 localAngle2 = myTransform2.localEulerAngles;
        //if(localAngle2.x >= 70.0f)
        if (J < 7)
        {
            localAngle2.x += 10.0f; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
            localAngle2.y = 0; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
            localAngle2.z = 0; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
            myTransform2.localEulerAngles = localAngle2; // 回転角度を設定
            J++;

        }

        Transform myTransform3 = righthand.transform;
        Vector3 localAngle3 = myTransform3.localEulerAngles;
        //if(localAngle3.x >= 35.0f)
        if (T < 4)
        {
            localAngle3.x += 10.0f; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
            localAngle3.y = 0; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
            localAngle3.z = 0; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
            myTransform3.localEulerAngles = localAngle3; // 回転角度を設定
            T++;

        }

        //2秒待つ
        yield return new WaitForSeconds(2.0f);
        enabled = false;
        StartCoroutine("Hoge2");

    }
    IEnumerator Hoge2()
    {
        //enabled = true;
        Transform myTransform4 = this.transform;
        Vector3 localAngle4 = myTransform4.localEulerAngles;
        localAngle4.x = 90; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
        localAngle4.y = 0; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
        localAngle4.z = 0; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
        myTransform4.localEulerAngles = localAngle4; // 回転角度を設定

        Transform myTransform5 = rightarm.transform;
        Vector3 localAngle5 = myTransform5.localEulerAngles;

        localAngle5.x = 0; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
        localAngle5.y = 0; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
        localAngle5.z = 0; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
        myTransform5.localEulerAngles = localAngle5; // 回転角度を設定

        Transform myTransform6 = righthand.transform;
        Vector3 localAngle6 = myTransform6.localEulerAngles;
        localAngle6.x = 0; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
        localAngle6.y = 0; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
        localAngle6.z = 0; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
        myTransform6.localEulerAngles = localAngle6; // 回転角度を設定
                                                     //2秒待つ
        yield return new WaitForSeconds(2.0f);

        enabled = false;
        
        StartCoroutine("Hoge3");
        //StartCoroutine("Hoge");

    }

    IEnumerator Hoge3()
    {
        Transform myTransform = this.transform;
        Vector3 localAngle = myTransform.localEulerAngles;

        //enabled = true;

        //if (localAngle.z > -70.0f)
        localAngle.x = 0; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
        localAngle.y = 0; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
        localAngle.z = 0; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
        myTransform.localEulerAngles = localAngle; // 回転角度を設定


        Transform myTransform2 = rightarm.transform;
        Vector3 localAngle2 = myTransform2.localEulerAngles;
        //if(localAngle2.x >= 70.0f)
        localAngle2.x = 0; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
        localAngle2.y = 0; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
        localAngle2.z = 0; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
        myTransform2.localEulerAngles = localAngle2; // 回転角度を設定

        Transform myTransform3 = righthand.transform;
        Vector3 localAngle3 = myTransform3.localEulerAngles;
        //if(localAngle3.x >= 35.0f)
        localAngle3.x = 0; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
        localAngle3.y = 0; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
        localAngle3.z = 0; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
        myTransform3.localEulerAngles = localAngle3; // 回転角度を設定



        //2秒待つ
        yield return new WaitForSeconds(2.0f);

        M = 0;
        J = 0;
        T = 0;

        //2秒待つ
        yield return new WaitForSeconds(1.0f);

        enabled = false;
        StartCoroutine("Hoge");
    }

}
