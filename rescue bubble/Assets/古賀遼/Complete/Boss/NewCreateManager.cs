using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCreateManager : MonoBehaviour
{

    GameObject[] characters;
    GameObject currentChar;
    Animator MSN;
    int _currentCharNum = 1;


    public Transform target;
    private int BOSSHP = 5000;

    public Transform playa;

    bool witch = false;

    int eCount;

    private int P = 0;

    public EnemyStatus enemystatus;

    bool SWI = false;

    public AudioClip furikaburu;
    public AudioClip panti;
    public AudioClip kasai;
    public AudioClip kasai2;

    AudioSource audioSource;

    //プレイヤーのオブジェクトをここに入れる。
    public GameObject Player_obj;

    // Use this for initialization
    void Start()
    {
        characters = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("ya");
        Debug.Log("I have " + characters.Length + " Changable Characters");
        Movement(_currentCharNum);

        audioSource = GetComponent<AudioSource>();

        target = GameObject.Find("Player").transform;
        StartCoroutine("ChangeColor1");

    }

    // --- 各攻撃モーションの変更 ---------------------------------------------------------------
    void Movement(int characterNum)
    {
        foreach (GameObject mo in characters)         // いったん全キャラクターを非アクティブにする
        {
            mo.SetActive(false);
        }

        currentChar = characters[characterNum];         // 指定した番号のキャラクターだけをアクティブにする
        currentChar.SetActive(true);

        // 対象キャラクターのAnimatorコンポーネントを取得する
        MSN = currentChar.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //ボスのHPを毎回取る
        eCount = enemystatus.enemy_hp;

        Vector3 Player_pos = Player_obj.transform.position;

        if (SWI == true)
        {
            //プレイヤーの方を向く
            Vector3 target = playa.position;
            target.y = this.transform.position.y;
            this.transform.LookAt(target);
        }

        //Debug.Log(_currentCharNum);
    }

    //ファイアボール
    IEnumerator ChangeColor1()
    {
        yield return new WaitForSeconds(2);

        // プレハブを元にオブジェクトを生成する
        Invoke("Call", 2f);

        Debug.Log("これはできてる");
        Debug.Log(eCount); //5

        audioSource.PlayOneShot(furikaburu);

        SWI = true;

        audioSource.PlayOneShot(furikaburu);

        _currentCharNum = 0;
        Movement(_currentCharNum);
        //_currentCharNum = 2;
        //Movement(_currentCharNum);

        yield return new WaitForSeconds(11);
        SWI = false;

        if (eCount < 1500)
        {
            P++;
        }
            //_currentCharNum = 3;
            //Movement(_currentCharNum);

            //5秒停止
            yield return new WaitForSeconds(4);
        Debug.Log(eCount); //5

        Vector3 Player_pos = Player_obj.transform.position;

            if (P == 1)
            {
                StartCoroutine("ChangeColor3");
                P++;
                SWI = false;
            }else{
                Debug.Log("シーン移動");

                if (Player_pos.z > 9 && Player_pos.x < 20 && Player_pos.x > -15)
                {
                    StartCoroutine("ChangeColor2");
                    SWI = false;
                    Debug.Log("パンチ移動");
                }
                else
                {
                    StartCoroutine("ChangeColor1");
                    SWI = false;
                    Debug.Log("FB移動");
                }
             }
    }

    void Call()
    {

        Invoke("FB1", 2f);
        Invoke("FB1", 3f);
        Invoke("FB1", 4f);
        Invoke("FB1", 5f);
        Invoke("FB1", 6f);
    }

    void FB1()
    {
        Vector3 hira = GameObject.Find("pasted__pasted__pasted__pasted__pCube7").transform.position;
        Vector3 hiramae = new Vector3(hira.x, hira.y = 20, hira.z);
        GameObject obj = (GameObject)Resources.Load("SFB");
        GameObject instance = (GameObject)Instantiate(obj, hiramae, Quaternion.identity);
    }

    //パンチ
    IEnumerator ChangeColor2()
    {
        yield return new WaitForSeconds(2);

        // プレハブを元にオブジェクトを生成する

        Debug.Log("これはできてる");
        Debug.Log(eCount); //5

        SWI = true;

        Invoke("PanSE", 1);
        Invoke("PanSE2", 5.9f);

        //_currentCharNum = 3;
        //Movement(_currentCharNum);

        _currentCharNum = 2;
        Movement(_currentCharNum);

        yield return new WaitForSeconds(5);
        SWI = false;
        Invoke("sw", 1.1f);

        if (eCount < 1500)
        {
            P++;
        }

        yield return new WaitForSeconds(6);

        //5秒停止
        yield return new WaitForSeconds(4);
        Debug.Log(eCount); //5

        //_currentCharNum = 3;
        //Movement(_currentCharNum);

        Vector3 Player_pos = Player_obj.transform.position;

        if (P == 1)
        {
                StartCoroutine("ChangeColor3");
                P++;
                SWI = false;
        } else{
            if (Player_pos.z > 9 && Player_pos.x < 20 && Player_pos.x > -15)
            {
                StartCoroutine("ChangeColor2");
                SWI = false;
            }
            else
            {
                StartCoroutine("ChangeColor1");
                SWI = false;
            }
        }
    }

    void PanSE()
    {
        audioSource.PlayOneShot(furikaburu);
    }

    void PanSE2()
    {
        audioSource.PlayOneShot(panti);
    }

    void sw()
    {
        Vector3 sw = GameObject.Find("pasted__pasted__pCube7").transform.position;
        Vector3 sww = new Vector3(sw.x, sw.y = 1, sw.z);

        //tmp2 = new Vector3(tmp.x - 20, tmp.y, tmp.z);

        GameObject syoyu = (GameObject)Resources.Load("ShockWave2");
        GameObject syosyo = (GameObject)Instantiate(syoyu, sww, Quaternion.identity);
    }

    //火災旋風
    IEnumerator ChangeColor3()
    {
        _currentCharNum = 3;
        Movement(_currentCharNum);

        Debug.Log("よくここまで来たね");

        Invoke("mark", 0);

        Transform lasthoko = GameObject.Find("MainChar").transform;

        Vector3 kasahoko = GameObject.Find("MainChar").transform.localEulerAngles;
        kasahoko.x = 0.0f;
        kasahoko.y = -180.0f;
        kasahoko.z = 0.0f;

        lasthoko.localEulerAngles = kasahoko;

        //火災旋風の呼び出し
        GameObject obj9 = (GameObject)Resources.Load("FireWhirlwind");
        GameObject instance9 = (GameObject)Instantiate(obj9, new Vector3(0, 3, 27), Quaternion.identity);

        audioSource.PlayOneShot(kasai);

        Invoke("kasaSE", 5);
        yield return new WaitForSeconds(15);

        Vector3 Player_pos = Player_obj.transform.position;

        if (Player_pos.z > 9 && Player_pos.x < 20 && Player_pos.x > -15)
        {
            //StartCoroutine("ChangeColor2");
            //SWI = false;

            StartCoroutine("ChangeColor2");
            SWI = false;
        }else{
            //StartCoroutine("ChangeColor1");
            //SWI = false;

            StartCoroutine("ChangeColor1");
            SWI = false;
        }
    }
    void kasaSE()
    {
        audioSource.PlayOneShot(kasai2);
    }

    void mark()
    {
        //予測呼び出し（四角）
        GameObject yotyou1 = (GameObject)Resources.Load("yosokusikaku");
        GameObject yoyo1 = (GameObject)Instantiate(yotyou1, new Vector3(0, 1f, 6), Quaternion.identity);

        //予測呼び出し（丸）
        //GameObject yotyou2 = (GameObject)Resources.Load("yosokumaru");
        //GameObject yoyo2 = (GameObject)Instantiate(yotyou2, new Vector3(0, 1f, 0), Quaternion.identity);

        //Destroy(yoyo1,5f);
        Destroy(yoyo1, 5f);
    }

}
