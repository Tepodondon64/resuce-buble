using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class Test_HPCtrl : MonoBehaviour {

    Slider _slider;

    float _hp = 0;
    void Start()
    {
        // スライダーを取得する
      //  _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    
    void Update()
    {
        // HP上昇
        //_hp += 1;
        //if (_hp > _slider.maxValue)
        //{
        //    // 最大を超えたら0に戻す
        //    _hp = _slider.minValue;
        //}

        //// HPゲージに値を設定
        //_slider.value = _hp;
        Test();
    }

    void Test()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;//XとZのポジションを固定
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;//固定全解除
        if (GetComponent<Rigidbody>().constraints == RigidbodyConstraints.FreezeAll)
        {
            //　すべて固定されていたら
        }
//       transform.rigidbody.constraints =
//RigidbodyConstraints.FreezeRotationX |
//RigidbodyConstraints.FreezeRotationZ |
//RigidbodyConstraints.FreezePositionY;
    }
}
