using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{

    GameObject target = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire2"))
{
//ロックを解除する
if (target != null )
target = null;
//else
//一番近いターゲットを取得する    
//target = FindClosestEnemy();
//ターゲットを取得
//target = GameObject.FindWithTag("Enemy");
}

if(target != null)
{
//ターゲットの方を向く
//transform.LookAt(target.transform);

//スムーズにターゲットの方を向く
Quaternion targetRotation = Quaternion.LookRotation
(target.transform.position - transform.position);

transform.rotation = Quaternion.Slerp
(transform.rotation, targetRotation, Time.deltaTime * 10);

transform.rotation = new Quaternion
(0, transform.rotation.y,0, transform.rotation.w);

//カメラをターゲットに向ける
//Transform cameraParent = Camera.main.transform.parent;

//Quaternion targetRotation2 = Quaternion.LookRotation
//(target.transform.position - cameraParent.position);

//cameraParent.localRotation = Quaternion.Slerp
//(cameraParent.localRotation, targetRotation2, Time.deltaTime * 10);

//cameraParent.localRotation = new Quaternion(cameraParent.localRotation.x, 0, 0,
//cameraParent.localRotation.w);

}

//一番近い敵を探して取得
target = GameObject.FindWithTag("Enemy");
{
    //GameObject.FindWithTag("Enemy");
    //{
    GameObject[] gos;
    gos = GameObject.FindGameObjectsWithTag("Enemy");
    GameObject closest = null;
    float distance = Mathf.Infinity;
    Vector3 position = transform.position;

    foreach (GameObject go in gos)
    {
        Vector3 diff = go.transform.position - position;
        float curDistance = diff.sqrMagnitude;

        if (curDistance < distance)
        {
            closest = go;
            distance = curDistance;
        }
    }
}


}
}
