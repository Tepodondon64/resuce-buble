using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_2 : MonoBehaviour {

    public float speed; //プレイヤーの動くスピード

    private Vector3 Player_pos; //プレイヤーのポジション
    private float x; //x方向のImputの値
    private float z; //z方向のInputの値
    private Rigidbody rigd;

    void Start()
    {
        Player_pos = GetComponent<Transform>().position; //最初の時点でのプレイヤーのポジションを取得
        rigd = GetComponent<Rigidbody>(); //プレイヤーのRigidbodyを取得


    }

    void Update()
    {

        x = Input.GetAxis("Horizontal"); //x方向のInputの値を取得
        z = Input.GetAxis("Vertical"); //z方向のInputの値を取得


        rigd.velocity = new Vector3(x * speed, 0, z * speed); //プレイヤーのRigidbodyに対してInputにspeedを掛けた値で更新し移動

        Vector3 diff = transform.position - Player_pos; //プレイヤーがどの方向に進んでいるかがわかるように、初期位置と現在地の座標差分を取得


        //////

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            transform.rotation = Quaternion.LookRotation(transform.position +
            (Vector3.right * Input.GetAxisRaw("Horizontal")) +
            (Vector3.forward * Input.GetAxisRaw("Vertical"))
            - transform.position);
        }


        Player_pos = transform.position; //プレイヤーの位置を更新


    }
}
