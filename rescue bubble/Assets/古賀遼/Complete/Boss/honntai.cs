using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honntai : MonoBehaviour {

    public int kaisu;
    public int hani;
	// Use this for initialization
	void Start () {
        Invoke("SENP", 0);
        Invoke("mark", 0);
    }
	
	// Update is called once per frame
	void Update () {
        //if(kaisu < 10) {
        //    InvokeRepeating("syutugen", 0, 0);
        //    //Invoke("syutugen", 1);
        //    kaisu++;
        //}

        //渦玉の関数の呼び出し
        //InvokeRepeating("syutugen", 0, 3);

        if (Input.GetKeyDown(KeyCode.B))
        {
            //GameObject obj = (GameObject)Resources.Load("Cube");
            //GameObject instance = (GameObject)Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
            //GameObject instance3 = (GameObject)Instantiate(obj, new Vector3(10, 0, 10), Quaternion.identity);
            //GameObject instance4 = (GameObject)Instantiate(obj, new Vector3(-10, 0, 10), Quaternion.identity);

        }

        
    }

    void syutugen()
    {
        GameObject obj = (GameObject)Resources.Load("fireEF");
        GameObject instance1 = (GameObject)Instantiate(obj, new Vector3(-10, 5, 0), Quaternion.identity);
        GameObject instance2 = (GameObject)Instantiate(obj, new Vector3(10, 0, 0), Quaternion.identity);
        Invoke("owari", 5);
    }

    void SENP()
    {
        //火災旋風の呼び出し
        GameObject obj = (GameObject)Resources.Load("senppu");
        GameObject instance1 = (GameObject)Instantiate(obj, new Vector3(0, -0.5f, 0), Quaternion.identity);

        Destroy(obj, 5f);
        //Invoke("mark", 5);
    }

    void mark()
    {
        //予測呼び出し（四角）
        //GameObject yotyou1 = (GameObject)Resources.Load("yosokusikaku");
        //GameObject yoyo1 = (GameObject)Instantiate(yotyou1, new Vector3(0, 1f, 0), Quaternion.identity);

        //予測呼び出し（丸）
        GameObject yotyou2 = (GameObject)Resources.Load("yosokumaru");
        GameObject yoyo2 = (GameObject)Instantiate(yotyou2, new Vector3(0, 1f, 0), Quaternion.identity);

        //Destroy(yoyo1,5f);
        Destroy(yoyo2, 5f);
    }

    void owari()
    {
        GameObject obj = (GameObject)Resources.Load("fireEF");
        Destroy(gameObject);
        //Destroy(obj);
    }
}
