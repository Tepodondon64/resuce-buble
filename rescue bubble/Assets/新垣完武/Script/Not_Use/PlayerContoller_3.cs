using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller_3 : MonoBehaviour
{
    public float speed;
    private float x; //x方向のImputの値
    private float z; //z方向のInputの値
// Use this for initialization
void Start () 
{


}

// Update is called once per frame
    void Update () {

        x = Input.GetAxis("Horizontal"); //x方向のInputの値を取得
        z = Input.GetAxis("Vertical"); //z方向のInputの値を取得

        if (x < 0)//右方向に押されたとき  
        {
          //  transform.position += transform.forward * Time.deltaTime * speed;
            transform.Rotate(0, -90 * Time.deltaTime, 0 * speed);
        }


        else if (x > 0)//左方向に押されたとき
        {
            //transform.position += transform.forward * Time.deltaTime * speed;
            transform.Rotate(0, 90 * Time.deltaTime, 0 * speed);
        }

        if (z > 0)    //上キーに押されたとき
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        else if (z < 0)    //下キーに押されたとき
        {
            transform.position += transform.forward * Time.deltaTime * -(speed);
        }


        if (Input.GetKey(KeyCode.A))//左
        {
            transform.Rotate(0, -90 * Time.deltaTime, 0 * speed);
        }
        if(Input.GetKey(KeyCode.D))//右
        {
            transform.Rotate(0, 90 * Time.deltaTime, 0 * speed);

        }
        if (Input.GetKey(KeyCode.W))//上
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.S))//下
        {
            transform.position += transform.forward * Time.deltaTime * -(speed);
        }

    }

}
